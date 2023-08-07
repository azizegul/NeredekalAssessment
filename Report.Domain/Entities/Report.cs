using Report.Domain.Common;
using Report.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Domain.Entities
{
    public class Report : BaseEntity
    {
        public DateTime RequestDate { get; set; }

        public ReportStatus Status { get; set; }

        public ICollection<ReportData>? Data { get; set; }
    }
}
