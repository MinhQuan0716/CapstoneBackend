using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.LessonModel
{
    public class UnitViewModel
    {
        public Guid Id { get; set; }
        public string UnitName { get; set; }
        public TimeSpan UnitDuration { get; set; }
        public string UnitType { get; set; }
    }
}
