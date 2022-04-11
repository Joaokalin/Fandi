using FandiApi.Modelos.Entidades.Produtos;

namespace FandiApi.Modelos.Contratos.Produtos;

public interface IProdutoServico
{
    Task InserirAsync(Produto produto);

    Task<ProdutoListagem> ListarAsync(ProdutoFiltro filtro);
}