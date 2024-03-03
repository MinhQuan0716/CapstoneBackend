using Application.Common;
using Infrastructure;
using Infrastructure.Mappers;
using Microsoft.OpenApi.Models;
using MonochordCapstoneProjectAPI;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddInfrastructureService(configuration!.databaseConnectionString,configuration!.cacheConnectionString);
builder.Services.AddWebAPIService(configuration!.JwtSecretKey);
builder.Services.AddSingleton(configuration);
builder.Services.AddAutoMapper(typeof(MapperProfileConfiguration));
builder.Services.AddCors(options
     => options.AddPolicy(name: "AllowOrigin", policy
         => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
     });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API");

    });
    app.ApplyMigration();
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API");

    });
}
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
