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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestModel requestModel)
        {
            var responce = await userService.CreateUserAsync(requestModel);
            return this.Ok(responce);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequestModel requestModel)
        {
            var responce = await userService.DeleteUserAsync(requestModel);
            if (responce.IsSuccess)
            {
                return this.Ok(responce.Message);
            }
            return BadRequest(responce.Message);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequestModel requestModel)
        {
            var response = await userService.UpdateUserAsync(requestModel);
            return this.Ok(response);
        }
    }
}
