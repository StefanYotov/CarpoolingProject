using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Services.ServiceImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolingProject.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateAddressAsync([FromBody] CreateAddressRequestModel requestModel)
        {
            var response = await addressService.CreateAddressAsync(requestModel);
            return this.Ok(response);
        }
        [HttpDelete("")]
        public async Task<IActionResult> DeleteAddressAsync([FromBody] DeleteAddressRequestModel requestModel)
        {
            var response = await addressService.DeleteAddressAsync(requestModel);
            if (response.IsSuccess)
            {
                return this.Ok(response);
            }
            return BadRequest(response);
        }
    }
}
