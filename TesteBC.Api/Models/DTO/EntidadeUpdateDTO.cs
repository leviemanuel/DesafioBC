using System.ComponentModel.DataAnnotations;

namespace TesteBC.Api.Models.DTO
{
    public class EntidadeUpdateDTO
    {
        [Required]
        public Guid IdEntidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(300, ErrorMessage = "Tamanho máximo é de 300 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlPessoaFisica { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Documento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlAtivo { get; set; }
    }
}
