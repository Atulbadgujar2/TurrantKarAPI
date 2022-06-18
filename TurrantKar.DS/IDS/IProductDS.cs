using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Product
    /// </summary>
    public interface IProductDS : IBaseDS<Product>
    {
        Task<ResponseModelDTO> AddProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteProductAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}
