using System.ComponentModel.DataAnnotations;

namespace TesteBC.Api.Models.DTO
{
    public class LancamentoUpdateDTO
    {
        [Required]
        public Guid IdLancamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
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
        public bool FlCredito { get; set; } = true;

        [StringLength(48, ErrorMessage = "Tamanho máximo é de 48 caracteres")]
        public string? CodBarras { get; set; } = null;

        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string? InstituicaoEmissora { get; set; } = null;

        [StringLength(10, ErrorMessage = "Tamanho máximo é de 10 caracteres")]
        public string? Agencia { get; set; } = null;

        [StringLength(20, ErrorMessage = "Tamanho máximo é de 20 caracteres")]
        public string? ContaCorrente { get; set; } = null;

        [Required]
        public Guid EntidadeId { get; set; }
    }
}
