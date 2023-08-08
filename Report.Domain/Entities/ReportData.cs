using Report.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Domain.Entities
{
    public class ReportData : BaseEntity
    {
        public string Location { get; set; }

        public int RegisteredHotelCount { get; set; }

        public int RegisteredPhoneCount { get; set; }
    }
}
