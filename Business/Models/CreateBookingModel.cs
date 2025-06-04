namespace Business.Models;

public class CreateBookingModel
{
    public string CustomerId { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public string EventName { get; set; } = null!;
    public CreateInvoiceModel? Invoice { get; set; }
    public ICollection<CreateTicketModel> Tickets { get; set; } = new List<CreateTicketModel>();
}
