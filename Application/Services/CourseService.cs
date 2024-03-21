using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> CreateCourse(CourseDetailViewModel model)
        {
            var obj = _mapper.Map<Course>(model);
            obj.IsDelete = false;
            await _unitOfWork.CourseRepository.AddAsync(obj);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result > 0)
            {
                return new Respone(HttpStatusCode.OK, "Add Suceess", model);
            }
            return new Respone(HttpStatusCode.InternalServerError, "Add False", model);
        }

        public async Task<Respone> DeleteCourse(Guid CourseId)
        {
            var obj = await _unitOfWork.CourseRepository.GetByIdAsync(CourseId);
            if (obj is not null)
            {
                _unitOfWork.CourseRepository.SoftRemove(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Delete Suceess");
                }
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete False");
        }

        public async Task<Respone> GetAllCourse()
        {
            List<Course> course = await _unitOfWork.CourseRepository.GetAllAsync();
            if (course.Any())
            {
                return new Respone(HttpStatusCode.OK, "Fetch successfully", course);
            }
            return new Respone(HttpStatusCode.BadRequest, "Fetch error");
        }

        public async Task<Respone> GetAllCourseByUserId(Guid userId)
        {
            var result = await _unitOfWork.CourseRepository.GetAllCourseByUserIdAsync(userId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Respone> GetCourseById(Guid CourseId)
        {
            var result = await _unitOfWork.CourseRepository.GetByIdAsync(CourseId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
        public async Task<Respone> UpdateCourse(Guid CourseId, CourseDetailViewModel model)
        {
            var obj = await _unitOfWork.CourseRepository.GetByIdAsync(CourseId);
            if (obj is not null)
            {
                obj.CourseDescription = model.CourseDescription;
                obj.CourseName = model.CourseName;

                _unitOfWork.CourseRepository.Update(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Update Suceess", model);
                }
            }
            return new Respone(HttpStatusCode.InternalServerError, "Update False");
        }
    }
}
