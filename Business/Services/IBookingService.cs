using Business.Models;

namespace Business.Services;

public interface IBookingService
{
    Task<BookingServiceResultModel> CreateBookingAsync(CreateBookingModel model);
    Task<IEnumerable<BookingModel>> GetBookingsAsync(string customerId);
}
