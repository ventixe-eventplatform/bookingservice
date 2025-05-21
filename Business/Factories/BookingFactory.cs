using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class BookingFactory
{
    public static BookingEntity Create(CreateBookingModel model, List<string> codes)
    {
        int codeIndex = 0;

        return new BookingEntity
        {
            EventId = model.EventId,
            EventName = model.EventName,
            BookingDate = DateTime.UtcNow,
            Customer = new CustomerEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = new CustomerAddressEntity
                {
                    StreetName = model.StreetName,
                    PostalCode = model.PostalCode,
                    City = model.City
                }
            },
            Tickets = model.Tickets.SelectMany(t => Enumerable.Range(0, t.Quantity).Select(_ => new TicketEntity
            {
                Type = t.Type,
                Price = t.Price,
                EVoucher = codes[codeIndex++]
            })).ToList()
        };
    }

    public static BookingModel Create(BookingEntity entity)
    {
        return new BookingModel
        {
            BookingId = entity.BookingId,
            EventId = entity.EventId,
            EventName = entity.EventName,
            Tickets = entity.Tickets.Select(x => new TicketModel
            {
                Id = x.TicketId,
                Type = x.Type,
                Price = x.Price,
                EVoucher = x.EVoucher,
            }).ToList()
        };
    }
}
