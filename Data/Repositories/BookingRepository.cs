using System.Diagnostics;
using System.Linq.Expressions;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BookingRepository(DataContext context, DbSet<BookingEntity> dbSet) : BaseRepository<BookingEntity>(context, dbSet)
{
    public async Task<bool> VoucherCodeExistsAsync(string code)
    {
        bool exists = await _context.Tickets.AnyAsync(x => x.EVoucher == code);

        if (exists)
            return true;

        return false;
    }
}
