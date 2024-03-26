using Application.InterfaceService;
using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModel.ResponeModel;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Application.ViewModel.ResetPasswordModel;
using Application.Services;
using Application.ViewModel.CourseModel;
using Application.ViewModel.AccountModel;
using Application.ViewModel.UpdatePasswordModel;

namespace MonochordCapstoneProjectAPI.Controllers
{
   
    public class AccountController :MainController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Login with email and password
        /// </summary>
        /// <param name="loginForm">Login object for user to login to the app</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Login by email and password",typeof(Token))]
        [HttpPost]
        public async Task<IActionResult> Login(LoginForm loginForm)
        {
           Token newToken= await _accountService.LoginAsync(loginForm);
            if (newToken != null)
            {
                return Ok(newToken);
            }
           return BadRequest();
        }
        /// <summary>
        /// Register with username,email and password
        /// </summary>
        /// <param name="registerForm">Register form for create new account</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterForm registerForm)
        {
            bool isSuccess= await _accountService.RegisterAsync(registerForm);
            if (isSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        /// Controller to get new extend login session
        /// </summary>
        /// <param name="refreshToken">the Refresh Token to get new access token</param>
        /// <returns>Access token</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var accessToken= await _accountService.RefreshAccessTokenAsync(refreshToken);
            if (accessToken != null)
            {
                return Ok(accessToken);
            }
            return BadRequest();
        }
        /// <summary>
        /// Send code to user email for password reset
        /// </summary>
        /// <param name="email">The email of user</param>
        /// <returns>Respone</returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Send success",typeof(Respone))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Cannot send mail", typeof(Respone))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Mail do not existed", typeof(Respone))]
        [HttpGet("{email}")]
        public async Task<Respone> ForgotPassword([FromRoute]string email)
        {
            var response= await _accountService.SendConfirmMailCode(email);
            return response;
        }
        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="resetPasswordDTO">Reset Password Form</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Send success", typeof(Respone))]
        [HttpPost]
        public async Task<Respone> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var respone=await _accountService.ResetPassword(resetPasswordDTO);
            return respone;
        }
        /// <summary>
        /// Get all course
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get All Account", typeof(Respone))]
        [Authorize]
        [HttpGet]
        public async Task<Respone> GetAllAccount()
        {
            var respone = await _accountService.GetAllAccount();
            return respone;
        }
        [Authorize]
        [HttpGet]
        public async Task<Respone> GetCurrentLoginUser()
        {
            var respone= await _accountService.GetCurrentLoginUser();
            return respone;
        }
        /// <summary>
        /// Login with google
        /// </summary>
        /// <param name="google_access_token">access token return by google api</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Login by access_token", typeof(Token))]
        [HttpPost]
        public async Task<IActionResult> LoginWithGoogle(string token)
        {
            Token newToken = await _accountService.LoginGoogle(token);
            if (newToken != null)
            {
                return Ok(newToken);
            }
            return BadRequest();
        }
        [SwaggerResponse((int)HttpStatusCode.OK, "Update account", typeof(Respone))]
        [HttpPut("{id}")]
        public async Task<Respone> UpdateAccount(Guid id, AccountViewModel model)
        {
            var respone = await _accountService.UpdateAccount(id, model);
            return respone;
        }
        [SwaggerResponse((int)HttpStatusCode.OK, "Update password success", typeof(Respone))]
        [HttpPost]
        public async Task<Respone> UpdateAccountPassword(Guid id, UpdatePasswordDTO updatePasswordDTO)
        {
            var respone = await _accountService.UpdatePassword(id, updatePasswordDTO);
            return respone;
        }
    }
}
