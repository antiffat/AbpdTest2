using System.ComponentModel.DataAnnotations;

namespace Abpd_Test2.Models;

public class CarManufacturer
{
    public int Id { get; set; }
    
    [Required, MaxLength(200)]
    public string Name { get; set; }
    
    [ConcurrencyCheck]
    public byte[] RowVersion { get; set; }

    public ICollection<Car> Cars { get; set; }
}