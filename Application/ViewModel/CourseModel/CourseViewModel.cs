using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.CourseModel
{
    public class CourseViewModel
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime Duration { get; set; }
        public int numberLesson { get; set; }
        public decimal progress { get; set; }
    }
}
