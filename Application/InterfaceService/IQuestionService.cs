﻿using Application.ViewModel.QuestionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.ResponeModel;
namespace Application.InterfaceService
{
    public interface IQuestionService
    {
       Task<Respone> AddQuestionAsync(CreateQuestionModel createQuestionModel);
        Task<Respone> GetAllQuestionAsync();
        Task<Respone> DeleteQuestionAsync(Guid questionId);
        Task<Respone> GetQuestionByQuizIdAsync(Guid quizId);
    }
}
