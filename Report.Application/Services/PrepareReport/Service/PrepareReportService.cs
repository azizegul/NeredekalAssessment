using Amazon.Runtime.Internal;
using Flurl.Http;
using Hotel.Domain.Domain.Enums;
using MongoDB.Driver;
using Report.Application.Services.PrepareReport.Interface;
using Report.Application.Services.PrepareReport.Models;
using Report.Domain.Entities;
using Report.Domain.Enums;
using System.Threading;

namespace Report.Application.Services.PrepareReport.Service
{
    public class PrepareReportService : IPrepareReportService
    {
        private readonly IApplicationDbContext _context;

        private string baseUrl = "https://localhost:7273/Contact";


        public PrepareReportService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelsDto>> GetContacts(PrepareReportModel model)
        {
            var data = await baseUrl.GetJsonAsync<IList<HotelsDto>>();

            var reportData = data
             .Where(r => r.InfoType == ContactInfoType.Location)
             .GroupBy(r => r.Info)
             .Select(r => new ReportData
             {
                 Location = r.Key,
             }).ToList();

            foreach (var reportItem in reportData)
            {
                var hotelIdList = data.Where(y => y.InfoType == ContactInfoType.Location && y.Info == reportItem.Location)
                    .Select(x => x.HotelId).ToList();

                reportItem.RegisteredPhoneCount = data.Count(x =>
                hotelIdList.Contains(x.HotelId) && x.InfoType == ContactInfoType.Phone); // Konumda yer alan rehbere kayıtlı telefon numarası sayısı

                reportItem.RegisteredHotelCount = hotelIdList.Count(); // Konumda yer alan rehbere kayıtlı otel sayısı
            }

            var report = await _context.Report.Find(x => x.Id == model.ReportId).FirstOrDefaultAsync();

            report.Data = reportData;
            report.Status = ReportStatus.Completed;

            await _context.Report.ReplaceOneAsync(k => k.Id == model.ReportId, report);

            return data.ToList(); //TODO: Dönüş tipi düzenlenecek.
        }
    }
}
