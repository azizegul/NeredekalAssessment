using Hotel.Domain.Domain.Enums;

namespace Report.Application.Services.Report.Models;

public class HotelsDto
{
    public Guid HotelId { get; set; }

    public string Info { get; set; }

    public ContactInfoType InfoType { get; set; }
}
