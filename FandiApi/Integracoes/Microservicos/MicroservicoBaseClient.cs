using System.Text;
using FandiApi.Integracoes.MicroservicosOpcoes;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace FandiApi.Integracoes.Microservicos;

public class MicroservicoBaseClient
{
    protected readonly HttpClient _client;
    public MicroservicoBaseClient(HttpClient client, MicroservicoBaseOpcoes opcoes)
    {
        client.BaseAddress = new Uri(opcoes.EnderecoBase);
        _client = client;
    }

    protected StringContent ConstruirCorpoSolicitacao(object corpo)
    {
        var corpoSerializado = JsonConvert.SerializeObject(corpo);
        return new StringContent(corpoSerializado, Encoding.UTF8, "application/json");
    }

    protected async Task<(bool status, string erro, T corpo)> EnviarSolicitacaoAsync<T>(HttpMethod metodo, string endpoint, HttpContent conteudoHttp = null, IDictionary<string, string> parametrosRota = null)
    {
        if (parametrosRota != null) endpoint = QueryHelpers.AddQueryString(endpoint, parametrosRota);

        var mensageSolicitacao = new HttpRequestMessage(metodo, endpoint) { Content = conteudoHttp };
        var mensagemResposta = new HttpResponseMessage();
        var conteudoResposta = string.Empty;

        try
        {
            mensagemResposta = await _client.SendAsync(mensageSolicitacao);
            conteudoResposta = await mensagemResposta.Content.ReadAsStringAsync();
            mensagemResposta.EnsureSuccessStatusCode();

            if (typeof(T) == typeof(bool)) return (true, string.Empty, (T)(object)true);
            return (true, string.Empty, JsonConvert.DeserializeObject<T>(conteudoResposta));
        }
        catch (Exception)
        {
            var erro = conteudoResposta.Substring(0, Math.Min(conteudoResposta.Length, 100));

            return (false, erro , default);
        }
    }
}