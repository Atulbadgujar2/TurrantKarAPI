using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ShoppingCart
    /// </summary>
    public interface IShoppingCartDS : IBaseDS<ShoppingCart>
    {
        Task<ResponseModelDTO> AddShoppingCartAsync(ShoppingCartDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateShoppingCartAsync(ShoppingCartDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteShoppingCartAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}
