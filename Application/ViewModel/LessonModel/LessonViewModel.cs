using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.LessonModel
{
    public class LessonViewModel
    {
        public string LessonName { get; set; }
        public TimeSpan LessonDuration { get; set; }
        public string LessonType { get; set; }
    }
}
