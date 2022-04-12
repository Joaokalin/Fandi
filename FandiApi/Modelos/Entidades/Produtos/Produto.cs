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

    public (bool status, string erro) Comprar(int quantidade)
    {
        if(Qtde_estoque - 1 < 0) return (false, $"quantidade em estoque insuficiente, só tem {Qtde_estoque} no estoque");
        
        Ultima_venda_em = DateTime.Now;
        Valor_ultima_venda =  Valor_unitario * quantidade;
        Qtde_estoque -= quantidade;
        return (true, string.Empty);
    }

    public void Atualizar(int id)
    {
        Id = id;
        Ultima_atualizaçao_em = DateTime.Now;
    }
}