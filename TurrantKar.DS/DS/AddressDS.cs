using System;
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
        ICustomerAddressesDS _customerAddressesDS;
        #endregion

        #region Constructor
        public AddressDS(IAddressRepository addressRepository, ICustomerAddressesDS customerAddressesDS,IUnitOfWork unitOfWork) : base(addressRepository)
        {
            _addressRepository = addressRepository;
            _customerAddressesDS = customerAddressesDS;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 
        public async Task<List<AddressDTO>> GetAddressListByCustomerId(int customerId, CancellationToken token = default(CancellationToken))
        {
            return await _addressRepository.GetAddressListByCustomerId(customerId, token);
        }
      
        /// <inheritdoc />  
        public async Task<AddressDTO> GetAddressDetailById(int AddressId, CancellationToken token = default(CancellationToken))
        {
            return await _addressRepository.GetAddressDetailById(AddressId, token);
        }
        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken))
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

                        Address entity = AddressDTO.MapToEntity(model);
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Address address = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();
                        if (model.CustomerId != null)
                        {
                            // Add and Update EmployeeTaskRate Data
                            CustomerAddresses customerAddresses = new CustomerAddresses();
                            customerAddresses.AddressId = address.Id;
                            customerAddresses.CustomerId = model.CustomerId;
                            _customerAddressesDS.UpdateSystemFieldsByOpType(customerAddresses, OperationType.Add);
                            await _customerAddressesDS.AddAsync(customerAddresses, token);
                            _unitOfWork.SaveAll();
                        }
                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = address.Id;
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
