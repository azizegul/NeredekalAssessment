namespace NeredekalAssesment.Test;

public class ContactTests
{
    private readonly Mock<IContactService> _contactService;
    private readonly ContactsController _controller;

    private List<ContactModel> contacts = new List<ContactModel>() { new ContactModel { HotelId = _hotelId, Info = "admin@admin.com.tr", InfoType = Hotel.Domain.Domain.Enums.ContactInfoType.Email },
            new ContactModel() { HotelId = new Guid(), Info = "05463456798", InfoType = Hotel.Domain.Domain.Enums.ContactInfoType.Phone } };

    public ContactTests()
    {
        _contactService = new Mock<IContactService>();
        _controller = new ContactsController(_contactService.Object);
    }

    private static Guid _hotelId = Guid.NewGuid();



    [Fact]
    public async void GetContacts_Should_Return_Contact_List()
    {
        _contactService.Setup(x => x.Get()).ReturnsAsync(contacts);

        var result = await _controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(result);

        var returnProducts = Assert.IsAssignableFrom<IEnumerable<ContactModel>>(okResult.Value);

        Assert.Equal<int>(2, returnProducts.ToList().Count);

    }
}
