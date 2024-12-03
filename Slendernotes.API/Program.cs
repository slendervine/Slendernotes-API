using MongoDB.Driver;
using Slendernotes.API.Services;
using Slendernotes.API.Services.Interfaces;
using Slendernotes.API.Validations;
using Slendernotes.Infrastructure.Persistence.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Slendernotes.Domain.IRepository;
using DotNetEnv;
using Slendernotes.Infrastructure.Persistence.Settings;
using Slendernotes.Infrastructure.Repository;
using Slendernotes.Domain.Abstractions.Services;
using Slendernotes.Infrastructure.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);


// MediatR
builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssembly(typeof(Program).Assembly));


//MongoDB
Env.Load();
MongoSettings mongoSettings = new(); //Env propeties are inside this class


builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoSettings.ConnectionString));
builder.Services.AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoSettings.Database));
builder.Services.AddSingleton<MongoDbContext>();


//Validations
builder.Services
    .AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblyContaining<TextCreateValidator>();


//Injecting Interfaces
builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddScoped<ITextRepository, TextRepository>();
builder.Services.AddScoped<ILogStorageS3, LogStorageS3>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
