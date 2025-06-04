using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BookingRepository: BaseRepository<BookingEntity>, IBookingRepository
{
    public BookingRepository(DataContext context) : base(context)
    {
    }

    public async Task<bool> VoucherCodeExistsAsync(string code)
    {
        bool exists = await _context.Tickets.AnyAsync(x => x.EVoucher == code);

        if (exists)
            return true;

        return false;
    }
}
