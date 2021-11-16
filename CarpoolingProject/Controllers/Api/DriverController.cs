using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Services.Interfaces;
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
    public class DriverController : Controller
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTravels()
        {
            var result = await driverService.GetAllDriversAsync();
            if (result.Count() < 1)
            {
                return this.NoContent();
            }
            return this.Ok(result);
        }
        [HttpPut("departure")]
        public async Task<IActionResult> UpdateDepartureTime([FromBody] UpdateTimeOfDepartureRequestModel requestModel)
        {
            var result = await driverService.UpdateTimeOfDepartureAsync(requestModel);
            return this.Ok(result);
        }
        [HttpPost("select")]
        public async Task<IActionResult> SelectUser([FromBody] SelectPassengerRequestModel requestModel)
        {
            var result = await driverService.SelectUser(requestModel);
            return this.Ok(result);
        }
    }
}
