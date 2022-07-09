using System;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Data;
using TurrantKar.Common;
using TurrantKar.DTO;
using TurrantKar.Entity;
using TurrantKar.Repository;
using System.Collections.Generic;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Category
    /// </summary>
    public class CategoryDS : BaseDS<Category>, ICategoryDS
    {
        #region Local Member
        ICategoryRepository _categoryRepository;
        ICategoryPictureMappingDS _categoryPictureMappingDS;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CategoryDS(ICategoryRepository categoryRepository, ICategoryPictureMappingDS categoryPictureMappingDS, IUnitOfWork unitOfWork) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryPictureMappingDS = categoryPictureMappingDS;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 
        public async Task<List<CategoryViewDTO>> GetCategoryList(CancellationToken token = default(CancellationToken))
        {
            return await _categoryRepository.GetCategoryList(token);
        }

        /// <inheritdoc />  
        public async Task<CategoryViewDTO> GetCategoryDetailById(int categoryId, CancellationToken token = default(CancellationToken))
        {
            return await _categoryRepository.GetCategoryDetailById(categoryId, token);
        }
        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddCategoryAsync(CategoryDTO model, CancellationToken token = default(CancellationToken))
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

                        Category entity = CategoryDTO.MapToEntity(model);
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Category category = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        CategoryPictureMapping categoryPictureMapping = new CategoryPictureMapping();
                        categoryPictureMapping.CategoryId = category.Id;
                        categoryPictureMapping.PictureId = newGuid;
                        _categoryPictureMappingDS.UpdateSystemFieldsByOpType(categoryPictureMapping, OperationType.Add);
                         await _categoryPictureMappingDS.AddAsync(categoryPictureMapping, token);

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = category.Id;
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
        public async Task<ResponseModelDTO> UpdateCategoryAsync(CategoryDTO model, CancellationToken token = default(CancellationToken))
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
                        // Get existing Category.
                        Category entity = await _categoryRepository.GetAsync(model.Id, token);
                        if (entity != null & !entity.IsDeleted)
                        {
                            entity = CategoryDTO.MapToEntityWithEntity(model, entity);
                            UpdateSystemFieldsByOpType(entity, OperationType.Update);
                            await _categoryRepository.UpdateAsync(entity, entity.Id, token);
                        }
                        if (model.IsNewGuid)
                        {
                            Guid newGuid = Guid.NewGuid();
                            CategoryPictureMapping categoryPictureMapping = new CategoryPictureMapping();
                            categoryPictureMapping.CategoryId = model.Id;
                            categoryPictureMapping.PictureId = newGuid;
                            _categoryPictureMappingDS.UpdateSystemFieldsByOpType(categoryPictureMapping, OperationType.Add);
                            await _categoryPictureMappingDS.AddAsync(categoryPictureMapping, token);
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
        public async Task<ResponseModelDTO> DeleteCategoryAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            Category entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _categoryRepository.UpdateAsync(entity, entity.Id, token);
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
