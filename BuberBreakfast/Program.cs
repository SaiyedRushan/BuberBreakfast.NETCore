using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBreakfastService, BreakfastService>();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.UseAuthorization();

app.MapControllers();

app.Run();
