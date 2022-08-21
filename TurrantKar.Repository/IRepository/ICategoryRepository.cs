using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{

    /// <summary>
    /// This is the repository responsible for filtering data realted to Category and services related to it
    /// </summary>
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<CategoryViewDTO>> GetCategoryList(bool showHomePage, bool includeTopMenu, CancellationToken token = default(CancellationToken));

        Task<CategoryViewDTO> GetCategoryDetailById(int categoryId, CancellationToken token = default(CancellationToken));
    }
}


