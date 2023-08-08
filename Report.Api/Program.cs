using MongoDB.Driver;
using Report.Application;
using Report.Application.Services.PrepareReport.Interface;
using Report.Application.Services.PrepareReport.Service;
using Report.Application.Services.Report.Interface;
using Report.Application.Services.Report.Service;
using Report.Infrastructure.Persistence;
using Report.Infrastructure.Persistence.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddTransient<IPrepareReportService, PrepareReportService>();
builder.Services.AddTransient<IReportService, ReportService>();

builder.Services.Configure<ApplicationDbContext>(
          builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
    var client = new MongoClient(settings.Connection);
    return client.GetDatabase(settings.DatabaseName);
});

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
