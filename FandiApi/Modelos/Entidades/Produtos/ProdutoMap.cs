using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FandiApi.Modelos.Entidades.Produtos;

public static class ProdutoMap
{
    public static void Map(this EntityTypeBuilder<Produto> entity)
    {
        entity.ToTable("Produto");

        entity.HasKey(p => p.Id);
        entity.Property(p => p.Nome).IsRequired();
        entity.Property(p => p.Qtde_estoque).IsRequired();
        entity.Property(p => p.Valor_unitario).IsRequired();
        entity.Property(p => p.Ultima_venda_em);
        entity.Property(p => p.Valor_ultima_venda);
        entity.Property(p => p.Ultima_atualizaçao_em);
    }
}