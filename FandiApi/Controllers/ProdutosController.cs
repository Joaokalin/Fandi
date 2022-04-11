using FandiApi.Modelos.Contratos.Produtos;
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

        if (produto == null) return NotFound();
        return Ok(produto);
    }
}