namespace NeredekalAssesment.Test;

public class HotelTests
{
    private readonly Mock<IHotelService> _hotelService;
    private readonly HotelsController _controller;
    private readonly Hotel.Domain.Domain.Entities.Hotel hotel;
    public HotelTests()
    {
        _hotelService = new Mock<IHotelService>();
        _controller = new HotelsController(_hotelService.Object);
        hotel = new();
    }

    [Fact]
    public async void GetContacts_Should_Return_Not_Found_When_Hotel_Not_Exist()
    {
        Guid hotelId = Guid.NewGuid();

        Hotel.Domain.Domain.Entities.Hotel hotel = null;

        _hotelService.Setup(x => x.Get(hotelId)).ReturnsAsync(hotel);

        var result = await _controller.Get(hotelId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async void GetContacts_Should_Return_Ok()
    {
        Guid hotelId = Guid.NewGuid();

        _hotelService.Setup(x => x.Get(hotelId)).ReturnsAsync(hotel);

        var result = await _controller.Get(hotelId);

        Assert.IsType<OkObjectResult>(result);
    }
}