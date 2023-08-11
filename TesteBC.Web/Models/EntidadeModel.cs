using System.ComponentModel.DataAnnotations;

namespace TesteBC.Web.Models
{
    public class EntidadeModel
    {

        public Guid idEntidade { get; set; } = new Guid();

        [StringLength(300, ErrorMessage = "Tamanho máximo é de 300 caracteres")]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string? nome { get; set; }

        [Display(Name = "Pessoa Física", AutoGenerateFilter = false)]
        public bool flPessoaFisica { get; set; }

        [Display(Name = "Tipo", AutoGenerateFilter = false)]
        public string tipoPessoa
        {
            get { return flPessoaFisica ? "Física" : "Jurídica"; }
        }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14, ErrorMessage = "Tamanho máximo é de 14 caracteres")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Apenas números")]
        [Display(Name = "Documento", AutoGenerateFilter = false)]
        public string? documento { get; set; }

        [Display(Name = "Ativo", AutoGenerateFilter = false)]
        public bool flAtivo { get; set; }

        public string? errorMessage { get; set; }
    }
}
