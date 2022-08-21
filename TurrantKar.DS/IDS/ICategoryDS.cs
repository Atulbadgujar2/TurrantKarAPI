using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Category
    /// </summary>
    public interface ICategoryDS : IBaseDS<Category>
    {

        Task<List<CategoryViewDTO>> GetCategoryList(bool showHomePage, bool includeTopMenu, CancellationToken token = default(CancellationToken));

        Task<CategoryViewDTO> GetCategoryDetailById(int categoryId, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> AddCategoryAsync(CategoryDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateCategoryAsync(CategoryDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteCategoryAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}

