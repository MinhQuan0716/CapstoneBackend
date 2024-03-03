using Application.InterfaceRepository;
using Application.InterfaceService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SongRepository : GenericRepository<ListNote>, ISongRepository
    {
        private AppDbContext _appDbContext;
        public SongRepository(AppDbContext appDbContext,IClaimService claimService) : base(appDbContext,claimService)
        {
            _appDbContext = appDbContext;
        }
    }
}