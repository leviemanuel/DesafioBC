using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Data.Context;
using TesteBC.Infrastructure.Repositories.Interfaces;

namespace TesteBC.Infrastructure.Repositories
{
    public class EntidadeRepository : IEntidadeRepository
    {
        private readonly TesteBCDBContext _dbContext;

        public EntidadeRepository(TesteBCDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EntidadeModel>> BuscaTodos()
        {
            return await _dbContext.Entidades.ToListAsync();
        }
        public async Task Adiciona(EntidadeModel lancto)
        {
            await _dbContext.Entidades.AddAsync(lancto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualiza(EntidadeModel obj)
        {
            _dbContext.Entidades.Update(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(EntidadeModel obj)
        {
            _dbContext.Entidades.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EntidadeModel?> BuscaEntidade(Guid id)
        {
            return await _dbContext.Entidades.FirstOrDefaultAsync(t => t.IdEntidade == id);
        }

        public async Task<EntidadeModel?> BuscaEntidadePorDocumento(string doc)
        {
            return await _dbContext.Entidades.FirstOrDefaultAsync(t => t.Documento == doc);
        }
    }
}
