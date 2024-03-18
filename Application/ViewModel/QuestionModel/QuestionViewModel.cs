using Application.ViewModel.ChoiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.QuestionModel
{
    public class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Explainantion {  get; set; }
        public List<ChoiceViewModel> ChoiceList { get; set; }
    }
}
