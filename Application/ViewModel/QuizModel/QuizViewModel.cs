using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuizModel
{
    /// <summary>
    /// QuestionTextList:List of Question
    /// ChoiceList:List Choice In Question
    /// </summary>
    public class QuizViewModel
    {
        public List<string> QuestionTextList { get; set; }
        public List<string> ChoiceList { get; set; }    
    }
}
