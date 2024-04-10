using Application;
using Application.InterfaceRepository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, string databaseConnectionString,string cacheConnectionString)
        {
            services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(databaseConnectionString).EnableSensitiveDataLogging());
            services.AddScoped<IDatabase>(cfg =>
            {
                IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(cacheConnectionString);
                return multiplexer.GetDatabase();
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();   
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();  
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();  
            services.AddScoped<IQuizDetailRepository, QuizDetailRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuestionDetailRepository, QuestionDetailRepository>();
            services.AddScoped<IUserQuizAttemptRepository, UserQuizAttemptRepository>();
            services.AddScoped<ITheoryUnitRepository, TheoryUnitRepository>();
            services.AddScoped<IPracticeUnitRepository, PracticeUnitRepository>();
            services.AddScoped<IVideoUnitRepository, VideoUnitRepository>();
            services.AddScoped<IUserProgressRepository, UserProgressRepository>();
            return services;
        }
    }
}
