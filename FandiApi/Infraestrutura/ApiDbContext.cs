using FandiApi.Modelos.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;

namespace FandiApi.Infraestrutura;

public class ApiDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
}