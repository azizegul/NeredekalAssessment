using Report.Application.Services.Report.Models;

namespace Report.Application.Services.Report.Interface;

public interface IReportService
{
    Task<string> Create();
    Task<ReportDto> GetReport(string Id);
    Task<List<ReportDto>> GetAllReport();
    Task PrepareReport(PrepareReportModel model);
}
