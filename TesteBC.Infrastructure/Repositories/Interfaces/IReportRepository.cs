using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBC.Domain.Models;

namespace TesteBC.Infrastructure.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<LancamentoModel>> GetReportLancamentoDiarios(DateTime date) ;
    }
}
