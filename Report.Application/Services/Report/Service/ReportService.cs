using Flurl.Http;
using Hotel.Domain.Domain.Enums;
using MassTransit;
using MongoDB.Driver;
using Report.Application.Services.Report.Interface;
using Report.Application.Services.Report.Models;
using Report.Domain.Entities;
using Report.Domain.Enums;
using Report.Domain.Events;

namespace Report.Application.Services.Report.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportDbContext _context;

        private readonly IPublishEndpoint _publishEndpoint;

        private string baseUrl = "https://localhost:7273/api/Contacts";

        public ReportService(IReportDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<string> Create()
        {
            var entity = new Domain.Entities.Report
            {
                RequestDate = DateTime.Now,
                Status = ReportStatus.Preparing
            };

            await _context.Report.InsertOneAsync(entity);

            await _publishEndpoint.Publish<ReportCreated>(new(entity.Id));

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
                    RegisteredPhoneCount = x.RegisteredPhoneCount,
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

        public async Task PrepareReport(PrepareReportModel model)
        {
            var data = await baseUrl.GetJsonAsync<IList<HotelsDto>>();

            var reportData = data
             .Where(r => r.InfoType == ContactInfoType.Location)
             .GroupBy(r => r.Info)
             .Select(r => new ReportData
             {
                 Location = r.Key
             }).ToList();

            foreach (var reportItem in reportData)
            {
                var hotelIdList = data.Where(y => y.InfoType == ContactInfoType.Location && y.Info == reportItem.Location)
                    .Select(x => x.HotelId).ToList();

                reportItem.RegisteredPhoneCount = data
                    .Count(x =>
                hotelIdList.Contains(x.HotelId) && x.InfoType == ContactInfoType.Phone);

                reportItem.RegisteredHotelCount = hotelIdList.Count();
            }

            var report = await _context.Report.Find(x => x.Id == model.ReportId).FirstOrDefaultAsync();

            report.Data = reportData;
            report.Status = ReportStatus.Completed;

            await _context.Report.ReplaceOneAsync(k => k.Id == model.ReportId, report);

        }
    }
}
