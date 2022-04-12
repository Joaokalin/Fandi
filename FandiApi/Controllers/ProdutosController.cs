using FandiApi.Modelos.Contratos.Produtos;
using FandiApi.Modelos.DTOS.Produtos;
using FandiApi.Modelos.Entidades.Produtos;
using Microsoft.AspNetCore.Mvc;

namespace FandiApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Listar([FromQuery] ProdutoFiltro filtro, [FromServices] IProdutoServico servico)
    {
        var produtoListagem = await servico.ListarAsync(filtro);
        return Ok(produtoListagem);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detalhar([FromRoute] int id, [FromServices] IProdutoServico servico)
    {
        var produto = await servico.DetalharAsync(id);

        if (produto == null) return NotFound("Ocorreu um erro desconhecido");
        return Ok(produto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] ProdutoDto produtoDto, [FromServices] IProdutoServico servico)
    {
        await servico.InserirAsync(produtoDto.Map());
        return Ok("Produto cadastrado");
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Deletar([FromRoute] int id, [FromServices] IProdutoServico servico)
    {
        var produtoDetalhado = await servico.DetalharAsync(id);
        if (produtoDetalhado == null) return BadRequest("Ocorreu um erro desconhecido");

        await servico.DeletarAsync(produtoDetalhado);
        return Ok("Produto excluído com sucesso");
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] ProdutoDto produtoDTO, [FromServices] IProdutoServico servico)
    {
        var produtoDetalhado = await servico.DetalharAsync(id);
        if (produtoDetalhado == null) return NotFound("Ocorreu um erro desconhecido");

        var produto = produtoDTO.Map();
        return Ok(await servico.AtualizarAsync(produto, id));
    }

}