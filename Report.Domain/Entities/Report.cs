using Report.Domain.Common;
using Report.Domain.Enums;

namespace Report.Domain.Entities;

public class Report : BaseEntity
{
    public DateTime RequestDate { get; set; }

    public ReportStatus Status { get; set; }

    public ICollection<ReportData>? Data { get; set; }
}
