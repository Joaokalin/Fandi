namespace FandiApi.Modelos.Entidades.Produtos;

public class Produto
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public decimal Valor_unitario { get; set; }
    
    public int Qtde_estoque { get; set; }
    
    public DateTime? Ultima_venda_em { get; set; }
    
    public DateTime? Ultima_atualizaçao_em { get; set; }
    
    public decimal? Valor_ultima_venda{ get; set; }
}