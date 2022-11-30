using Application;
using Persistence;
using Shared;
using WebAPI.Extnesions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);

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

app.UseErrorHandlingMiddleWare();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();