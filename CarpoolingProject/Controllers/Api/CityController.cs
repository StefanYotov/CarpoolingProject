using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolingProject.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService service)
        {
            this.cityService = service;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateCityRequestModel requestModel)
        {
            var response = await cityService.CreateCityAsync(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCityRequestModel requestModel)
        {
            var response = await cityService.DeleteCityAsync(requestModel);
            return Ok(response);
        }
    }
}
