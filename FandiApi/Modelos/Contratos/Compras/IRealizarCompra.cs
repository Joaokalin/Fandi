using FandiApi.Modelos.DTOS.Compras;

namespace FandiApi.Modelos.Contratos.Compras;

public interface IRealizarCompra
{
    Task<(bool status, string erro)> ComprarAsync(CompraDto compraDto);
}