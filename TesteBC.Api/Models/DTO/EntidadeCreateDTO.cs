using System.ComponentModel.DataAnnotations;

namespace TesteBC.Api.Models.DTO
{
    public class EntidadeCreateDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(300, ErrorMessage = "Tamanho máximo é de 300 caracteres")]
        public string? Nome { get; set; } 

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlPessoaFisica { get; set; } = true;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14, ErrorMessage = "Tamanho máximo é de 14 caracteres")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage ="Apenas números")]
        public string? Documento { get; set; } = null;

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlAtivo { get; set; } = true;
    }
}
