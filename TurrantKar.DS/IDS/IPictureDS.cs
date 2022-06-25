using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Picture
    /// </summary>
    public interface IPictureDS : IBaseDS<Picture>
    {
        Task<ResponseModelDTO> AddPictureAsync(FileUploadDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdatePictureAsync(PictureDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeletePictureAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}

