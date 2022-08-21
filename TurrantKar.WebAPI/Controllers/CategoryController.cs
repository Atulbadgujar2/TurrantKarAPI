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

        #region Get
        [HttpGet]
        [Route("list")]
        public async Task<List<CategoryViewDTO>> GetCategoryList(bool showHomePage = false, bool includeTopMenu = false, CancellationToken token = default(CancellationToken))
        {
            return await _categoryDS.GetCategoryList(showHomePage, includeTopMenu, token);
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<CategoryViewDTO> GetCategoryDetailById([FromRoute] int id, CancellationToken token = default(CancellationToken))
        {
            return await _categoryDS.GetCategoryDetailById(id, token);
        }

        #endregion
        #region Add
        [HttpPost]
        [Route("add")]
        public async Task<ResponseModelDTO> AddCategoryAsync(CategoryDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModelDTO = await _categoryDS.AddCategoryAsync(model);
            return responseModelDTO;
        }

        #endregion


        #region Update

        /// <summary>
        /// Update the holdiays
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<ResponseModelDTO> UpdateCategoryAsync([FromBody] CategoryDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModelDTO = await _categoryDS.UpdateCategoryAsync(model);
            return responseModelDTO;
        }


        #endregion Update

        #region Delete method

        /// <summary>
        /// delete Category
        /// </summary>
        /// <param name="model"></param       
        /// <returns></returns>
        [HttpPut]
        [Route("delete")]
        public async Task<ResponseModelDTO> DeleteCategoryAsync([FromBody] IdentificationDTO model, CancellationToken token = default(CancellationToken))
        {
            return await _categoryDS.DeleteCategoryAsync(model);
        }

        #endregion Delete method
    }
}
