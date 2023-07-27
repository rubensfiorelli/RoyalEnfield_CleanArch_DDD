using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Domain.Interfaces.Repositories
{
    public interface IProdutoOrderRepository : IGenRepository<ProdutoOrder>
    {
        Task<ProdutoOrder> SelectOrderCodeAsync(string trackingCode);
        Task<ProdutoOrder> AddAsync(ProdutoOrder produtoOrder);
        Task<bool> DeleteAsync(string trackingCode);
    }
}
