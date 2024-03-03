using Application.InterfaceService;
using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MonochordCapstoneProjectAPI.Controllers
{
   
    public class AccountController :MainController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginForm loginForm)
        {
           Token newToken= await _accountService.LoginAsync(loginForm);
            if (newToken != null)
            {
                return Ok(newToken);
            }
            return BadRequest();
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterForm registerForm)
        {
            bool isSuccess= await _accountService.RegisterAsync(registerForm);
            if (isSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet("/refreshLogin")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var accessToken= await _accountService.RefreshAccessTokenAsync(refreshToken);
            if (accessToken != null)
            {
                return Ok(accessToken);
            }
            return BadRequest();
        }
    }
}
