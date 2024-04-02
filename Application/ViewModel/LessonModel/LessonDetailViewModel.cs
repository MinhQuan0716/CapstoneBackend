using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.ViewModel.CourseModel
{
    public class LessonDetailViewModel
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public bool IsPremium { get; set; }
        public string? ImageUrl { get; set; }
        public int LessonOrder { get; set; }
        public decimal progress { get; set; }
        public bool isUnclocked { get; set; }
        public int NumberOfLesson { get; set; }
    }
}
