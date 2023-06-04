using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using DT.BusinessRules.Contracts;
using DT.BusinessRules.Rules;
using DT.Infra.Repository;
using DT.Infra.Contracts;
using DT.Infra.ExternalServices;
using DT.Infra.ExternalServices.DummyService.Contracts;
using DT.Infra.ExternalServices.DummyService.Data;
using DT.Infra.ExternalServices.DummyService.Services;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);

//Background service hosting
IHost _host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>{
        services.AddHostedService<Worker>()
        .AddSingleton<IUserDummyData, UserDummyData>()
        .AddSingleton<IDummyService, DummyService>()
        .AddDbContext<AppDbContext>(opt => 
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DummyDBConnection")));
    }).Build();

_host.Run();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserRules, UserRules>();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DummyDBConnection")));

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
