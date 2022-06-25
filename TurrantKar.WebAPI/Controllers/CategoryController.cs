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
    public class CategoryController : ControllerBase
    {
        #region Local Member
        ICategoryDS _categoryDS;
        #endregion

        #region Contructor
        public CategoryController(ICategoryDS categoryDS)
        {
            _categoryDS = categoryDS;
        }
        #endregion

        #region Add
        [HttpPost]
        [Route("add")]
        public async Task<int> AddCategoryAsync(CategoryDTO model, CancellationToken token = default(CancellationToken))
        {

            int responseId = 0;
            var file = Request.Form.Files[0];
            ResponseModelDTO responseModelDTO = await _categoryDS.AddCategoryAsync(model);
            responseId = responseModelDTO.Id;


            return responseId;

        }

        //[HttpPost("PostFile/{Id}")]
        //public ActionResult PostFile(IFormFile uploadedFile)
        //{
        //    try {
        //        var saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Attachment");
        //        string FileExtn = Path.GetExtension(uploadedFile.FileName);
        //        string uniqueFileName = Guid.NewGuid().ToString() + FileExtn;
        //        string filePath = Path.Combine(saveFilePath, uniqueFileName);
               
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //             uploadedFile.CopyTo(stream);
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //    return Ok();
        //}
        #endregion
    }
}
