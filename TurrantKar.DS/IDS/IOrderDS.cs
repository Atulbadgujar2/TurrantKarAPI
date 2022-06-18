using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Order
    /// </summary>
    public interface IOrderDS : IBaseDS<Order>
    {
        Task<ResponseModelDTO> AddOrderAsync(OrderDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateOrderAsync(OrderDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteOrderAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}
