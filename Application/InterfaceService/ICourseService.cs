using Application.ViewModel.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseViewModel>> GetAllCourse();
    }
}
