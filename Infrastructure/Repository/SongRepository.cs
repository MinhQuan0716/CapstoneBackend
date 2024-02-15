using Application.InterfaceRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private AppDbContext _appDbContext;
        public SongRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}