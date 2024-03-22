using Application.InterfaceService;
using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    public class WebAccountController : MainController
    {
        private readonly IAccountService _accountService;
        public WebAccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginForm loginForm)
        {
            Token newToken = await _accountService.LoginAsync(loginForm);
            if (newToken != null)
            {
                return Ok(newToken);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterForm registerForm)
        {
            bool isSuccess = await _accountService.RegisterAsync(registerForm);
            if (isSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var accessToken = await _accountService.RefreshAccessTokenAsync(refreshToken);
            if (accessToken != null)
            {
                return Ok(accessToken);
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<Respone> GetCurrentLoginUser()
        {
            var respone = await _accountService.GetCurrentLoginUser();
            return respone;
        }
    }
}

