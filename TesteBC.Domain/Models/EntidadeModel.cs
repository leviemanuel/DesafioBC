using System.ComponentModel.DataAnnotations;

namespace TesteBC.Domain.Models
{
    public class EntidadeModel
    {
        [Key]
        [Required]
        public Guid IdEntidade { get; set; } = new Guid();

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(300, ErrorMessage = "Tamanho máximo é de 300 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlPessoaFisica { get; set; } = true;

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo é de 14 caracteres")]
        public string? Documento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlAtivo { get; set; } = true;

        public virtual ICollection<LancamentoModel>? Lancamentos { get; set; }
    }
}
