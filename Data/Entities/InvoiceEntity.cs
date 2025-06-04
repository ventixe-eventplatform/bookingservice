using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class InvoiceEntity
{
    [Key]
    public int Id { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime ExpiryDate {  get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
    public bool Status { get; set; }

    [ForeignKey(nameof(Booking))]
    public string BookingId { get; set; } = null!;
    public BookingEntity? Booking { get; set; }
}
