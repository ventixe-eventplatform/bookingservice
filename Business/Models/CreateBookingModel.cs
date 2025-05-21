namespace Business.Models;

public class CreateBookingModel
{
    public string EventId { get; set; } = null!;
    public string EventName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public IEnumerable<CreateTicketModel> Tickets { get; set; } = new List<CreateTicketModel>();
}
