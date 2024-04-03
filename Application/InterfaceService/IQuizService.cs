using Application.Common;
using Application.ViewModel.QuizModel;
using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public  interface IQuizService
    {
        Task<Respone> CreateQuizAsync(CreateQuizModel createQuizModel);
        Task<Respone> DeleteQuizAsync(Guid quizId);
        Task<Respone> GetQuizAsync(Guid unitId,int pageIndex,int pageSize);
        Task<Respone> DoingQuizAsync(Guid quizId, List<DoingQuizViewModel> listAnswers);
    }
}
