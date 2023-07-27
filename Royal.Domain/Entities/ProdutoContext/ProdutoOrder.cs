using Royal.Domain.Common;
using Royal.Domain.Enums;
using Royal.Domain.Validations.Interfaces;

namespace Royal.Domain.Entities.ProdutoContext
{
    public sealed class ProdutoOrder : BaseEntity, IContract
    {
        public ProdutoOrder(string descricao, decimal totalPrice, decimal pesoKg) : base()
        {
            TrackingCode = GenerateLoteCode();
            Descricao = descricao;
            Status = StatusCompra.Started;
            TotalPrice = totalPrice;
            Itens = new();
            PesoKg = pesoKg;
            IsDeleted = false;
        }

        public string TrackingCode { get; private set; }
        public string Descricao { get; private set; }
        public decimal PesoKg { get; private set; }
        public bool IsDeleted { get; private set; }
        public StatusCompra Status { get; private set; }
        public decimal TotalPrice { get; private set; }
        public List<ProdutoOrderService> Itens { get; private set; }

        public void SetupCompras(List<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                var cart = produto.Preco + (produto.PrecoPorKg * PesoKg);
                TotalPrice += cart;
                Itens.Add(new ProdutoOrderService(produto.Nome, cart));
            }
        }

        private static string GenerateLoteCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            var code = new char[10];
            var random = new Random();

            for (var i = 0; i < 5; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            for (var i = 5; i < 10; i++)
            {
                code[i] = numbers[random.Next(numbers.Length)];
            }

            return new string(code);
        }

        public void Deleted()
        {
            IsDeleted = true;
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}
