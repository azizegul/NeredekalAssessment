using Report.Domain.Common;

namespace Report.Domain.Entities
{
    public class ReportData : BaseEntity
    {
        public string Location { get; set; }

        public int RegisteredHotelCount { get; set; }

        public int RegisteredPhoneCount { get; set; }
    }
}
