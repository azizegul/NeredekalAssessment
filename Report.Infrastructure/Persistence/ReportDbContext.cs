using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Report.Application;
using Report.Domain.Entities;
using Report.Infrastructure.Persistence.Settings;

namespace Report.Infrastructure.Persistence
{
    public class ReportDbContext : IReportDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public ReportDbContext(IOptions<MongoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Connection);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);

            Report = _db.GetCollection<Domain.Entities.Report>(nameof(Domain.Entities.Report));
            ReportData = _db.GetCollection<ReportData>(nameof(ReportData));
        }

        public IMongoCollection<Domain.Entities.Report> Report { get; set; }
        public IMongoCollection<ReportData> ReportData { get; set; }
    }
}
