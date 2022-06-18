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
    /// This class Contain Business Logic of Picture
    /// </summary>
    public class PictureDS : BaseDS<Picture>, IPictureDS
    {
        #region Local Member
        IPictureRepository _pictureRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PictureDS(IPictureRepository pictureRepository, IUnitOfWork unitOfWork) : base(pictureRepository)
        {
            _pictureRepository = pictureRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 

        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddPictureAsync(PictureDTO model, CancellationToken token = default(CancellationToken))
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

                        Picture entity = new Picture();
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Picture Picture = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = Picture.Id;
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
        public async Task<ResponseModelDTO> UpdatePictureAsync(PictureDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            // Get existing Picture.
            Picture entity = await _pictureRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                //entity = PictureDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _pictureRepository.UpdateAsync(entity, entity.Id, token);
            }
            _unitOfWork.SaveAll();
            return commonRonsponseDTO;
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeletePictureAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            Picture entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _pictureRepository.UpdateAsync(entity, entity.Id, token);
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