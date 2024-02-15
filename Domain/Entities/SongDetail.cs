using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class SongDetail:BaseEntity
    {
        public Guid SongId { get; set; }    
        public Song Song { get; set; }  
        public int NoteId { get; set; }    
        public Note Note { get; set; }
        public int Position { get; set; }
        public double DelayTime { get; set; }
    }
}
