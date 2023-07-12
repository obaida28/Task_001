using BussinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));
builder.Services.AddControllers();
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
