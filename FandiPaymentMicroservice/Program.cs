using FandiPaymentMicroservice.Modelos.DTO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UsePathBase("/api");
app.UseRouting();

app.MapPost("/pagamentos", (PagamentoDto pagamentoDto) =>
{
    if (pagamentoDto.Valor > 100) return Results.Ok(new {Estado = "Aprovado", pagamentoDto.Valor});
    return Results.UnprocessableEntity(new { Estado = "Reprovado", pagamentoDto.Valor });
});

app.Run();

