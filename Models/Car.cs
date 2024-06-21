using System.ComponentModel.DataAnnotations;

namespace Abpd_Test2.Models;

public class Car
{
    public int Id { get; set; }
    
    public int CarManufacturerId { get; set; }
    
    [Required, MaxLength(200)]
    public string ModelName { get; set; }
    
    public int Number { get; set; }
    
    [ConcurrencyCheck]
    public byte[] RowVersion { get; set; }
    
    public CarManufacturer CarManufacturer { get; set; }
    
    public ICollection<Driver> Drivers { get; set; }
}