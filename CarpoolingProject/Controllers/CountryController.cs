using CarpoolingProject.Models.RequestModels;
using CarpoolingProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolingProject.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService service)
        {
            this.countryService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromBody] CreateCountryRequestModel requestModel)
        {
            var response = await countryService.CreateCountryAsync(requestModel);
            return Json(response);
        }
    }
}