using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ReturnRequest
    /// </summary>
    public interface IReturnRequestDS : IBaseDS<ReturnRequest>
    {

        Task<ResponseModelDTO> AddReturnRequestAsync(ReturnRequestDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateReturnRequestAsync(ReturnRequestDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteReturnRequestAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}
