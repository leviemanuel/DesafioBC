using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBC.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task Adiciona(TEntity obj);
        Task Atualiza(TEntity obj);
        Task Remove(TEntity obj);
        Task<IEnumerable<TEntity>> BuscaTodos();
    }

}
