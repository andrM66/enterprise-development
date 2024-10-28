using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
 });
builder.Services.AddSingleton<IRepository<Bike, int>, BikeRepository>();
builder.Services.AddSingleton<IRepository<Client, int>, ClientRepository>();
builder.Services.AddSingleton<IRepository<BikeType, int>, BikeTypeRepository>();
builder.Services.AddSingleton<IRepository<Rent, int>, RentRepository>();
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
