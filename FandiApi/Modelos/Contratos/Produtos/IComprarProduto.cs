using FandiApi.Modelos.Entidades.Produtos;

namespace FandiApi.Modelos.Contratos.Produtos;

public interface IComprarProduto
{
    (bool status, string erro) Comprar(Produto produto, int quantidade);
}