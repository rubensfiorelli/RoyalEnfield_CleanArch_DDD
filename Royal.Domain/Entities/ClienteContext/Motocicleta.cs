using Royal.Domain.Common;
using Royal.Domain.Validations;
using Royal.Domain.Validations.Interfaces;

namespace Royal.Domain.Entities.ClienteContext
{
    public sealed class Motocicleta : BaseEntity, IContract
    {
        public Motocicleta(string modelo, string cor, string chassis, Guid clienteId) : base()
        {
            Modelo = modelo;
            Ano = 0000;
            Cor = cor;
            Chassis = chassis;
            ClienteId = clienteId;
        }

        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Cor { get; private set; }
        public string Chassis { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente? Cliente { get; set; }


        public void SetFields(string modelo, int ano, string cor, string chassis)
        {
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Chassis = chassis;

        }

        public override bool Validation()
        {
            var contracts =
               new ContractValidations<Motocicleta>()
                    .ModeloIsOk(Modelo, 6, 20, "O modelo precisa ter entre 6 e 20 caracteres", nameof(Modelo))
                    .CorIsOk(Cor, 5, "A cor da motocicleta deve ser preenchida", nameof(Cor))
                    .ChasisIsOk(Chassis, 10, 10, "O chassis precisa conter 10 caracteres válidos", nameof(Chassis));


            return contracts.IsValid();
        }
    }
}
