using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TesteBC.Web.Models
{
    public class LancamentoModel
    {

        public Guid idLancamento { get; set; } = new Guid();

        [Display(Name = "Descrição", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(300, ErrorMessage = "Tamanho máximo é de 300 caracteres")]
        public string? descricao { get; set; }

        [Display(Name = "Dt. Vencimento", AutoGenerateFilter = false)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime dtVencimento { get; set; }

        [Display(Name = "Dt. Pagamento", AutoGenerateFilter = false)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime dtPagamento { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vl. Lançamento", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal vlLancamento { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vl. Lançamento", AutoGenerateFilter = false)]
        public string vlLancamento_ptbr
        {
            get { return vlLancamento.ToString("#,##0.00"); }
            set { vlLancamento = decimal.Parse(value.Replace(",", ".").Replace(".", ",")); }
        }

        [Display(Name = "Vl. Desconto", AutoGenerateFilter = false)]
        public decimal vlDesconto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vl. Desconto", AutoGenerateFilter = false)]
        public string vlDesconto_ptbr
        {
            get { return vlDesconto.ToString("#,##0.00"); }
            set { vlDesconto = decimal.Parse(value.Replace(",", ".").Replace(".", ",")); }
        }

        [Display(Name = "Vl. Juros/Mora", AutoGenerateFilter = false)]
        public decimal vlJurosMora { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vl. Juros/Mora", AutoGenerateFilter = false)]
        public string vlJurosMora_ptbr
        {
            get { return vlJurosMora.ToString("#,##0.00"); }
            set { vlJurosMora = decimal.Parse(value.Replace(",", ".").Replace(".", ",")); }
        }

        [Display(Name = "Vl. Encargos", AutoGenerateFilter = false)]
        public decimal vlEncargos { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vl. Encargos", AutoGenerateFilter = false)]
        public string vlEncargos_ptbr
        {
            get { return vlEncargos.ToString("#,##0.00"); }
            set { vlEncargos = decimal.Parse(value.Replace(",", ".").Replace(".", ",")); }
        }

        [Display(Name = "Fl. Crédito", AutoGenerateFilter = false)]
        public bool flCredito { get; set; }

        [Display(Name = "Código de Barras", AutoGenerateFilter = false)]
        public string? codBarras { get; set; }

        [Display(Name = "Instituição Emissora", AutoGenerateFilter = false)]
        public string? instituicaoEmissora { get; set; }

        [Display(Name = "Agência", AutoGenerateFilter = false)]
        public string? agencia { get; set; }

        [Display(Name = "Conta Corrente", AutoGenerateFilter = false)]
        public string? contaCorrente { get; set; }

        [Display(Name = "Entidade", AutoGenerateFilter = false)]
        public Guid entidadeId { get; set; }

        [Required]
        [Display(Name = "Entidade", AutoGenerateFilter = false)]
        public string entidadeNome { get; set; }

        public IEnumerable<SelectListItem> entidades { get; set;}
    }
}
