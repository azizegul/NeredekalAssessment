namespace Hotel.Application.Services.Person.Model;

public class PersonRequestModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string CompanyTitle { get; set; }
    public Guid HotelId { get; set; }

}
