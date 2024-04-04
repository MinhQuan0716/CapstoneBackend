using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Note
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<ListNoteDetail> ListNoteDetail { get; set; }
    }
}
