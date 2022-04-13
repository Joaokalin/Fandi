using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.DTOS.Produtos;

namespace FandiApi.Modelos.Entidades.Produtos;

public class AtualizarProduto : IAtualizarProduto
{
    public void Atualizar(Produto produto, ProdutoDto produtoDto, int id)
    {
        produto.Id = id;
        produto.Ultima_atualizaçao_em = DateTime.Now;
        produto.Qtde_estoque = produtoDto.Qtde_estoque;
        produto.Nome = produtoDto.Nome;
        produto.Valor_unitario = produtoDto.Valor_unitario;
    }
}