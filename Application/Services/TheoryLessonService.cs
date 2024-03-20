using Application.InterfaceService;
using Application.ViewModel.ResponeModel;
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
    public class TheoryLessonService : ITheoryLessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TheoryLessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> GetAllTheoryLesson()
        {
            var result = await _unitOfWork.TheoryLessonRepository.GetAllAsync();
            return new Respone(HttpStatusCode.OK, "Fetch successfully", result);
        }

        public async Task<Respone> GetAllTheoryLessonByLessonId(Guid lessonId)
        {
            var result = await _unitOfWork.TheoryLessonRepository.GetAllTheoryLessonByLessonId(lessonId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
    }
}
