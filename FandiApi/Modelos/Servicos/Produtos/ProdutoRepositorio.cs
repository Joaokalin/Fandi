using FandiApi.Infraestrutura;
using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.DTOS.Produtos;
using FandiApi.Modelos.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;

namespace FandiApi.Modelos.Servicos;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly ApiDbContext _apiDbContext;

    public ProdutoRepositorio(ApiDbContext apiDbContext)
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
    
    public async Task<(bool status, string erro)> ComprarAsync(Produto produto, int quantidade)
    {
        var comprar = new ComprarProduto().Comprar(produto, quantidade);
        if (!comprar.status) return comprar;
        
        _apiDbContext.Produtos.Update(produto);
        await _apiDbContext.SaveChangesAsync();

        return (true, string.Empty);
    }

    public async Task<Produto> AtualizarAsync(Produto produto, ProdutoDto produtoDto, int id)
    {
        new AtualizarProduto().Atualizar(produto, produtoDto, id);
        
        _apiDbContext.Produtos.Update(produto);
        await _apiDbContext.SaveChangesAsync();
        return produto;
    }

}