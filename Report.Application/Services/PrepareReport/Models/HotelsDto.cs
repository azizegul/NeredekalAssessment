using Hotel.Domain.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Application.Services.PrepareReport.Models
{
    public class HotelsDto
    {
        public Guid HotelId { get; set; }

        public string Info { get; set; }

        public ContactInfoType InfoType { get; set; }
    }
}
