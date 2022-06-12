using System.Collections.Generic;
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
    /// This class Contain Business Logic of AddressDS
    /// </summary>
    public class AddressDS : BaseDS<Address>, IAddressDS
    {
        #region Local Member
        IAddressRepository _addressRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public AddressDS(IAddressRepository addressRepository, IUnitOfWork unitOfWork) : base(addressRepository)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 
        public async Task<ICollection<Address>> GetAddressByCustomerId(int customer, CancellationToken token = default(CancellationToken))
        {
            return await FindAllAsync(i => i.IsDeleted == false, token);
        }
        ///// <inheritdoc />  
        //public async Task<List<AddressDTO>> GetAddressListByOptionParam(string year, CancellationToken token = default(CancellationToken))
        //{
        //    return await _AddressRepository.GetAddressListByOptionParam(year, token);
        //}

        ///// <inheritdoc />  
        //public async Task<AddressDTO> GetAddressDetailById(int AddressId, CancellationToken token = default(CancellationToken))
        //{
        //    return await _AddressRepository.GetAddressDetailById(AddressId, token);
        //}
        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            Address entity = AddressDTO.MapToEntity(model);
            UpdateSystemFieldsByOpType(entity, OperationType.Add);
            Address address = await _addressRepository.AddAsync(entity, token);
            _unitOfWork.SaveAll();
            commonRonsponseDTO.Id = address.Id;
            return commonRonsponseDTO;
        }
        #endregion

        #region Update
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> UpdateAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            // Get existing Address.
            Address entity = await _addressRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                entity = AddressDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _addressRepository.UpdateAsync(entity, entity.Id, token);
            }
            _unitOfWork.SaveAll();
            return commonRonsponseDTO;
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeleteAddressAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            Address entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);
            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _addressRepository.UpdateAsync(entity, entity.Id, token);
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
