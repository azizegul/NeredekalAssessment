using Report.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Services.Report.Models
{
    public class ReportDto
    {
        public string Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public string StatusName => Status.ToString();
        public IList<ReportDataDto>? Data { get; set; }
    }
}
