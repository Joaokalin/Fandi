using FandiApi.Integracoes.MicroservicosOpcoes;
using FandiApi.Integracoes.Modelos.Pagamento;
using Microsoft.Extensions.Options;

namespace FandiApi.Integracoes.Microservicos;

public class PagamentoMicroservicoClient : MicroservicoBaseClient
{
    public PagamentoMicroservicoClient(HttpClient client, IOptions<MicroservicoOpcoes> opcoes) : base(client,
        opcoes.Value.Pagamento)
    {
    }

    public async Task<(bool status, string erro)> ValidarAsync(PagamentoDto pagamentoDto)
    {
        var (status, error, _) = await EnviarSolicitacaoAsync<string>(HttpMethod.Post, "compras", ConstruirCorpoSolicitacao(pagamentoDto));
        return (status, error);
    }
}
