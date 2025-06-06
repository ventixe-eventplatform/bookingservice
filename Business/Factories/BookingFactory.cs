using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class BookingFactory
{
    public static BookingEntity Create(CreateBookingModel model, List<string> codes, string invoiceNumber)
    {
        int codeIndex = 0;

        return new BookingEntity
        {
            EventId = model.EventId,
            EventName = model.EventName,
            BookingDate = DateTime.Now,
            CustomerId = model.CustomerId,
            Invoice = new InvoiceEntity
            {
                InvoiceNumber = invoiceNumber,
                Created = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(30),
                Amount = model.Invoice!.Amount,
                Status = false,
            },
            Tickets = model.Tickets.SelectMany(t => Enumerable.Range(0, t.Quantity).Select(_ => new TicketEntity
            {
                HolderFirstName = t.HolderFirstName,
                HolderLastName = t.HolderLastName,
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
            BookingDate = entity.BookingDate,
            Tickets = entity.Tickets.Select(x => new TicketModel
            {
                Id = x.TicketId,
                Type = x.Type,
                Price = x.Price,
                EVoucher = x.EVoucher,
                HolderFirstName= x.HolderFirstName,
                HolderLastName= x.HolderLastName,
            }).ToList()
        };
    }
}
