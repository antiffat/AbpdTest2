using System.ComponentModel.DataAnnotations;

namespace Abpd_Test2.Models;

public class Driver
{
    public int Id { get; set; }
    
    [Required, MaxLength(200)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(200)]
    public string LastName { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public int CarId { get; set; }

    public Car Car { get; set; }
    
    public ICollection<DriverCompetition> DriverCompetitions { get; set; }
    
}