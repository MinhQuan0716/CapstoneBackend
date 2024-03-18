using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ChoiceModel
{
    public class ChoiceViewModel
    {
        public Guid ChoiceId { get; set; }
        public string ChoiceText { get; set;}
        public bool IsCorrect { get; set; }
    }
}
