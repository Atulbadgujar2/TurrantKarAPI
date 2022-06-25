using System;
using System.Collections.Generic;
using System.IO;
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
                        //var filePath = Path.GetTempFileName();

                        //Byte[] bytes = Convert.FromBase64String(model.FileUpload.FileAsBase64);
                        //File.WriteAllBytes(filePath, bytes);

                        Category entity = CategoryDTO.MapToEntity(model);
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Category category = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        CategoryPictureMapping categoryPictureMapping = new CategoryPictureMapping();
                        categoryPictureMapping.CategoryId = category.Id;
                        categoryPictureMapping.PictureId = Guid.NewGuid();
                        _categoryPictureMappingDS.UpdateSystemFieldsByOpType(categoryPictureMapping, OperationType.Add);
                         await _categoryPictureMappingDS.AddAsync(categoryPictureMapping, token);

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = category.Id;
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
            // Get existing Category.
            Category entity = await _categoryRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                //entity = CategoryDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _categoryRepository.UpdateAsync(entity, entity.Id, token);
            }
            _unitOfWork.SaveAll();
           
            return commonRonsponseDTO;
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
