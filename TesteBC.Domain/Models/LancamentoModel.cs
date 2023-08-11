using System.ComponentModel.DataAnnotations;

namespace TesteBC.Domain.Models
{
    public class LancamentoModel
    {
        [Key]
        [Required]
        public Guid IdLancamento { get; set; } = new Guid();

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DtVencimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DtPagamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal VlLancamento { get; set; } = 0;

        public decimal VlDesconto { get; set; } = 0;

        public decimal VlJurosMora { get; set; } = 0;

        public decimal VlEncargos { get; set; } = 0;

        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal VlTotal { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FlCredito { get; set; }

        [MaxLength(48, ErrorMessage = "Tamanho máximo é de 48 caracteres")]
        public string? CodBarras { get; set; } = null;

        [MaxLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string? InstituicaoEmissora { get; set; } = null;

        [MaxLength(10, ErrorMessage = "Tamanho máximo é de 10 caracteres")]
        public string? Agencia { get; set; } = null;

        [MaxLength(20, ErrorMessage = "Tamanho máximo é de 20 caracteres")]
        public string? ContaCorrente { get; set; } = null;

        [Required]
        public Guid EntidadeId { get; set; }

        public virtual EntidadeModel Entidade { get; set; }
    }
}
