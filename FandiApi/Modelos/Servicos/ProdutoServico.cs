using FandiApi.Infraestrutura;
using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;

namespace FandiApi.Modelos.Servicos;

public class ProdutoServico : IProdutoServico
{
    private readonly ApiDbContext _apiDbContext;

    public ProdutoServico(ApiDbContext apiDbContext)
    {
        _apiDbContext = apiDbContext;
    }
    
    public async Task<Produto> DetalharAsync(int id)
        => await _apiDbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    
    public async Task<ProdutoListagem> ListarAsync(ProdutoFiltro filtro)
    {
        var produtoConsulta = _apiDbContext.Produtos
            .OndeNome(filtro.Nome);

        var quantidade = produtoConsulta.LongCount();
        var produtos = await produtoConsulta.Skip(filtro.Indice).Take(filtro.Tamanho).ToListAsync();

        return new ProdutoListagem() {Quantidade = quantidade, Produtos = produtos};
    }
    
    public async Task InserirAsync(Produto produto)
    {
        await _apiDbContext.Produtos.AddAsync(produto);
        await _apiDbContext.SaveChangesAsync();
    }
    
    public async Task DeletarAsync(Produto produto)
    {
        _apiDbContext.Produtos.Remove(produto);
        await _apiDbContext.SaveChangesAsync();
    }
    
}