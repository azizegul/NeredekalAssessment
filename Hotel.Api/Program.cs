using Hotel.Application;
using Hotel.Application.Services.Contact.Interface;
using Hotel.Application.Services.Contact.Service;
using Hotel.Application.Services.Hotel.Interface;
using Hotel.Application.Services.Hotel.Service;
using Hotel.Application.Services.Person.Interface;
using Hotel.Application.Services.Person.Service;
using Hotel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IPersonService, PersonService>();




builder.Services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
