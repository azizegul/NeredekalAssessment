using MongoDB.Driver;

namespace Report.Application
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Domain.Entities.Report> Report { get; set; }
    }
}
