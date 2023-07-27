using Royal.Domain.Common;
using Royal.Domain.Validations;
using Royal.Domain.Validations.Interfaces;

namespace Royal.Domain.Entities.ProdutoContext
{
    public sealed class Produto : BaseEntity, IContract
    {
        public Produto(string nome, string descricao, decimal preco, string imgUrl, Guid categoriaId, decimal precoPorKg) : base()
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            EstoqueDisponivel = true;
            ImgUrl = imgUrl;
            IsDeleted = false;
            CategoriaId = categoriaId;
            PrecoPorKg = precoPorKg;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public decimal PrecoPorKg { get; private set; }
        public bool EstoqueDisponivel { get; private set; }
        public string ImgUrl { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; set; }


        public void SetFields(string nome, string descricao, decimal preco, bool estoqueDisponivel, string categoria, string imgUrl, decimal freteFixoSP, decimal precoPorKg)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            EstoqueDisponivel = estoqueDisponivel;
            ImgUrl = imgUrl;
            PrecoPorKg = precoPorKg;

        }

        public void Deleted()
        {
            IsDeleted = true;
        }

        public override bool Validation()
        {
            var contracts =
                new ContractValidations<Produto>()
                .NomeIsOk(Nome, 3, 15, "O nome precisa ter entre 3 e 15 caracteres", "Nome do produto")
                .DescricaoIsOk(Descricao, 10, 300, "A descricao precisa ter ente 10 e 300 caracteres", nameof(Descricao))
                .UrlIsOk(ImgUrl, 60, "A Url da imagem precisa conter no maximo 60 caracteres", nameof(ImgUrl));
            return contracts.IsValid();
        }
    }
}
