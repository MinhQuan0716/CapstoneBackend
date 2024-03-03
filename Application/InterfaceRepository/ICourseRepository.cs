using Application.ViewModel.CourseModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Task<IEnumerable<CourseViewModel>> GetAllCourseAsync();
    }
}
