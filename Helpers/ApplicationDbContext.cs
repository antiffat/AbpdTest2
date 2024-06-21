using Microsoft.EntityFrameworkCore;

namespace Abpd_Test2.Helpers;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    
}