using Report.Application.Services.Report.Interface;
using Report.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Services.Report.Service
{
    public class ReportService : IReportService
    {
        private readonly IApplicationDbContext _context;

        public ReportService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create()
        {
            var entity = new Domain.Entities.Report
            {
                RequestDate = DateTime.Now,
                Status = ReportStatus.Preparing
            };

            await _context.Report.InsertOneAsync(entity);

            return entity.Id;
        }
    }
}
