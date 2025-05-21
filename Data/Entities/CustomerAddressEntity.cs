using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerAddressEntity
{
    [Column(TypeName = "varchar(36)")]
    public string AddressId { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "nvarchar(50)")]
    public string StreetName { get; set; } = null!;

    [Column(TypeName = "nvarchar(10)")]
    public string PostalCode { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = null!;
}
