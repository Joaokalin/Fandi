using System.ComponentModel.DataAnnotations;

namespace FandiApi.Modelos.DTOS.Compras;

public class CompraDto
{
    [Required]
    public int Produto_Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Qtde_comprada { get; set; }

    [Required]
    public CartaoDto Cartao { get; set; } 
}