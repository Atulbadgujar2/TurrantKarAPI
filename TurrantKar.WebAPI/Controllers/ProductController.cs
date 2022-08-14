using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DS;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        #region Local Member
        IProductDS _productDS;
        #endregion

        #region Contructor
        public ProductController(IProductDS productDS)
        {
            _productDS = productDS;
        }
        #endregion

        #region Get
        [HttpGet]
        [Route("list")]
        public async Task<List<ProductViewDTO>> GetProductList(CancellationToken token = default(CancellationToken))
        {
            return await _productDS.GetProductList(token);
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<ProductViewDTO> GetProductDetailById([FromRoute] int id, CancellationToken token = default(CancellationToken))
        {
            return await _productDS.GetProductDetailById(id, token);
        }

        #endregion

        #region Add
        [HttpPost]
        [Route("add")]
        public async Task<Guid> AddProductAsync(ProductDTO model, CancellationToken token = default(CancellationToken))
        {

            Guid responseId;
            //var file = Request.Form.Files[0];
            ResponseModelDTO responseModelDTO = await _productDS.AddProductAsync(model);
            responseId = responseModelDTO.GuidId;
            return responseId;
        }
        #endregion

        #region Update

        /// <summary>
        /// Update the Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<ResponseModelDTO> UpdateProductAsync([FromBody] ProductDTO model, CancellationToken token = default(CancellationToken))
        {
            ResponseModelDTO responseModelDTO = await _productDS.UpdateProductAsync(model);
            return responseModelDTO;
        }


        #endregion Update

        #region Delete method

        /// <summary>
        /// delete Address
        /// </summary>
        /// <param name="model"></param       
        /// <returns></returns>
        [HttpPut]
        [Route("delete")]
        public async Task<ResponseModelDTO> DeleteAddressAsync([FromBody] IdentificationDTO model, CancellationToken token = default(CancellationToken))
        {
            return await _productDS.DeleteProductAsync(model);
        }

        #endregion Delete method
    }
}
