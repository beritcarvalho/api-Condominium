using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Applications.Services;
using CondominiumApi.Infrastructure.IoC.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

//Extension
builder.Services.AddInfrastructure(builder.Configuration);

//Scoped
builder.Services.AddScoped<IPersonService, PersonService>();

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
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
