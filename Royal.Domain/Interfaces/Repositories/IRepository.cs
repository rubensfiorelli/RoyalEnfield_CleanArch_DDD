using Royal.Domain.Common;

namespace Royal.Domain.Interfaces.Repositories
{
    public interface IGenRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<List<T>> ListAll();

    }



}
