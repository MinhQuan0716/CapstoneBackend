using Application.ViewModel.ChoiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuestionModel
{
    public class CreateQuestionModel
    {
        public string QuestionText { get; set; }
        public string Explanation {  get; set; }    
        public List<CreateChoiceModel> ChoiceList { get; set; }
    }
}
