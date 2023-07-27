using Royal.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> ChasisIsOk(string chassi, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(chassi) || (chassi.Length < minLength) || (chassi.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
