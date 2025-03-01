using AutoMapper;
using MicroEngine.Data.Entities;
using MicroEngine.Framework.Commons;
using MicroEngine.Framework.Entity;
using MicroEngine.Framework.Repository;
using MicroEngine.Framework.Services.Interface;
using MicroEngine.Models.RequestModels;
using MicroEngine.Models.ResponseModels;
using MicroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroEngine.Controllers
{
    public class TokenController : BaseController
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserAccountService _userAccountService;

        public TokenController(
            IJwtTokenService jwtTokenService,
            IUserAccountService userAccountService
        )
        {
            _jwtTokenService = jwtTokenService;
            _userAccountService = userAccountService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginModel model)
        {
            var user = await _userAccountService.GetUserLogin(model.LoginName, model.Password);
            if (user == null)
            {
                return Ok(
                    new ApiResponse { Success = false, Message = "Invalid LoginName/Password" }
                );
            }
            return Ok(
                new ApiResponse
                {
                    Success = true,
                    Message = "Authenticate Successfully",
                    Data = _jwtTokenService.GetNewJwtToken(user),
                }
            );
        }
    }
}
