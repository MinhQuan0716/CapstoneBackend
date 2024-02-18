using Application.ViewModel.Login_Model;
using Application.ViewModel.RegisterModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IAccountService
    {
        Task<Token> LoginAsync(LoginForm loginForm);
        Task<bool> RegisterAsync(RegisterForm registerForm);
        Task<Token> RefreshAccessTokenAsync(string refreshToken);
    }
}
