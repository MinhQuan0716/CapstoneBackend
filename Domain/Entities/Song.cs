using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Song:BaseEntity   
    {
        public string SongName { get; set; }
       public ICollection<SongDetail> Detail { get; set; }
    }
}
