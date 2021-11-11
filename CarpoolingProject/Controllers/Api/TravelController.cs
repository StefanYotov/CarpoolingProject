using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Services.Interfaces;
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
    public class TravelController : ControllerBase
    {
        private readonly ITravelService travelService;

        public TravelController(ITravelService travelService)
        {
            this.travelService = travelService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var travels = await travelService.GetAllTravelsAsync();
            return Ok(travels);
        }
        [HttpPut("")]
        public async Task<IActionResult> Create([FromBody] CreateTravelRequestModel requestModel)
        {
            var responce = await travelService.CreateTravelAsync(requestModel);
            return this.Ok(responce);
        }
    }
}
