using Microsoft.EntityFrameworkCore;
using Royal.Data.DataBaseContext;
using Royal.Domain.Entities.ProdutoContext;
using Royal.Domain.Interfaces.Repositories;

namespace Royal.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        protected new DbSet<Produto> _dataset;
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Produto>> ListAllAsync()
        {
            try
            {
                var list = _dataset.Where(p => !p.IsDeleted)
                    .AsNoTracking()
                    .Take(30)
                    .ToListAsync();

                return await list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
