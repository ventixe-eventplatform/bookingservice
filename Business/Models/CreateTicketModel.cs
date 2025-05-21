namespace Business.Models;

public class CreateTicketModel
{
    public string Type { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string BookingId { get; set; } = null!;
    public CreateBookingModel BookingModel { get; set; } = null!;
}
