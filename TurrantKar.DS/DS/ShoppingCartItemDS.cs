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
    /// This class Contain Business Logic of ShoppingCartItem
    /// </summary>
    public class ShoppingCartItemDS : BaseDS<ShoppingCartItem>, IShoppingCartItemDS
    {
        #region Local Member
        IShoppingCartItemRepository _shoppingCartItemRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ShoppingCartItemDS(IShoppingCartItemRepository shoppingCartItemRepository, IUnitOfWork unitOfWork) : base(shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get 

        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddShoppingCartItemAsync(ShoppingCartItemDTO model, CancellationToken token = default(CancellationToken))
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

                        ShoppingCartItem entity = new ShoppingCartItem();
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        ShoppingCartItem ShoppingCartItem = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = ShoppingCartItem.Id;
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
        public async Task<ResponseModelDTO> UpdateShoppingCartItemAsync(ShoppingCartItemDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            // Get existing ShoppingCartItem.
            ShoppingCartItem entity = await _shoppingCartItemRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                //entity = ShoppingCartItemDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _shoppingCartItemRepository.UpdateAsync(entity, entity.Id, token);
            }
            _unitOfWork.SaveAll();
            return commonRonsponseDTO;
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeleteShoppingCartItemAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            ShoppingCartItem entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _shoppingCartItemRepository.UpdateAsync(entity, entity.Id, token);
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

