using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBC.Domain.Models;

namespace TesteBC.Infrastructure.Repositories.Interfaces
{
    public interface ILancamentoRepository : IRepository<LancamentoModel>
    {
        Task<LancamentoModel> BuscaLancamento(Guid id);
    }
}
