namespace Business.Models;

public class BookingModel
{
    public string BookingId { get; set; } = Guid.NewGuid().ToString();
    public string EventId { get; set; } = null!;
    public string EventName { get; set; } = null!;
    public DateTime BookingDate { get; set; }
    public ICollection<TicketModel> Tickets { get; set; } = new List<TicketModel>();
}
