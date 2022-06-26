using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
