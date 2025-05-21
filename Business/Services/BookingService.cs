using System;
using Business.Factories;
using Business.Helpers;
using Business.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class BookingService(BookingRepository bookingRepository) : IBookingService
{
    private readonly BookingRepository _bookingRepository = bookingRepository;

    public async Task<int> CreateBookingAsync(CreateBookingModel model)
    {
        var codes = new List<string>();

        foreach (var ticket in model.Tickets)
        {
            string voucherCode;
            var random = new Random();

            do
            {
                voucherCode = random.Next(100000, 999999).ToString();
            } while (await _bookingRepository.VoucherCodeExistsAsync(voucherCode));

            codes.Add(voucherCode);
        }

        var bookingEntity = BookingFactory.Create(model, codes);
        var result = await _bookingRepository.AddEntityAsync(bookingEntity);
        if (result == false)
            return 500;

        return 201;
    }

    public async Task<IEnumerable<BookingModel>> GetBookingsAsync(string customerId)
    {
        var entities = await _bookingRepository.GetAllAsync(x => x.CustomerId == customerId, query => query.Include(x => x.Tickets));

        if (entities == null || entities.Count() == 0)
            return Enumerable.Empty<BookingModel>();

        return entities.Select(BookingFactory.Create).ToList();
    }
}
