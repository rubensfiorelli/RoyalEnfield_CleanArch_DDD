using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IGenRepository<Produto>
    {
        Task<List<Produto>> ListAllAsync();
    }
}
