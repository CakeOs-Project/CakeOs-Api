using CakeOs.Web.Extensions;
using CakeOs.Web.Extensions.Infrastructure;
using CakeOs.Web.Extensions.Module;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);

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
