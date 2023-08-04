namespace TesteBC.Api.Models.DTO
{
    public class EntidadeReadDTO
    {
        public Guid idEntidade { get; set; }
        public string? Nome { get; set; }
        public bool FlPessoaFisica { get; set; }
        public string? Documento { get; set; }
        public bool FlAtivo { get; set; }
    }
}
