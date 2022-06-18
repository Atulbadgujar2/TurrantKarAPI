using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ShoppingCartItem
    /// </summary>
    public interface IShoppingCartItemDS : IBaseDS<ShoppingCartItem>
    {
        Task<ResponseModelDTO> AddShoppingCartItemAsync(ShoppingCartItemDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateShoppingCartItemAsync(ShoppingCartItemDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteShoppingCartItemAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}
