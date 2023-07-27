using Royal.Domain.Common;
using Royal.Domain.Validations;
using Royal.Domain.Validations.Interfaces;

namespace Royal.Domain.Entities.ClienteContext
{
    public sealed class Cliente : BaseEntity, IContract
    {
        public Cliente(string primeiroNome, string ultimoNome, string celular, string email) : base()
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Celular = celular;
            Email = email;
            Motocicletas = new List<Motocicleta>();
            IsDeleted = false;
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Celular { get; private set; }
        public string Email { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Motocicleta> Motocicletas { get; set; }


        public void SetFields(string primeiroNome, string ultimoNome, string celular, string email)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Celular = celular;
            Email = email;
        }

        public void Deleted()
        {
            IsDeleted = true;
        }

        public override bool Validation()
        {
            var contracts =
               new ContractValidations<Cliente>()
               .PrimeiroNomeIsOk(PrimeiroNome, 3, 12, "O primeiro nome deve ter entre 3 e 12 caracteres", nameof(PrimeiroNome))
               .UltimoNomeIsOk(UltimoNome, 6, 15, "O ultimo nome deve ter entre 6 e 15 caracteres", nameof(UltimoNome))
               .CelularIsOk(Celular, 11, 11, "O celular / WhatsApp deve ter 11 caracteres", nameof(Celular))
               .EmailIsOk(Email, "Informe um email valido", nameof(Email));
            return contracts.IsValid();
        }
    }

}
