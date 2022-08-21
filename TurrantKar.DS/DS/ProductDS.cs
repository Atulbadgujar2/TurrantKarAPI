using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Common;
using TurrantKar.DTO;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Product
    /// </summary>
    public class ProductDS : BaseDS<Product>, IProductDS
    {
        #region Local Member
        IProductRepository _productRepository;
        IProductCategoryMappingDS _productCategoryMappingDS;
        IProductPictureMappingDS _productPictureMappingDS;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductDS(IProductRepository productRepository, IProductCategoryMappingDS productCategoryMappingDS, IProductPictureMappingDS productPictureMappingDS, IUnitOfWork unitOfWork) : base(productRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _productCategoryMappingDS = productCategoryMappingDS;
            _productPictureMappingDS = productPictureMappingDS;
        }
        #endregion

        #region Get 
        public async Task<List<ProductViewDTO>> GetProductList(bool showHomePage, CancellationToken token = default(CancellationToken))
        {
            return await _productRepository.GetProductList(showHomePage,token);
        }

        /// <inheritdoc />  
        public async Task<ProductViewDTO> GetProductDetailById(int productId, CancellationToken token = default(CancellationToken))
        {
            return await _productRepository.GetProductDetailById(productId, token);
        }
        #endregion
      

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();

            //Transaction Manage
            using (TKDBContext context = new TKDBContext())
            {
                //Begin Trasaction
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Guid newGuid = Guid.NewGuid();

                        Product entity = ProductDTO.MapToEntity(model);
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Product product = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        ProductPictureMapping productPictureMapping = new ProductPictureMapping();
                        productPictureMapping.ProductId = product.Id;
                        productPictureMapping.PictureId = newGuid;
                        _productPictureMappingDS.UpdateSystemFieldsByOpType(productPictureMapping, OperationType.Add);
                        await _productPictureMappingDS.AddAsync(productPictureMapping, token);

                        ProductCategoryMapping productCategoryMapping = new ProductCategoryMapping();
                        productCategoryMapping.ProductId = product.Id;
                        productCategoryMapping.CategoryId = model.CategoryId;
                        _productCategoryMappingDS.UpdateSystemFieldsByOpType(productCategoryMapping, OperationType.Add);
                        await _productCategoryMappingDS.AddAsync(productCategoryMapping, token);

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = product.Id;
                        commonRonsponseDTO.GuidId = newGuid;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }

                    return commonRonsponseDTO;
                }
            }
        }
        #endregion

        #region Update
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> UpdateProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            //Transaction Manage
            using (TKDBContext context = new TKDBContext())
            {
                //Begin Trasaction
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Get existing Product.
                        Product entity = await _productRepository.GetAsync(model.Id, token);
                        if (entity != null & !entity.IsDeleted)
                        {
                            entity = ProductDTO.MapToEntityWithEntity(model, entity);
                            UpdateSystemFieldsByOpType(entity, OperationType.Update);
                            await _productRepository.UpdateAsync(entity, entity.Id, token);
                        }

                        // Get existing Product.
                        ProductCategoryMapping productCategoryMapping = await _productCategoryMappingDS.FindAsync(i=> i.ProductId == model.Id, token);
                        if (productCategoryMapping != null & !productCategoryMapping.IsDeleted)
                        {
                            if(productCategoryMapping.CategoryId != model.CategoryId)
                            {
                                productCategoryMapping.CategoryId = model.CategoryId;
                                _productCategoryMappingDS.UpdateSystemFieldsByOpType(productCategoryMapping, OperationType.Update);
                                await _productCategoryMappingDS.UpdateAsync(productCategoryMapping, productCategoryMapping.Id, token);
                            }
                           
                        }

                        if (model.IsNewGuid)
                        {
                            Guid newGuid = Guid.NewGuid();
                            ProductPictureMapping productPictureMapping = await _productPictureMappingDS.FindAsync(i => i.ProductId == model.Id, token);                          
                            productPictureMapping.ProductId = model.Id;
                            productPictureMapping.PictureId = newGuid;
                            _productPictureMappingDS.UpdateSystemFieldsByOpType(productPictureMapping, OperationType.Add);
                            await _productPictureMappingDS.UpdateAsync(productPictureMapping, productPictureMapping.Id, token);                           
                        }
                        _unitOfWork.SaveAll();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }

                    return commonRonsponseDTO;
                }
            }
          
            
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeleteProductAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();

            //Transaction Manage
            using (TKDBContext context = new TKDBContext())
            {
                //Begin Trasaction
                using (var transaction = context.Database.BeginTransaction())
                {
                    Product entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

                    ProductCategoryMapping productCategoryMapping = await _productCategoryMappingDS.FindAsync(v => v.ProductId == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

                    ProductPictureMapping productPictureMapping = await _productPictureMappingDS.FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

                    if (entity != null)
                    {
                        responseModel.IsSuccess = true;
                        UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                        await _productRepository.UpdateAsync(entity, entity.Id, token);

                        _productCategoryMappingDS.UpdateSystemFieldsByOpType(productCategoryMapping, OperationType.Delete);
                        await _productCategoryMappingDS.UpdateAsync(productCategoryMapping, productCategoryMapping.Id, token);

                        _productPictureMappingDS.UpdateSystemFieldsByOpType(productPictureMapping, OperationType.Delete);
                        await _productPictureMappingDS.UpdateAsync(productPictureMapping, productPictureMapping.Id, token);
                        // Save Data
                        _unitOfWork.SaveAll();
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                    }
                    return responseModel;
                }
            }

            // Get entity if exists
           
        }
        #endregion
    }
}
