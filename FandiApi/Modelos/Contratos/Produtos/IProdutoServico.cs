using FandiApi.Modelos.Entidades.Produtos;

namespace FandiApi.Modelos.Contratos.Produtos;

public interface IProdutoServico
{
    Task<Produto> DetalharAsync(int id);
    
    Task<ProdutoListagem> ListarAsync(ProdutoFiltro filtro);

    Task InserirAsync(Produto produto);

    Task DeletarAsync(Produto produto);

    Task<(bool status, string erro)> ComprarAsync(Produto produto, int quantidade);

    Task<Produto> AtualizarAsync(Produto produto, int id);
}