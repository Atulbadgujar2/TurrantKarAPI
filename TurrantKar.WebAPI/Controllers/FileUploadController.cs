using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
         string FILE_PATH = Path.Combine(Directory.GetCurrentDirectory(), "Attachment");

        [HttpPost("postfile")]
        public IActionResult Post([FromBody] FileUploadDTO theFile)
        {
            var filePathName = FILE_PATH + Path.GetFileNameWithoutExtension(theFile.FileName) + "-" +
    DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") +
    Path.GetExtension(theFile.FileName);

            if (theFile.FileAsBase64.Contains(","))
            {
                theFile.FileAsBase64 = theFile.FileAsBase64.Substring(theFile.FileAsBase64.IndexOf(",") + 1);
            }

            theFile.FileAsByteArray = Convert.FromBase64String(theFile.FileAsBase64);

            using (var fs = new FileStream(filePathName, FileMode.CreateNew))
            {
                fs.Write(theFile.FileAsByteArray, 0, theFile.FileAsByteArray.Length);
            }
            return Ok();
        }
    }
}
