using Royal.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> CelularIsOk(string celular, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(celular) || (celular.Length < minLength) || (celular.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
