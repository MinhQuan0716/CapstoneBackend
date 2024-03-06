﻿using Application.ViewModel.CourseModel;
using Application.ViewModel.RegisterModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public  class MapperProfileConfiguration:Profile
    {
        public MapperProfileConfiguration() 
        { 
            CreateAccountMap();
            CreateCourseMap();
        }
        internal void CreateAccountMap()
        {
            CreateMap<RegisterForm, Account>().ReverseMap();
        }
        internal void CreateCourseMap()
        {
            CreateMap<CourseDetailViewModel, Course>().ReverseMap();
        }
    }
}
