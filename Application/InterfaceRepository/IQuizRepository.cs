﻿using Application.ViewModel.QuizModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IQuizRepository:IGenericRepository<Quiz>
    {
        Task<Guid> GetLastSaveQuizId();
        Task<QuizViewModel> GetQuiz(Guid lessonId);
    }
}
