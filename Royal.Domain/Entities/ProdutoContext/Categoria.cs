using Royal.Domain.Common;
using Royal.Domain.Validations;
using Royal.Domain.Validations.Interfaces;

namespace Royal.Domain.Entities.ProdutoContext
{
    public sealed class Categoria : BaseEntity, IContract
    {
        public Categoria(string nome, string descricao) : base()
        {
            Nome = nome;
            Descricao = descricao;
            Produtos = new();
            IsDeleted = false;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Produto> Produtos { get; private set; }

        public void SetFields(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public void Deleted()
        {
            IsDeleted = true;
        }

        public override bool Validation()
        {
            var contracts =
               new ContractValidations<Categoria>()
               .NomeIsOk(Nome, 3, 15, "O nome precisa ter entre 3 e 15 caracteres", "Nome do produto")
               .DescricaoIsOk(Descricao, 10, 300, "A descricao precisa ter ente 10 e 300 caracteres", nameof(Descricao));
            return contracts.IsValid();
        }
    }
}
