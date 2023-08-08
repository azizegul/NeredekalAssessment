using MassTransit;
using MongoDB.Driver;
using Report.Application;
using Report.Application.EventHandlers;
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
builder.Services.AddScoped<IReportDbContext, ReportDbContext>();

builder.Services.AddTransient<IReportService, ReportService>();

builder.Services.Configure<MongoDbSettings>(
          builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
    var client = new MongoClient(settings.Connection);
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(PrepareReportWhenReportCreatedConsumer).Assembly);

    x.SetKebabCaseEndpointNameFormatter();

    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
    {
        config.Host("amqps://papoxjil:prFF5JqD61vBuF1dPR1yS46Dq42eHNlB@cow.rmq2.cloudamqp.com/papoxjil", h =>
        {
            h.Username("papoxjil");
            h.Password("prFF5JqD61vBuF1dPR1yS46Dq42eHNlB");
        });

        config.ReceiveEndpoint(nameof(PrepareReportWhenReportCreatedConsumer), ep =>
        {
            ep.PrefetchCount = 1;
            ep.UseMessageRetry(r => r.Interval(5, 1000));
            ep.ConfigureConsumer<PrepareReportWhenReportCreatedConsumer>(provider);
        });
    }));

    //x.UsingRabbitMq();
});


builder.Services.Configure<MassTransitHostOptions>(options => { options.WaitUntilStarted = true; });

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
