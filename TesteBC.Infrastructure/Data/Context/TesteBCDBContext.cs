using Microsoft.EntityFrameworkCore;
using TesteBC.Domain.Models;

namespace TesteBC.Infrastructure.Data.Context
{
    public class TesteBCDBContext : DbContext
    {
        public TesteBCDBContext(DbContextOptions<TesteBCDBContext> opts) : base(opts)
        {

        }

        public DbSet<LancamentoModel> Lancamentos { get; set; }
        public DbSet<EntidadeModel> Entidades { get; set; }
    }
}
