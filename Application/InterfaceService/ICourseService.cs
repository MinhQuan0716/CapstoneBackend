﻿using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface ICourseService
    {
        Task<Respone> GetAllCourse(Guid userId);
        Task<Respone> CreateCourse(CourseDetailViewModel model);
        Task<Respone> DeleteCourse(Guid courtId);
        Task<Respone> UpdateCourse(Guid courtId, CourseDetailViewModel model);
        Task<Respone> GetCourseById(Guid courtId);
    }
}
