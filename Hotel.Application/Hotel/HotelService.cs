using Hotel.Application.Common;
using Hotel.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Hotel
{
    public class HotelService : IHotelService
    {
        private readonly IHotelService _service;
        private readonly IApplicationDbContext _context;
        public HotelService(IHotelService service, IApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<Domain.Domain.Entities.Hotel> Add(HotelRequestModel requestModel, CancellationToken cancellationToken)
        {
            var hotel = await _service.Add(requestModel, cancellationToken);

            _context.Hotels.Add(hotel);

            return hotel;

        }

        public async Task<Domain.Domain.Entities.Hotel> ContactDetails(Guid id)
        {
            var hotelDetails = _context.Hotels.Include(x=>x.Contacts).Where(x => x.Id == id).FirstOrDefault();

            return hotelDetails;
        }

        public async Task<Domain.Domain.Entities.Hotel> Delete(Guid id, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            hotel.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return hotel;
        }
    }
}
