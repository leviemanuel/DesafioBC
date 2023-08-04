namespace TesteBC.Domain.Models
{
    public  class LancamentosDiarioModel
    {
        public string? Descricao { get; set; }
        public DateTime DtVencimento { get; set; }
        public DateTime DtPagamento { get; set; }
        public decimal VlLancamento { get; set; }
        public decimal VlDesconto { get; set; }
        public decimal VlJurosMora { get; set; }
        public decimal VlEncargos { get; set; }
        public decimal VlTotal { get; set; }
        public bool FlCredito { get; set; }
        public string? Nome { get; set; }
    }
}
