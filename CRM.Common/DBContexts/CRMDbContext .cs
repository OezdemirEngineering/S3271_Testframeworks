
using CRM.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CRM.Common.DBContexts;

public class CRMDbContext : DbContext
{
    public DbSet<UserDto> Users { get; set; }

    public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options) { }
}
