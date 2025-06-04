using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class BookingEntity
{
    [Column(TypeName = "varchar(36)")]
    [Key]
    public string BookingId { get; set; } = Guid.NewGuid().ToString();
    public string CustomerId { get; set; } = null!;

    [Column(TypeName = "varchar(36)")]
    public string EventId { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(50)")]
    public string EventName { get; set; } = null!;
    
    public DateTime BookingDate { get; set; } = DateTime.Now;
    
    public InvoiceEntity? Invoice { get; set; }
    public ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
}