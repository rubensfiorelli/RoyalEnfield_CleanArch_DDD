using Royal.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> UrlIsOk(string url, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(url) || (url.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
