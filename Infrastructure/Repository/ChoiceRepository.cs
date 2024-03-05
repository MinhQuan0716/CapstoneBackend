﻿using Application.InterfaceRepository;
using Application.InterfaceService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ChoiceRepository : GenericRepository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
        }
    }
}
