using Application.Common;
using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.Util;
using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public AccountService(IUnitOfWork unitOfWork,AppConfiguration configuration,IMapper mapper,ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _cacheService = cacheService;
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
            var cacheData= _cacheService.GetData<string>(loginAccount.Id.ToString());
            if (cacheData != null)
            {
                throw new Exception("You already logged in");
            }
            var refreshToken = RefreshToken.GetRefreshToken();
            var accessToken = loginAccount.GenerateTokenString(_configuration!.JwtSecretKey, DateTime.Now);
            var expireRefreshTokenTime = DateTime.Now.AddHours(24);
            loginAccount.RefreshToken = refreshToken;
            loginAccount.ExpireTokenTime= expireRefreshTokenTime;
            await _unitOfWork.SaveChangeAsync();
            _cacheService.SetData(loginAccount.Id.ToString(), accessToken, DateTime.Now.AddMinutes(1));
            return new Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
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
            newAcc.RoleId = 2;
            newAcc.PasswordHash = registerForm.Password.Hash();
            await _unitOfWork.AccountRepository.AddAsync(newAcc);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
