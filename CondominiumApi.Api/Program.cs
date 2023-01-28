using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Applications.Services;
using CondominiumApi.Domain.Interfaces;
using CondominiumApi.Infrastructure.Data.Repositories;
using CondominiumApi.Infrastructure.IoC.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

//Extension
builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddControllers();//.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
