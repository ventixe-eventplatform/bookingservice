using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Column(TypeName = "varchar(36)")]
    public string CustomerId { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; } = null!;

    public string AddressId { get; set; } = null!;
    [ForeignKey(nameof(AddressId))]
    public CustomerAddressEntity Address { get; set; } = null!;
}
