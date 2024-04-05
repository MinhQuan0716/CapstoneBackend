using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.PracticeUnitModel;
using Application.ViewModel.TheoryLessonModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PracticeUnitRepository : GenericRepository<PraticeUnit>, IPracticeUnitRepository
    {
        private readonly AppDbContext _appDbContext;
        public PracticeUnitRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<PracticeUnitModel>> GetAllPracticeUnitByUnitId(Guid unitId)
        {
            var practiceUnits = await _appDbContext.PracticeUnits
            .Include(p => p.ListNote)
                .ThenInclude(l => l.Detail)
                .ThenInclude(d => d.Note)
                .ToListAsync();

            return practiceUnits.Select(p => new PracticeUnitModel
            {
                LessonId = p.UnitId,
                ListNoteId = p.ListNoteId,
                ListNoteName = p.ListNote.ListNoteName,
                ListNoteStatus = p.ListNote.ListNoteStatus,
                Notes = p.ListNote.Detail.Select(d => new NoteViewModel
                {
                    NoteId = d.Note.NoteId,
                    NoteName = d.Note.NoteName,
                    Duration = d.Note.Duration,
                    Position = d.Position,
                    DelayTime = d.DelayTime
                }).OrderBy(note => note.Position).ToList(),
                IsMandatory = p.IsMandatory
            });
        }
    }
}