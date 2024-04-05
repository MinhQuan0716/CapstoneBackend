using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.LessonModel;
using Application.ViewModel.TheoryLessonModel;
using Application.ViewModel.VideoUnitModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VideoUnitRepository : GenericRepository<UnitVideo>, IVideoUnitRepository
    {
        private readonly AppDbContext _appDbContext;
        public VideoUnitRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<VideoUnitModel>> GetAllVideoUnitByUnitIdAsync(Guid unitId)
        {
            return await _appDbContext.UnitVideos
                .Where(Video => Video.UnitId == unitId)
                .Select(x => new VideoUnitModel
                {
                    Id = x.Id,
                    VideoTitle = x.VideoTitle,
                    VideoDesciption = x.VideoDesciption,
                    VideoUrl = x.VideoUrl,
                }).AsQueryable().ToListAsync();
        }
    }
}
