using System.ComponentModel.DataAnnotations;

namespace FandiPaymentMicroservice.Modelos.DTO
{
    public class CartaoDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Titular é requerido")]
        public string Titular { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Numero é requerido")]
        [CreditCard(ErrorMessage = "Número inválido")]
        public string Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Data_expiracao é requerido")]
        public string Data_expiracao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Bandeira é requerido")]
        public string Bandeira { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Cvv é requerido")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O tamanho do Cvv é de 3 caracteres")]
        public string Cvv { get; set; }
    }
}
