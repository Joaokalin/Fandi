using FandiApi.Modelos.Contratos.Compras;
using FandiApi.Modelos.DTOS.Compras;
using Microsoft.AspNetCore.Mvc;

namespace FandiApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ComprasController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Comprar([FromBody] CompraDto compraDto, [FromServices] ICompraServico compraServico)
    {
        var (status, erro) = await compraServico.ComprarAsync(compraDto);
        if (!status) return BadRequest(erro);
        
        return Ok();
    }

}
