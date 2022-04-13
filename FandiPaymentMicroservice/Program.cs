var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapPost("/pagamentos", (decimal valor) =>
{
    if (valor > 100) Results.Ok("Aprovado");
    Results.UnprocessableEntity("Reprovado");
});

app.Run();

