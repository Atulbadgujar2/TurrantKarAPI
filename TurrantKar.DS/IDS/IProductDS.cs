using System.Collections.Generic;
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
        Task<List<ProductViewDTO>> GetProductList(bool showHomePage, int categoryId, CancellationToken token = default(CancellationToken));

        Task<ProductViewDTO> GetProductDetailById(int productId, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> AddProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteProductAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}
