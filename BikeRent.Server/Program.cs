using BikeRent.Domain.Entities;
using BikeRent.Domain.Repositories;
using BikeRent.Domain.Context;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BikeRentDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
 });
builder.Services.AddScoped<IRepository<Bike, int>, BikeRepository>();
builder.Services.AddScoped<IRepository<Client, int>, ClientRepository>();
builder.Services.AddScoped<IRepository<BikeType, int>, BikeTypeRepository>();
builder.Services.AddScoped<IRepository<Rent, int>, RentRepository>();
builder.Services.AddAutoMapper(typeof(Server.Mapping));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
