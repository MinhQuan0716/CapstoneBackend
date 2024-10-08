﻿using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using Application.ViewModel.ResetPasswordModel;
using Application.ViewModel.ResponeModel;
using Google.Apis.Auth;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.AccountModel;
using Application.ViewModel.UpdatePasswordModel;

namespace Application.InterfaceService
{
    public interface IAccountService
    {
        Task<Token> LoginAsync(LoginForm loginForm);
        Task<bool> RegisterAsync(RegisterForm registerForm);
        Task<Token> RefreshAccessTokenAsync(string refreshToken);
        Task<Respone> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<Respone> SendConfirmMailCode(string email);
        Task<Respone> GetAllAccount();
        Task<Respone> GetCurrentLoginUser();
        Task<Token> LoginGoogle(string token);
        Task<Respone> UpdateAccount(Guid accountId, AccountViewModel accountViewModel);
        Task<Respone> UpdatePassword(Guid accountId, UpdatePasswordDTO updatePasswordDTO);
    }
}
