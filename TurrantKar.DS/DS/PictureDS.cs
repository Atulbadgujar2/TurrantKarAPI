using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
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
        IPictureBinaryDS _pictureBinaryDS;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PictureDS(IPictureRepository pictureRepository,IPictureBinaryDS pictureBinaryDS, IUnitOfWork unitOfWork) : base(pictureRepository)
        {
            _pictureRepository = pictureRepository;
            _pictureBinaryDS = pictureBinaryDS;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 

        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddPictureAsync(FileUploadDTO theFile, CancellationToken token = default(CancellationToken))
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
                        string FILE_PATH = Path.Combine(Directory.GetCurrentDirectory(), "Attachment", theFile.PictureGuidId + Path.GetExtension(theFile.FileName));
                        var filePathName = FILE_PATH;
                        theFile.VirtualPath = filePathName;
                        if (theFile.FileAsBase64.Contains(","))
                        {
                            theFile.FileAsBase64 = theFile.FileAsBase64.Substring(theFile.FileAsBase64.IndexOf(",") + 1);
                        }

                        theFile.FileAsByteArray = Convert.FromBase64String(theFile.FileAsBase64);

                        using (var fs = new FileStream(filePathName, FileMode.CreateNew))
                        {
                            fs.Write(theFile.FileAsByteArray, 0, theFile.FileAsByteArray.Length);
                        }

                        Picture entity = PictureDTO.MapToEntity(theFile);
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Picture pictureEntity = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();


                        PictureBinary pictureBinary = new PictureBinary();
                        pictureBinary.PictureId = pictureEntity.Id;
                        pictureBinary.BinaryData = theFile.FileAsByteArray;
                        _pictureBinaryDS.UpdateSystemFieldsByOpType(pictureBinary, OperationType.Add);
                        await _pictureBinaryDS.AddAsync(pictureBinary, token);

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = pictureEntity.Id;
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