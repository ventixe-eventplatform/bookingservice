namespace Business.Models;

public class CreateTicketModel
{    
    public string HolderFirstName { get; set; } = null!;
    public string HolderLastName { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

