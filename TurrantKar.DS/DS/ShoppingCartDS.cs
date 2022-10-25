using System;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Common;
using TurrantKar.DTO;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ShoppingCart
    /// </summary>
    public class ShoppingCartDS : BaseDS<ShoppingCart>, IShoppingCartDS
    {
        #region Local Member
        IShoppingCartRepository _shoppingCartRepository;
        IUnitOfWork _unitOfWork;
        IShoppingCartItemDS _shoppingCartItemDS;
        #endregion

        #region Constructor
        public ShoppingCartDS(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork, IShoppingCartItemDS shoppingCartItemDS) : base(shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
            _shoppingCartItemDS = shoppingCartItemDS;
        }
        #endregion

        #region Get 

        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddShoppingCartAsync(ShoppingCartDTO model, CancellationToken token = default(CancellationToken))
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

                        ShoppingCart entity = new ShoppingCart();
                        //Category entity = CategoryDTO.MapToEntity(model);
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        ShoppingCart ShoppingCart = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();
                        ShoppingCartItem shoppingCartItem;
                        foreach (ShoppingCartItemDTO shoppingCartItemDTO in model.shopCartItemList ) {
                            shoppingCartItem = new ShoppingCartItem();
                            shoppingCartItem.ShoppingCartId = ShoppingCart.Id;
                            shoppingCartItem = ShoppingCartItemDTO.MapToEntity(shoppingCartItemDTO);
                            _shoppingCartItemDS.UpdateSystemFieldsByOpType(shoppingCartItem, OperationType.Add);
                            await _shoppingCartItemDS.AddAsync(shoppingCartItem, token);
                        }  
                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = ShoppingCart.Id;
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
        public async Task<ResponseModelDTO> UpdateShoppingCartAsync(ShoppingCartDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            // Get existing ShoppingCart.
            ShoppingCart entity = await _shoppingCartRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                entity = ShoppingCartDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _shoppingCartRepository.UpdateAsync(entity, entity.Id, token);

                foreach (ShoppingCartItemDTO shoppingCartItemDTO in model.shopCartItemList)
                {
                    // Get existing ShoppingCartItem.
                    ShoppingCartItem shoppingCartItem = await _shoppingCartItemDS.GetAsync(shoppingCartItemDTO.Id, token);
                    if (entity != null & !entity.IsDeleted)
                    {
                        shoppingCartItem = ShoppingCartItemDTO.MapToEntityWithEntity(shoppingCartItemDTO, shoppingCartItem);
                        _shoppingCartItemDS.UpdateSystemFieldsByOpType(shoppingCartItem, OperationType.Update);
                        await _shoppingCartItemDS.UpdateAsync(shoppingCartItem, entity.Id, token);
                    }
                    else
                    {
                        shoppingCartItem.ShoppingCartId = entity.Id;
                        shoppingCartItem = ShoppingCartItemDTO.MapToEntity(shoppingCartItemDTO);
                        _shoppingCartItemDS.UpdateSystemFieldsByOpType(shoppingCartItem, OperationType.Add);
                        await _shoppingCartItemDS.AddAsync(shoppingCartItem, token);
                    }
                }
                
            }
            _unitOfWork.SaveAll();
            return commonRonsponseDTO;
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeleteShoppingCartAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            ShoppingCart entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _shoppingCartRepository.UpdateAsync(entity, entity.Id, token);
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

