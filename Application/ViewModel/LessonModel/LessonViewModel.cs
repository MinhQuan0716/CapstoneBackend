using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.CourseModel
{
    public class LessonViewModel
    {
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public DateTime Duration { get; set; }
        public int unitNumber { get; set; }
        public decimal progress { get; set; }
    }
}
