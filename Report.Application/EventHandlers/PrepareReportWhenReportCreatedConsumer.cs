using MassTransit;
using Microsoft.Extensions.Logging;
using Report.Application.Services.Report.Interface;
using Report.Application.Services.Report.Models;
using Report.Domain.Events;

namespace Report.Application.EventHandlers
{
    public class PrepareReportWhenReportCreatedConsumer : IConsumer<ReportCreated>
    {
        private ILogger<PrepareReportWhenReportCreatedConsumer> _logger;

        private readonly IReportService _reportService;

        public PrepareReportWhenReportCreatedConsumer(ILogger<PrepareReportWhenReportCreatedConsumer> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }


        public async Task Consume(ConsumeContext<ReportCreated> context)
        {
            _logger.LogInformation("Starting prepare report data process");

            await _reportService.PrepareReport(new PrepareReportModel { ReportId = context.Message.Id });

            _logger.LogInformation("Process has been finished succesfully");
        }
    }
}
