namespace Business.Models;

public class BookingServiceResultModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
    public bool? Data { get; set; }
}
