using MongoDB.Driver;

namespace Report.Application
{
    public interface IReportDbContext
    {
        IMongoCollection<Domain.Entities.Report> Report { get; set; }
    }
}
