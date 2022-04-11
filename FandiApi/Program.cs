using FandiApi.Infraestrutura;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();

//conexão Pgsql
services.AddDbContext<ApiDbContext>(options => options.UseNpgsql( builder.Configuration["BaseDeDados:Pgsql"]));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();