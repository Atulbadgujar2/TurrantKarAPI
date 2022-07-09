using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DS;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        #region Local Member
        IShoppingCartDS _shoppingCartDS;
        #endregion

        #region Contructor
        public ShoppingCartController(IShoppingCartDS shoppingCartDS)
        {
            _shoppingCartDS = shoppingCartDS;
        }
        #endregion

        #region Add
        [HttpPost]
        [Route("add")]
        public async Task<int> AddShopingCartAsync(ShoppingCartDTO model, CancellationToken token = default(CancellationToken))
        {

            int responseId = 0;
            //var file = Request.Form.Files[0];
            ResponseModelDTO responseModelDTO = await _shoppingCartDS.AddShoppingCartAsync(model,token);
            responseId = responseModelDTO.Id;
            return responseId;
        }
        #endregion
    }
}
