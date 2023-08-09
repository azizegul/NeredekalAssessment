using Hotel.Application.Services.Hotel.Interface;
using Hotel.Application.Services.Hotel.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.Services.Hotel.Service;

public class HotelService : IHotelService
{
    private readonly IApplicationDbContext _context;

    public HotelService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Domain.Entities.Hotel> Add(HotelRequestModel requestModel)
    {

        Domain.Domain.Entities.Hotel hotel = new()
        {
            Name = requestModel.Name
        };

        await _context.Hotels.AddAsync(hotel);

        await _context.SaveChangesAsync();

        return hotel;

    }

    public async Task<Domain.Domain.Entities.Hotel> Get(Guid id)
    {
        var hotelDetails = await _context.Hotels.Include(x => x.Contacts.Where(c => !c.IsDeleted)).Include(x => x.Persons.Where(c => !c.IsDeleted)).FirstOrDefaultAsync(h => h.Id == id);

        return hotelDetails;
    }

    public async Task<bool> Delete(Guid id)
    {
        var hotel = await _context.Hotels.FindAsync(id);

        if (hotel == null)
            throw new Exception("Hotel Not Found.");

        hotel.IsDeleted = true;

        _context.Hotels.Update(hotel);

        await _context.SaveChangesAsync();

        return hotel.IsDeleted;
    }
}
