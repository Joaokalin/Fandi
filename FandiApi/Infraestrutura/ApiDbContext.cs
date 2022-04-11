using Microsoft.EntityFrameworkCore;

namespace FandiApi.Infraestrutura;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
}