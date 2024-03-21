using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class ListNote:BaseEntity   
    {
        public string ListNoteName { get; set; }
        public bool ListNoteStatus { get; set; }
        public ICollection<ListNoteDetail> Detail { get; set; }
        public ICollection<PraticeLesson> PraticeLessons { get; set; }
    }
}
