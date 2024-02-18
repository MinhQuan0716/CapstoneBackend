using Application.Common;
using Infrastructure;
using Infrastructure.Mappers;
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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
