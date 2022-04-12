using FandiApi.Modelos.DTOS.Compras;

namespace FandiApi.Modelos.Contratos.Compras;

public interface ICompraServico
{
    Task<(bool status, string erro)> ComprarAsync(CompraDto compraDto);
}