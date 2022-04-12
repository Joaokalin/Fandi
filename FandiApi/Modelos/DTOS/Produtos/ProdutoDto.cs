using System.ComponentModel.DataAnnotations;
using FandiApi.Modelos.Entidades.Produtos;

namespace FandiApi.Modelos.DTOS.Produtos;

public class ProdutoDto
{
    [Required(AllowEmptyStrings=false, ErrorMessage = "O campo Nome é requerido")]
    [StringLength(60, ErrorMessage = "O tamanho máximo de caracteres é 60")]
    private string Nome { get; set; }

    [Required (ErrorMessage = "O campo Valor_unitario é requerido")]
    private decimal Valor_unitario { get; set; }

    [Required (ErrorMessage = "O campo Qtde_estoque é requerido")]
    private int Qtde_estoque { get; set; }

    public Produto Map() => new Produto
    {
        Nome = Nome,
        Valor_unitario = Valor_unitario,
        Qtde_estoque = Qtde_estoque
    };
}