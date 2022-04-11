namespace FandiApi.Modelos.Entidades.Produtos;

public class ProdutoListagem
{
    public IEnumerable<Produto> Produtos { get; set; }
    public long Quantidade { get; set; }
}