using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Services.Report.Models
{
    public class ReportDataDto
    {
        public string Location { get; set; }

        public int RegisteredHotelCount { get; set; }

        public int RegisteredPhoneCount { get; set; }
    }
}
