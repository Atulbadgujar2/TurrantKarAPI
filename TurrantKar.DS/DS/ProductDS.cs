using System;
using System.Threading;
using System.Threading.Tasks;
using TK.Data;
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
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductDS(IProductRepository productRepository, IUnitOfWork unitOfWork) : base(productRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 

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

                        Product entity = new Product();
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Product Product = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = Product.Id;
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
            // Get existing Product.
            Product entity = await _productRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                //entity = ProductDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _productRepository.UpdateAsync(entity, entity.Id, token);
            }
            _unitOfWork.SaveAll();
            return commonRonsponseDTO;
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeleteProductAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            Product entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _productRepository.UpdateAsync(entity, entity.Id, token);
                // Save Data
                _unitOfWork.SaveAll();
            }
            else
            {
                responseModel.IsSuccess = false;
            }
            return responseModel;
        }
        #endregion
    }
}
