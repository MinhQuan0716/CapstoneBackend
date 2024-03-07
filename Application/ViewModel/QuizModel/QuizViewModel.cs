using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuizModel
{
    public class QuizViewModel
    {
        public string QuestionText { get; set; }
        public List<string> ChoiceList { get; set; }
    }
}
