using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DS;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        #region Local Member
        IAddressDS _addressDS;
        #endregion

        #region Contructor
        public AddressController(IAddressDS addressDS)
        {
            _addressDS = addressDS;
        }
        #endregion

        #region Get
        //[HttpGet]
        //[Route("list")]
        //public async Task<List<AddressDTO>> GetEmployeeByEmployeeID(string year = "0000", CancellationToken token = default(CancellationToken))
        //{
        //    return await _addressDS.GetAddressListByOptionParam(year, token);
        //}

        //[HttpGet]
        //[Route("details/{id}")]
        //public async Task<AddressDTO> GetAddressDetailById([FromRoute] int id, CancellationToken token = default(CancellationToken))
        //{
        //    return await _addressDS.GetAddressDetailById(id, token);
        //}

        #endregion


        #region Add
        [HttpPost]
        [Route("add")]
        public async Task<int> AddAddressAsync([FromBody] AddressDTO model, CancellationToken token = default(CancellationToken))
        {

            int responseId;
            ResponseModelDTO responseModelDTO = await _addressDS.AddAddressAsync(model);
            responseId = responseModelDTO.Id;
            return responseId;
           
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
        public async Task<ResponseModelDTO> UpdateAddressAsync([FromBody] AddressDTO model, CancellationToken token = default(CancellationToken))
        {
            await _addressDS.UpdateAddressAsync(model);
            return new ResponseModelDTO()
            {
                Id = 1,
                IsSuccess = true,
                //Message = TKConstant.AddressUpdatedSuccessfull
            };
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
            return await _addressDS.DeleteAddressAsync(model);
        }

        #endregion Delete method
    }
}
