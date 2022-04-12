using FandiApi.Infraestrutura;
using FandiApi.Integracoes.Microservicos;
using FandiApi.Integracoes.MicroservicosOpcoes;
using FandiApi.Modelos.Contratos.Compras;
using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();


services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
services.AddTransient<IRealizarCompra, RealizarCompra>();

//conexão Pgsql
services.AddDbContext<ApiDbContext>(options => options
    .UseNpgsql(builder.Configuration["BaseDeDados:Pgsql"], pgsql => { pgsql.EnableRetryOnFailure(); }));

services.AddSingleton(builder.Configuration);

services.AddHttpClient<PagamentoMicroservicoClient>();
services.Configure<MicroservicoOpcoes>(builder.Configuration.GetSection("Integracoes:Microservicos"));


var app = builder.Build();

app.UsePathBase("/api");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();