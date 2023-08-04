using System.ComponentModel.DataAnnotations;

namespace TesteBC.Web.Models.Report
{
    public class LancamentoDiarioReport
    {
        [Display(Name = "Dt. Pagamento", AutoGenerateFilter = false)]
        [DataType(DataType.Date)]
        public DateTime dtPagamento { get; set; }

        public IEnumerable<TesteBC.Web.Models.Report.LancamentoDiarioReportResult> LancamentosDiarios { get; set; }
    }
}
