using Microsoft.EntityFrameworkCore;
using Royal.Data.DataBaseContext;
using Royal.Domain.Entities.ProdutoContext;
using Royal.Domain.Interfaces.Repositories;

namespace Royal.Data.Repositories
{
    public class ProdutoOrderRepository : BaseRepository<ProdutoOrder>, IProdutoOrderRepository
    {
        protected DbSet<ProdutoOrder> _produtoOrders;
        public ProdutoOrderRepository(ApplicationDbContext context) : base(context)
        {
            _produtoOrders = context.Set<ProdutoOrder>();
        }

        public async Task<ProdutoOrder> AddAsync(ProdutoOrder produtoOrder)
        {
            try
            {
                produtoOrder.CreateAt = DateTime.UtcNow;
                _dataset.Add(produtoOrder);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return produtoOrder;
        }

        public async Task<bool> DeleteAsync(string trackingCode)
        {
            try
            {
                var seek = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(trackingCode));
                if (seek is null)
                    return false;

                _dataset.Remove(seek);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
        public async Task<ProdutoOrder> SelectOrderCodeAsync(string trackingCode)
        {
            try
            {
                var seek = _dataset.Where(d => d.TrackingCode.Equals(trackingCode))
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (seek != null)
                {
                    return await seek;
                }

                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
