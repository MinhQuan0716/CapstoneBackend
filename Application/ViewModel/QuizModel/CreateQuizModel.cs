using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuizModel
{
    public class CreateQuizModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool QuizStatus { get; set; }
        public Guid UnitId { get; set; }
        public List<Guid> ListQuestionId { get; set; }    
    }
}
