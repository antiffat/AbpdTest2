using System.ComponentModel.DataAnnotations;

namespace Abpd_Test2.Models;

public class DriverCompetition
{
    public int DriverId { get; set; }
    
    public int CompetitionId { get; set; }
    
    public DateTime Date { get; set; }
    
    [ConcurrencyCheck]
    public byte[] RowVersion { get; set; }

    public Driver Driver { get; set; }
    
    public Competition Competition { get; set; }
}