﻿using Application.Common;
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
using System.Net.WebSockets;
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
        private readonly IClaimService _claimService;
        public AccountService(IUnitOfWork unitOfWork,AppConfiguration configuration,IMapper mapper,ICacheService cacheService,IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _cacheService = cacheService;
            _claimService = claimService;
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
           /* var cacheData = _cacheService.GetData<string>(loginAccount.Id.ToString());
            if (cacheData != null)
            {
                throw new Exception("You already logged in");
            }*/
            var refreshToken = RefreshToken.GetRefreshToken();
            var accessToken = loginAccount.GenerateTokenString(_configuration!.JwtSecretKey, DateTime.Now);
            var expireRefreshTokenTime = DateTime.Now.AddHours(24);
           /* loginAccount.RefreshToken = refreshToken;
            loginAccount.ExpireTokenTime= expireRefreshTokenTime;*/
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
            newAcc.RoleId = 2;
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
    }
}
