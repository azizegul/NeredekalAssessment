using Hotel.Domain.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Contact
{
    public class ContactRequestModel
    {
        public Guid HotelId { get; set; }
        public ContactInfoType InfoType { get; set; }
        public string Info { get; set; }
    }
}
