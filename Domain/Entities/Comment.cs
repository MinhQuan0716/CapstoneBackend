using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment:BaseEntity
    {
        public string CommentContent { get; set; }  
        public  Guid VideoId { get; set; }
        public Video Video { get; set; }    
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
