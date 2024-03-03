using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CourseViewModel>> GetAllCourse()
        {
            return await _unitOfWork.CourseRepository.GetAllCourseAsync();
        }
    }
}
