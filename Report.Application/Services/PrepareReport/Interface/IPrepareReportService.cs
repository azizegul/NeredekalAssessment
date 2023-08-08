using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Report.Application.Services.PrepareReport.Models;

namespace Report.Application.Services.PrepareReport.Interface
{
    public interface IPrepareReportService
    {
        Task<List<HotelsDto>> GetContacts(PrepareReportModel model);
    }
}
