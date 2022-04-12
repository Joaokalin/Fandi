using FandiApi.Integracoes.Microservicos;
using FandiApi.Integracoes.Modelos.Pagamento;
using FandiApi.Modelos.Contratos.Compras;
using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.DTOS.Compras;

namespace FandiApi.Modelos.Servicos;

public class RealizarCompra : IRealizarCompra
{
    private readonly PagamentoMicroservicoClient _pagamentoClient;
    private readonly IProdutoRepositorio _produtoServico;
    public RealizarCompra(PagamentoMicroservicoClient pagamentoClient, IProdutoRepositorio produtoServico)
    {
        _pagamentoClient = pagamentoClient;
        _produtoServico = produtoServico;
    }

    public async Task<(bool status, string erro)> ComprarAsync(CompraDto compraDto)
    {
        var produto = await _produtoServico.DetalharAsync(compraDto.Produto_Id);
        if (produto == null) return (false, "Produto não encontrado");

        PagamentoDto pagamento = new() {Valor = compraDto.Qtde_comprada * produto.Valor_unitario};
        
        var (compraSucesso, _) =  await ValidarCompraAsync(pagamento);
        if (!compraSucesso) return (false, "Compra não aprovada");

        var (sucesso, erro) = await _produtoServico.ComprarAsync(produto, compraDto.Qtde_comprada);
        if (!sucesso) return (false, erro);

        return (true, string.Empty);
    }
    
    private async Task<(bool status, string erro)> ValidarCompraAsync(PagamentoDto pagamentoDto)
        => await _pagamentoClient.ValidarAsync(pagamentoDto);
}