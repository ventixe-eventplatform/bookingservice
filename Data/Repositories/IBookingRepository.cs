using Data.Entities;

namespace Data.Repositories;

public interface IBookingRepository : IBaseRepository<BookingEntity>
{
    Task<bool> VoucherCodeExistsAsync(string code);
}
