using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.CourseModel
{
    public class LessonDetailViewModel
    {
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public DateTime Duration { get; set; }
    }
}
