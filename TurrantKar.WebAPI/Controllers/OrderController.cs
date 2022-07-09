using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DS;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        #region Local Member
        IOrderDS _orderDS;
        #endregion

        #region Contructor
        public OrderController(IOrderDS orderDS)
        {
            _orderDS = orderDS;
        }
        #endregion

        #region Add
        [HttpPost]
        [Route("add")]
        public async Task<int> AddOrderAsync(OrderDTO model, CancellationToken token = default(CancellationToken))
        {

            int responseId = 0;
            //var file = Request.Form.Files[0];
            ResponseModelDTO responseModelDTO = await _orderDS.AddOrderAsync(model);
            responseId = responseModelDTO.Id;
            return responseId;
        }
        #endregion

    }
}
