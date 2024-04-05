using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PracticeUnitModel
{
    public class PracticeUnitModel
    {
        public Guid LessonId { get; set; }
        public Guid ListNoteId { get; set; }
        public string ListNoteName { get; set; }
        public bool ListNoteStatus { get; set; }
        public ICollection<NoteViewModel> Notes { get; set; }
        public bool IsMandatory { get; set; }
    }
    public class NoteViewModel
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public double Duration { get; set; }
        public int Position { get; set; }
        public double DelayTime { get; set; }
    }
}
