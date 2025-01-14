using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Application.Interfaces;
using Clean.Application.Services;
using Clean.Contracts.RequestModel;
using Clean.Contracts.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Presentation.Controllers
{
    [ApiController]
    [Route("/api/auth/")]
    public class AuthControllers : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly ITokenServices _tokenServices;

        public AuthControllers(IAuthRepository authRepo, ITokenServices tokenServices)
        {
            _authRepo = authRepo;
            _tokenServices = tokenServices;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginModel)
        {
            LoginResponseDto loginResponse = await _authRepo.Login(loginModel);
            if (!loginResponse.Succeded) return BadRequest("Wrong Username or Password");
            string accessToken = _tokenServices.PopulateAccessToken(loginResponse);
            string refreshToken = _tokenServices.PopulateRefreshToken(loginResponse);
            HttpContext.Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = false,  //For dev purposes
                Expires = DateTime.Now.AddDays(7)
            });
            return Ok(new { AccessToken = accessToken });
        }
    }
}