using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Person.Model
{
    public class PersonRequestModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyTitle { get; set; }
        public Guid HotelId { get; set; }

    }
}
