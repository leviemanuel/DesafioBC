namespace TesteBC.Api.Models.DTO
{
    public class LancamentoReadDTO
    {
        public Guid IdLancamento { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtVencimento { get; set; }
        public DateTime DtPagamento { get; set; }
        public decimal VlLancamento { get; set; }
        public decimal VlDesconto { get; set; }
        public decimal VlJurosMora { get; set; }
        public decimal VlEncargos { get; set; }
        public decimal VlTotal { get; set; }
        public bool FlCredito { get; set; }
        public string? CodBarras { get; set; }
        public string? InstituicaoEmissora { get; set; }
        public string? Agencia { get; set; }
        public string? ContaCorrente { get; set; }
        public Guid EntidadeId { get; set; }

    } 
}
