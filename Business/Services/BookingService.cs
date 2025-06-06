using Business.Factories;
using Business.Helpers;
using Business.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class BookingService(IBookingRepository bookingRepository, InvoiceNumberGenerator invoiceNumberGenerator) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;
    private readonly InvoiceNumberGenerator _invoiceNumberGenerator = invoiceNumberGenerator;

    public async Task<BookingServiceResultModel> CreateBookingAsync(CreateBookingModel model)
    {
        var voucherCodes = new List<string>();
        foreach (var ticket in model.Tickets)
        {
            for(int i = 0; i < ticket.Quantity; i++)
            {
                string voucherCode;
                var random = new Random();

                do
                {
                    voucherCode = random.Next(100000, 999999).ToString();
                } while (await _bookingRepository.VoucherCodeExistsAsync(voucherCode));

                voucherCodes.Add(voucherCode);
            }
        }
        var invoiceNumber = await _invoiceNumberGenerator.GenerateInvoiceNumberAsync();

        var bookingEntity = BookingFactory.Create(model, voucherCodes, invoiceNumber);
        var result = await _bookingRepository.AddEntityAsync(bookingEntity);
        if (result == false)
            return new BookingServiceResultModel { Success = false, Error = "Failed to create booking." };

        return new BookingServiceResultModel { Success = true, Message = "Booking created successfully." };
    }

    public async Task<IEnumerable<BookingModel>> GetBookingsAsync(string customerId)
    {
        var entities = await _bookingRepository.GetAllAsync(x => x.CustomerId == customerId, query => query.Include(x => x.Tickets));

        if (entities == null || entities.Count() == 0)
            return Enumerable.Empty<BookingModel>();

        return entities.Select(BookingFactory.Create).ToList();
    }
}
