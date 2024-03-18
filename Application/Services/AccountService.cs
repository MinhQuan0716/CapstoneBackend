using Application.Common;
using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.Util;
using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using Application.ViewModel.ResetPasswordModel;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IClaimService _claimService;
        private ISendMailHelper _sendMailHelper;
        public AccountService(IUnitOfWork unitOfWork,AppConfiguration configuration
            ,IMapper mapper,ICacheService cacheService,IClaimService claimService,ISendMailHelper sendMailHelper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _cacheService = cacheService;
            _claimService = claimService;
            _sendMailHelper = sendMailHelper;
        }
        public async Task<Token> LoginAsync(LoginForm loginForm)
        {
            Account loginAccount = await _unitOfWork.AccountRepository.FindAccountByEmail(loginForm.Email);
            if (loginAccount == null)
            {
                throw new Exception("Email not found,please register first");
            }
            if (!loginForm.Password.CheckPassword(loginAccount.PasswordHash))
            {
                throw new Exception("Password is incorrect");
            }
            var refreshToken = RefreshToken.GetRefreshToken();
            var accessToken = loginAccount.GenerateTokenString(_configuration!.JwtSecretKey, DateTime.Now);
            var expireRefreshTokenTime = DateTime.Now.AddHours(24);
            await _unitOfWork.SaveChangeAsync();
            _cacheService.SetData( loginAccount.Id.ToString(), refreshToken, DateTime.Now.AddMinutes(30));
            return new Token
            {
                Username=loginAccount.UserName,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                RoleName=loginAccount.Role.RoleName
            };
        }

        public async Task<bool> RegisterAsync(RegisterForm registerForm)
        {
            var registerAccount =await _unitOfWork.AccountRepository.FindAccountByEmail(registerForm.Email);
            if (registerAccount != null)
            {
                throw new Exception("Email already exist");
            }
            var newAcc= _mapper.Map<Account>(registerForm);
            newAcc.RoleId = 3;
            newAcc.PasswordHash = registerForm.Password.Hash();
            newAcc.IsDelete = false;
            await _unitOfWork.AccountRepository.AddAsync(newAcc);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
        public async Task<Token> RefreshAccessTokenAsync(string refreshToken)
        {
            var accountId = _claimService.GetCurrentUserId;
            var cacheData = _cacheService.GetData<string>(accountId.ToString());
            var loginAccount = await _unitOfWork.AccountRepository.GetByIdAsync(accountId,x=>x.Role);
            if (loginAccount == null||cacheData==null)
            {
                return null;
            }
            if (cacheData != refreshToken)
            {
                return null;
            }
          var newAccessToken=loginAccount.GenerateTokenString(_configuration.JwtSecretKey,DateTime.Now);
            var newRefreshToken = RefreshToken.GetRefreshToken();
            _cacheService.RemoveData(refreshToken);
            _cacheService.SetData(loginAccount.Id.ToString(), newRefreshToken,  DateTime.Now.AddMinutes(30));
            return new Token
            {
                Username=loginAccount.UserName,
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                RoleName=loginAccount.Role.RoleName
            };
        }

        public async Task<Respone> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            string email= _cacheService.GetData<string>(resetPasswordDTO.Code);

            if (email != null)
            {
                if (resetPasswordDTO.NewPassword.Equals(resetPasswordDTO.ConfirmPassword))
                {
                    var user = await _unitOfWork.AccountRepository.FindAccountByEmail(email);
                    if (user != null)
                    {
                        resetPasswordDTO.NewPassword = resetPasswordDTO.NewPassword.Hash();
                        _ = _mapper.Map(resetPasswordDTO, user, typeof(ResetPasswordDTO), typeof(Account));
                        _unitOfWork.AccountRepository.Update(user);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            return new Respone(HttpStatusCode.OK,"Reset successfully");
                        }
                    }
                }
                else
                {
                    return new Respone(HttpStatusCode.BadRequest,"Password and Confirm Passord do not match");
                }
            }
            return new Respone(HttpStatusCode.BadRequest,"Invalide code");
        }

        public async Task<Respone> SendConfirmMailCode(string email)
        {
            var findAccount = await _unitOfWork.AccountRepository.FindAccountByEmail(email);
            string key;
            if (findAccount == null)
            {
                return new Respone(HttpStatusCode.BadRequest, "Account do not exist");
            }
            try
            {
                key = StringUtil.RandomString(6);
                //Get project's directory and fetch ForgotPasswordTemplate content from EmailTemplate
                string exePath = Environment.CurrentDirectory.ToString();
                string FilePath = exePath + @"/EmailTemplate/ForgotPasswordTemplate.html";
                StreamReader streamreader = new StreamReader(FilePath);
                string MailText = streamreader.ReadToEnd();
                streamreader.Close();
                //Replace [resetpasswordkey] = key
                MailText = MailText.Replace("[resetpasswordkey]", key);
                //Replace [emailaddress] = email
                MailText = MailText.Replace("[emailaddress]", email);
                var result = await _sendMailHelper.SendMailAsync(email, "ResetPassword", MailText);
                if (!result) 
                {
                    return new Respone(HttpStatusCode.BadRequest, "Cannot send mail");
                } ;

                _cacheService.SetData(key,email,DateTimeOffset.Now.AddMinutes(10));
            } catch(Exception ex) 
                {
                 return new Respone(HttpStatusCode.InternalServerError, ex.Message);
                }
            return new Respone(HttpStatusCode.OK, "Send successfully");
        }
    }
}
