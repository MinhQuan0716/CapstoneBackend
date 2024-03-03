﻿using Application.InterfaceRepository;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDBContext;
        private readonly IAccountRepository _accountRepository;
        private readonly ISongRepository _songRepository;
        private readonly ICourseRepository _courseRepository;
        public UnitOfWork(AppDbContext appDBContext, IAccountRepository accountRepository, ISongRepository songRepository, ICourseRepository courseRepository)
        {
            _appDBContext = appDBContext;
            _accountRepository = accountRepository;
            _songRepository = songRepository;
            _courseRepository = courseRepository;
        }

        public IAccountRepository AccountRepository => _accountRepository;

        public ISongRepository SongRepository => _songRepository;

        public ICourseRepository CourseRepository => _courseRepository;

        public async Task<int> SaveChangeAsync() => await _appDBContext.SaveChangesAsync();
    }
}

