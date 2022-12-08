﻿using Fintech.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUser request)
        {
            var response = await _authService.CreateUserAsync(new User
            {
                Email = request.Email
            },
            request.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(Login request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

    }
}
