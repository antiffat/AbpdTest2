using Abpd_Test2.DTOs;
using Abpd_Test2.Helpers;
using Abpd_Test2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abpd_Test2.Controllers;

[ApiController]
[Route("api/drivers")]
public class DriverController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DriverController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: api/drivers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DriverDto>>> GetDrivers(CancellationToken cancellationToken,
        [FromQuery] string sortBy = "FirstName")
    {
        var query = _context.Drivers.AsQueryable();

        switch (sortBy.ToLower())
        {
            case "lastname":
                query = query.OrderBy(d => d.LastName);
                break;
            case "birthday":
                query = query.OrderBy(d => d.Birthday);
                break;
            default:
                query = query.OrderBy(d => d.FirstName);
                break;
        }

        var drivers = await query.Select(d => new DriverDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            Birthday = d.Birthday,
            CarId = d.CarId
        }).ToListAsync(cancellationToken);

        return Ok(drivers);
    }
    
    // GET: /api/drivers/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DriverDetailDto>> GetDriverById(int id, CancellationToken cancellationToken)
    {
        var driver = await _context.Drivers
            .Include(d => d.Car)
            .ThenInclude(c => c.CarManufacturer)
            .Where(d => d.Id == id)
            .Select(d => new DriverDetailDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Birthday = d.Birthday,
                CarId = d.CarId,
                CarNumber = d.Car.Number,
                CarManufacturerName = d.Car.CarManufacturer.Name,
                CarModelName = d.Car.ModelName
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (driver == null)
        {
            throw new KeyNotFoundException("Driver not found");
        }

        return driver;
    }
    
    // POST: /api/drivers
    [HttpPost]
    public async Task<ActionResult> CreateDriver([FromBody] CreateDriverDto createDriverDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var driver = new Driver
        {
            FirstName = createDriverDto.FirstName,
            LastName = createDriverDto.LastName,
            Birthday = createDriverDto.Birthday,
            CarId = createDriverDto.CarId
        };
        
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync(cancellationToken);

        var driverDto = new Driver
        {
            Id = driver.Id,
            FirstName = driver.FirstName,
            LastName = driver.LastName,
            Birthday = driver.Birthday,
            CarId = driver.CarId
            
        };

        return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driverDto);
    }
}