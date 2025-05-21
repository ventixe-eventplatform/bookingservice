using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class TicketEntity
{
    [Column(TypeName = "varchar(36)")]
    [Key]
    public string TicketId { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "nvarchar(50)")]
    public string Type { get; set; } = null!;

    [Column(TypeName = "nvarchar(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string EVoucher { get; set; } = null!;
    public string BookingId { get; set; } = null!;
    [ForeignKey(nameof(BookingId))]
    public BookingEntity Booking { get; set; } = null!;
}

