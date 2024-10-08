﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public  interface IAccountRepository:IGenericRepository<Account>
    {
        Task<Account> FindAccountByEmail(string email);
        Task<Account> FindAccountByEmailAndPassword(string email, string password); 
    }
}
