using System;
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
    /// This class Contain Business Logic of Order
    /// </summary>
    public class OrderDS : BaseDS<Order>, IOrderDS
    {
        #region Local Member
        IOrderRepository _orderRepository;
        IUnitOfWork _unitOfWork;
        IOrderItemDS _orderItemDS;
        #endregion

        #region Constructor
        public OrderDS(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderItemDS orderItemDS) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _orderItemDS = orderItemDS;
        }
        #endregion

        #region Get 

        #endregion

        #region Add 
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> AddOrderAsync(OrderDTO model, CancellationToken token = default(CancellationToken))
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

                        Order entity = new Order();
                        UpdateSystemFieldsByOpType(entity, OperationType.Add);
                        Order Order = await AddAsync(entity, token);
                        await _unitOfWork.SaveAsync();

                        OrderItem OrderItem;
                        foreach (OrderItemDTO orderItemDTO in model.orderItemDTOList)
                        {
                            OrderItem = new OrderItem();
                            OrderItem.OrderId = entity.Id;
                            OrderItem = OrderItemDTO.MapToEntity(orderItemDTO);
                            _orderItemDS.UpdateSystemFieldsByOpType(OrderItem, OperationType.Add);
                            await _orderItemDS.AddAsync(OrderItem, token);
                        }
                        _unitOfWork.SaveAll();
                        transaction.Commit();
                        commonRonsponseDTO.Id = Order.Id;
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
        public async Task<ResponseModelDTO> UpdateOrderAsync(OrderDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO commonRonsponseDTO = new ResponseModelDTO();
            // Get existing Order.
            Order entity = await _orderRepository.GetAsync(model.Id, token);
            if (entity != null & !entity.IsDeleted)
            {
                //entity = OrderDTO.MapToEntityWithEntity(model, entity);
                UpdateSystemFieldsByOpType(entity, OperationType.Update);
                await _orderRepository.UpdateAsync(entity, entity.Id, token);

                foreach(OrderItemDTO orderItemDTO in model.orderItemDTOList)
                {
                    // Get existing OrderItem.
                    OrderItem orderItem = await _orderItemDS.GetAsync(orderItemDTO.Id, token);
                    if (entity != null & !entity.IsDeleted)
                    {
                        orderItem = OrderItemDTO.MapToEntityWithEntity(orderItemDTO, orderItem);
                        _orderItemDS.UpdateSystemFieldsByOpType(orderItem, OperationType.Update);
                        await _orderItemDS.UpdateAsync(orderItem, entity.Id, token);
                    }
                    else
                    {
                        orderItem.OrderId = entity.Id;
                        orderItem = OrderItemDTO.MapToEntity(orderItemDTO);
                        _orderItemDS.UpdateSystemFieldsByOpType(orderItem, OperationType.Add);
                        await _orderItemDS.AddAsync(orderItem, token);
                    }
                }
            }
            _unitOfWork.SaveAll();
            return commonRonsponseDTO;
        }
        #endregion



        #region Delete
        /// <inheritdoc /> 
        public async Task<ResponseModelDTO> DeleteOrderAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModel = new ResponseModelDTO();
            // Get entity if exists
            Order entity = await FindAsync(v => v.Id == identificationDTO.UNIQUE_ID && v.IsDeleted == false, token);

            if (entity != null)
            {
                responseModel.IsSuccess = true;
                UpdateSystemFieldsByOpType(entity, OperationType.Delete);
                await _orderRepository.UpdateAsync(entity, entity.Id, token);
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

