﻿using CarpoolingProject.Models.RequestModels;
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
    public class TravelController : Controller
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
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateTravelRequestModel requestModel)
        {
            var responce = await travelService.CreateTravelAsync(requestModel);
            return this.Ok(responce);
        }
        [HttpDelete("")]
        public async Task<IActionResult> Delete([FromBody] DeleteTravelRequestModel requestModel)
        {
            var responce = await travelService.DeleteTravelAsync(requestModel);
            if (responce.IsSuccess)
            {
                return this.Ok(responce.Message);
            }
            return BadRequest(responce.Message);
        }
        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] UpdateTravelRequestModel requestModel)
        {
            var response = await travelService.UpdateTravelAsync(requestModel);
            return this.Ok(response);
        }
        [HttpPut("status")]
        public async Task<IActionResult> TravelStatus([FromBody] FinishedTravelRequestModel requestModel)
        {
            var result = await travelService.FinishedTravel(requestModel);
            return this.Ok(result);
        }
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForTravel([FromBody] ApplyForTravelRequestModel requestModel)
        {
            var result = await travelService.ApplyForTravel(requestModel);
            return this.Ok(result);
        }
        [HttpGet("applicants")]
        public async Task<IActionResult> ListApplicantsForTravel([FromBody] GetTravelRequestModel requestModel)
        {
            var result = await travelService.ListApplicantsForTravel(requestModel);
            return this.Ok(result);
        }
    }
}
