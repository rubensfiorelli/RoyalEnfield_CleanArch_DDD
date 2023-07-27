using Royal.Domain.Common;
using Royal.Domain.Validations.Interfaces;

namespace Royal.Domain.Entities.ProdutoContext
{
    public sealed class ProdutoOrderService : BaseEntity, IContract
    {
        public ProdutoOrderService(string nome, decimal preco) : base()
        {
            Nome = nome;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}