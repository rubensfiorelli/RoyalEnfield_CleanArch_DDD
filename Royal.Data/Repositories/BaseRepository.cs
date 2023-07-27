using Microsoft.EntityFrameworkCore;
using Royal.Data.DataBaseContext;
using Royal.Domain.Common;
using Royal.Domain.Interfaces.Repositories;

namespace Royal.Data.Repositories
{
    public class BaseRepository<T> : IGenRepository<T> where T : BaseEntity
    {
        protected internal ApplicationDbContext _context;
        protected DbSet<T> _dataset;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<T> CreateAsync(T item)
        {
            try
            {
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var seek = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));
                if (seek is null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = seek.CreateAt;

                _context.Entry(seek).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var seek = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
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

        public async Task<List<T>> ListAll()
        {
            try
            {
                return await _dataset
                    .AsNoTracking()
                    .Take(30)
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var seek = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (seek is null)
                    return null;

                return seek;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
