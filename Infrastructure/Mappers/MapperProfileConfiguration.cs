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
using Application.ViewModel.ResetPasswordModel;
using Application.ViewModel.AccountModel;
using Application.ViewModel.UpdatePasswordModel;

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
            CreateMap<ResetPasswordDTO,Account>().ForMember(rp => rp.PasswordHash, opt => opt.MapFrom(src => src.NewPassword)).ReverseMap();
            CreateMap<AccountViewModel, Account>().ReverseMap();
            CreateMap<UpdatePasswordDTO, Account>().ForMember(rp => rp.PasswordHash, opt => opt.MapFrom(src => src.NewPassword)).ReverseMap();
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
            CreateMap<CreateQuestionWithChoiceModel,Question>().ReverseMap();
            CreateMap<UpdateQuestionViewModel,Question>().ReverseMap();
            CreateMap<CreateQuestionModel, Question>().ReverseMap();
        }
        internal void CreateChoiceMap()
        {
            CreateMap<CreateChoiceModel, Choice>().ReverseMap();    
            CreateMap<UpdateChoiceModel, Choice>().ReverseMap();
        }
        internal void CreateQuizMap()
        {
            CreateMap<CreateQuizModel,Quiz>().ReverseMap();
        }
    }
}
