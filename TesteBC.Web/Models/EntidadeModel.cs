using System.ComponentModel.DataAnnotations;

namespace TesteBC.Web.Models
{
    public class EntidadeModel
    {

        public Guid idEntidade { get; set; } = new Guid();

        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string? nome { get; set; }

        [Display(Name = "Pessoa Física", AutoGenerateFilter = false)]
        public bool flPessoaFisica { get; set; }

        [Display(Name = "Tipo", AutoGenerateFilter = false)]
        public string tipoPessoa
        {
            get { return flPessoaFisica? "Física" : "Jurídica"; }   
        }

        [Display(Name = "Documento", AutoGenerateFilter = false)]
        public string? documento { get; set; }

        [Display(Name = "Ativo", AutoGenerateFilter = false)]
        public bool flAtivo { get; set; }
    }
}
