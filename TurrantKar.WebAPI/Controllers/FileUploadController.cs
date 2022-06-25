using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DS;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        #region Local Member
        IPictureDS _pictureDS;
        #endregion

        #region Contructor
        public FileUploadController(IPictureDS pictureDS)
        {
            _pictureDS = pictureDS;
        }
        #endregion

        [HttpPost("postfile")]
        public IActionResult Post([FromBody] FileUploadDTO theFile, CancellationToken token = default(CancellationToken))
        {

             _pictureDS.AddPictureAsync(theFile, token);
            return Ok();
        }
    }
}
