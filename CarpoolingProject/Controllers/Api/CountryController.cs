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
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService service)
        {
            this.countryService = service;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateCountryRequestModel requestModel)
        {
            var response = await countryService.CreateCountryAsync(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCountryRequestModel requestModel)
        {
            var response = await countryService.DeleteCountryAsync(requestModel);
            return Ok(response);
        }
        [HttpPost("add/city")]
        public async Task<IActionResult> AddCityToCountry([FromBody] AddCitiesToCountryRequestModel requestModel)
        {
            var result = await countryService.AddCitiesToCountryAsync(requestModel);
            return this.Ok(result);
        }
        [HttpGet("cities")]
        public async Task<IActionResult> ListCities([FromBody] ShowCitiesRequestModel requestModel)
        {
            var result = await countryService.ShowCities(requestModel);
            if (result.Count() < 1)
            {
                return this.NoContent();
            }
            return this.Ok(result);
        }
    }
}