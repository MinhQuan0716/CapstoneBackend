using Application.InterfaceService;
using Application.ViewModel.Respone;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> DeleteLesson(Guid lessonId)
        {
            var obj = await _unitOfWork.LessonRepository.GetByIdAsync(lessonId);
            if (obj is not null)
            {
                _unitOfWork.LessonRepository.SoftRemove(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Delete Suceess");
                }
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete False");
        }

        public async Task<Respone> GetAllLessonByCourseId(Guid courseId)
        {
            var result = await _unitOfWork.LessonRepository.GetAllLessonByCourseIdAsync(courseId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Respone> GetLessonById(Guid lessonId)
        {
            var result = await _unitOfWork.LessonRepository.GetByIdAsync(lessonId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
    }
}
