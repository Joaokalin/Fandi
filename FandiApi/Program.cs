using FandiApi.Infraestrutura;
using FandiApi.Integracoes.MicroservicosOpcoes;
using FandiApi.Modelos.Contratos.Compras;
using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();

//conexão Pgsql
services.AddDbContext<ApiDbContext>(options => options.UseNpgsql( builder.Configuration["BaseDeDados:Pgsql"]));

services.AddTransient<IProdutoServico, ProdutoServico>();
services.AddTransient<ICompraServico, CompraServico>();

services.Configure<MicroservicoOpcoes>(builder.Configuration.GetSection("Integracoes:Microservicos"));
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();