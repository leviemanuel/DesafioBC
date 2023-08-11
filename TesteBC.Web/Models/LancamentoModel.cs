using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TesteBC.Web.Models
{
    public class LancamentoModel
    {

        public Guid idLancamento { get; set; } = new Guid();

        [Display(Name = "Descrição", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 300 caracteres")]
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
            set
            { if (vlLancamento != decimal.Parse(value)) vlLancamento = decimal.Parse(value.Replace(",", ".").Replace(".", ",")); }
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
        [StringLength(48, ErrorMessage = "Tamanho máximo é de 48 caracteres")]
        public string? codBarras { get; set; }

        [Display(Name = "Instituição Emissora", AutoGenerateFilter = false)]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string? instituicaoEmissora { get; set; }

        [Display(Name = "Agência", AutoGenerateFilter = false)]
        [StringLength(10, ErrorMessage = "Tamanho máximo é de 10 caracteres")]
        public string? agencia { get; set; }

        [Display(Name = "Conta Corrente", AutoGenerateFilter = false)]

        [StringLength(20, ErrorMessage = "Tamanho máximo é de 20 caracteres")]
        public string? contaCorrente { get; set; }

        [Required]
        [Display(Name = "Entidade", AutoGenerateFilter = false)]
        public Guid entidadeId { get; set; }

        public string? entidadeNome { get; set; } = "";

        public IEnumerable<SelectListItem>? entidades { get; set; } = null;

        public string? errorMessage { get; set; }
    }
}
