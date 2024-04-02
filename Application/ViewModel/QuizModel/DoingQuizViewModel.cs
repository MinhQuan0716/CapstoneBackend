using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuizModel
{
    public  class DoingQuizViewModel
    {
        public Guid QuestionId { get; set; }
        public Guid ChoiceId { get; set; }
    }
}
