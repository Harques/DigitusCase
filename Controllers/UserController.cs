﻿using DigitusCase.Dtos.User;
using DigitusCase.Interfaces;
using DigitusCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitusCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IStringLocalizer<Messages> _localizer;

        public UserController(IUserService userService, IStringLocalizer<Messages> localizer)
        {
            _userService = userService;
            _localizer = localizer;
        }

        // POST api/<user>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto request)
        {
            var userResult = await _userService.RegisterAsync(request);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            return !await _userService.ValidateUserAsync(request)
                ? Unauthorized(_localizer["UnauthorizedMessage"].Value)
                : Ok(new { Token = await _userService.CreateTokenAsync() });
        }

    }
}
