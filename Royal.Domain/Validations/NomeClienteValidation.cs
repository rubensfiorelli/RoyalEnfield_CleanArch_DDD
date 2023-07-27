using Royal.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> PrimeiroNomeIsOk(string primeiroNome, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(primeiroNome) || (primeiroNome.Length < minLength) || (primeiroNome.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }

        public ContractValidations<T> UltimoNomeIsOk(string ultimoNome, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(ultimoNome) || (ultimoNome.Length < minLength) || (ultimoNome.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
