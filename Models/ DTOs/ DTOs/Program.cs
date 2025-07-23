// Program.cs
using Microsoft.EntityFrameworkCore;
using Think41.BaggageAPI;
using Think41.BaggageAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Think41DbContext>(opt =>
    opt.UseInMemoryDatabase("BaggageDb"));

builder.Services.AddScoped<IBagService, BagService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
