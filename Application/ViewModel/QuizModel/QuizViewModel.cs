using Application.ViewModel.ChoiceModel;
using Application.ViewModel.QuestionModel;
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
        public Guid QuizId { get; set; }
        public List<QuestionViewModelForQuiz> QuestionTextList { get; set; }
        public List<ChoiceViewModelForQuiz> ChoiceList { get; set; }
    }
}
