using FandiApi.Modelos.Entidades.Produtos;

namespace FandiApi.Modelos.Contratos.Produtos;

public interface IAtualizarProduto
{
    void Atualizar(Produto produto, int id);
}