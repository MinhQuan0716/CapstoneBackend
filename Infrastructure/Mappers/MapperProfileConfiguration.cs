using Application.ViewModel.LessonModel;
﻿using Application.ViewModel.ChoiceModel;
using Application.ViewModel.CourseModel;
using Application.ViewModel.RegisterModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.QuestionModel;
using Application.ViewModel.QuizModel;

namespace Infrastructure.Mappers
{
    public  class MapperProfileConfiguration:Profile
    {
        public MapperProfileConfiguration() 
        { 
            CreateAccountMap();
            CreateCourseMap();
            CreateLessonMap();
            CreateChoiceMap();
            CreateQuestionMap();
            CreateQuizMap();
        }
        internal void CreateAccountMap()
        {
            CreateMap<RegisterForm, Account>().ReverseMap();
        }
        internal void CreateCourseMap()
        {
            CreateMap<CourseDetailViewModel, Course>().ReverseMap();
        }
        internal void CreateLessonMap()
        {
            CreateMap<LessonViewModel, Lesson>().ReverseMap();
        }
        internal void CreateQuestionMap()
        {
            CreateMap<CreateQuestionModel,Question>().ReverseMap();
            CreateMap<UpdateQuestionViewModel,Question>().ReverseMap(); 
        }
        internal void CreateChoiceMap()
        {
            CreateMap<CreateChoiceModel, Choice>().ReverseMap();    
        }
        internal void CreateQuizMap()
        {
            CreateMap<CreateQuizModel,Quiz>().ReverseMap();
            CreateMap<QuizViewModel, Quiz>().ReverseMap();
        }
    }
}
