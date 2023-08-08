using MongoDB.Driver;
using Report.Application.Services.Report.Interface;
using Report.Application.Services.Report.Models;
using Report.Domain.Entities;
using Report.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<ReportDto> GetReport(string Id)
        {
            var report =
           await _context
               .Report.Find(x => x.IsDeleted == false && x.Id == Id)
               .FirstOrDefaultAsync();

            if (report == null)
                return null;

            var reportDto = new ReportDto
            {
                Id = report.Id,
                RequestDate = report.RequestDate,
                Status = report.Status,
                Data = report.Data?.Select(x => new ReportDataDto
                {
                    Location = x.Location,
                    RegisteredHotelCount = x.RegisteredHotelCount,
                    RegisteredPhoneCount=x.RegisteredPhoneCount,
                }).ToList()
            };

            return reportDto;
        }

        public async Task<List<ReportDto>> GetAllReport()
        {
            var reportQuery =
         await _context.Report.Find(k => k.IsDeleted == false).ToListAsync();

            return reportQuery.Select(k => new ReportDto
            {
                Id = k.Id,
                RequestDate = k.RequestDate,
                Status = k.Status
            }).ToList();
        }

       
    }
}
