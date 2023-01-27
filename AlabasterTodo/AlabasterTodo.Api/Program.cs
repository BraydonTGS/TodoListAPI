using AlabasterTodo.DataAccess.Interfaces;
using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.DataAccess.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Ignore Json Cycles //
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Database Context //
builder.Services.AddDbContext<AlabasterTodoDbContext>();

// Dependency Injection //
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
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
