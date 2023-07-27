using Royal.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> CorIsOk(string cor, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(cor) || (cor.Length < minLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
