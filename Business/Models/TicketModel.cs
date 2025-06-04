namespace Business.Models;

public class TicketModel
{
    public string Id { get; set; } = null!;
    public string HolderFirstName { get; set; } = null!;
    public string HolderLastName { get; set; } = null!;
    public string Type { get; set; } = null!;
    public decimal Price { get; set; }
    public string EVoucher { get; set; } = null!;
    public string BookingId { get; set; } = null!;
    public BookingModel BookingModel { get; set; } = null!;
}
