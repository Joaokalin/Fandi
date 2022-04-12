using FandiApi.Modelos.Contratos.Produtos;

namespace FandiApi.Modelos.Entidades.Produtos;

public class AtualizarProduto : IAtualizarProduto
{
    public void Atualizar(Produto produto, int id)
    {
        produto.Id = id;
        produto.Ultima_atualizaçao_em = DateTime.Now;
    }
}