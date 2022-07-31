using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{

    /// <summary>
    /// This is the repository responsible for filtering data realted to Product and services related to it
    /// </summary>
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<ProductViewDTO>> GetProductList(CancellationToken token = default(CancellationToken));

        Task<ProductViewDTO> GetProductDetailById(int productId, CancellationToken token = default(CancellationToken));
    }
}

