using FandiApi.Modelos.Contratos.Produtos;

namespace FandiApi.Modelos.Entidades.Produtos;

public class ComprarProduto : IComprarProduto
{
    public (bool status, string erro) Comprar(Produto produto, int quantidade)
    {
        if(produto.Qtde_estoque - 1 < 0) return (false, $"quantidade em estoque insuficiente, só tem {produto.Qtde_estoque} no estoque");
        
        produto.Ultima_venda_em = DateTime.Now;
        produto.Valor_ultima_venda =  produto.Valor_unitario * quantidade;
        produto.Qtde_estoque -= quantidade;
        return (true, string.Empty);
    }
}