using Report.Application.Services.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Services.Report.Interface
{
    public interface IReportService
    {
        Task<string> Create();
        Task<ReportDto> GetReport(string Id);
        Task<List<ReportDto>> GetAllReport();

    }
}
