using System.ComponentModel.DataAnnotations;

namespace TesteBC.Web.Models.Report
{
    public class LancamentoDiarioReportResult
    {
        [Display(Name = "Descrição", AutoGenerateFilter = false)]
        public string descricao { get; set; }

        [Display(Name = "Dt. Vencimento", AutoGenerateFilter = false)]
        public DateTime dtVencimento { get; set; }

        [Display(Name = "Dt. Pagamento", AutoGenerateFilter = false)]
        public DateTime dtPagamento { get; set; }

        public float vlLancamento { get; set; }

        public float vlDesconto { get; set; }

        public float vlJurosMora { get; set; }

        public float vlEncargos { get; set; }

        [Display(Name = "Valor", AutoGenerateFilter = false)]
        public float vlTotal { get; set; }

        public bool flCredito { get; set; }

        [Display(Name = "Entidade", AutoGenerateFilter = false)]
        public string nome { get; set; }
    }
}
