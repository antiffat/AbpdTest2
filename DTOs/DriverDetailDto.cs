namespace Abpd_Test2.DTOs;

public class DriverDetailDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public int CarId { get; set; }
    public int CarNumber { get; set; }
    public string CarManufacturerName { get; set; }
    public string CarModelName { get; set; }
}