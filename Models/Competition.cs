using System.ComponentModel.DataAnnotations;

namespace Abpd_Test2.Models;

public class Competition
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(200)]
    public string Name { get; set; }
    
    [ConcurrencyCheck]
    public byte[] RowVersion { get; set; }

    public ICollection<DriverCompetition> DriverCompetitions { get; set; }
}