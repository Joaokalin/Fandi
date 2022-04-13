using System.ComponentModel.DataAnnotations;

namespace FandiPaymentMicroservice.Modelos.DTO
{
    public class PagamentoDto
    {
        [Required(ErrorMessage = "O valor tem que ser informado")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Os dados do cartão têm que ser informados")]
        public CartaoDto Cartao { get; set; }
    }
}
