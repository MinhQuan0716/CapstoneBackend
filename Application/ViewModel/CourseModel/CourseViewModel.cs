using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.CourseModel
{
    public  class CourseViewModel
    {
        public string courseName { get; set; }  
        public int lessonAmount { get; set; }
        public DateTime Duration { get; set; }
        public double Percentage { get; set; }
    }
}
