using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class BookingEntity
{
    [Column(TypeName = "varchar(36)")]
    [Key]
    public string BookingId { get; set; } = Guid.NewGuid().ToString();
    [Column(TypeName = "varchar(36)")]
    public string EventId { get; set; } = null!;
    public string EventName { get; set; } = null!;
    public DateTime BookingDate { get; set; } = DateTime.Now;
    public string CustomerId { get; set; } = null!;
    [ForeignKey(nameof(CustomerId))]
    public CustomerEntity Customer { get; set; } = null!;
    public ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
}