using Application.ViewModel.ChoiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuestionModel
{
    public class QuestionWithChoiceViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<ChoiceViewModelForQuiz> ListChoices { get; set; }
    }
}
