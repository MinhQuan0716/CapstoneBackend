using Application.InterfaceService;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MonochordCapstoneProjectAPI.Service;
namespace MonochordCapstoneProjectAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services,string secretKey)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddHttpContextAccessor();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = secretKey,
                       ValidAudience = secretKey,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                       ClockSkew = TimeSpan.FromSeconds(1)
                   };
               });
            return services;
        }
    }
}
