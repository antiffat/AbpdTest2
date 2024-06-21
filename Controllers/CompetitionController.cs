using Abpd_Test2.Helpers;
using Abpd_Test2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abpd_Test2.DTOs;

namespace Abpd_Test2.Controllers;

[ApiController]
[Route("api/competitions")]
public class CompetitionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompetitionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/competitions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompetitionDto>>> GetCompetitions(CancellationToken cancellationToken)
    {
        var competitions = await _context.Competitions
            .Select(c => new CompetitionDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync(cancellationToken);

        return Ok(competitions);
    }

    // GET: api/competitions/driver-competitions
    [HttpGet("driver-competitions")]
    public async Task<ActionResult<IEnumerable<CompetitionDto>>> GetDriverCompetitions(CancellationToken cancellationToken)
    {
        var driverCompetitions = await _context.DriverCompetitions
            .Include(dc => dc.Competition)
            .Select(dc => new CompetitionDto
            {
                Id = dc.Competition.Id,
                Name = dc.Competition.Name,
                Date = dc.Date
            })
            .ToListAsync(cancellationToken);

        return Ok(driverCompetitions);
    }

    // POST: api/driver/competitions
    [HttpPost("assign-driver")]
    public async Task<ActionResult> AssignDriverToCompetition([FromBody] DriverCompetitionAssignmentDto assignmentDto, CancellationToken cancellationToken)
    {
        var driverCompetition = new DriverCompetition
        {
            DriverId = assignmentDto.DriverId,
            CompetitionId = assignmentDto.CompetitionId,
            Date = DateTime.UtcNow
        };

        _context.DriverCompetitions.Add(driverCompetition);
        await _context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}
