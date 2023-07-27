﻿using Royal.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> DescricaoIsOk(string descricao, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(descricao) || (descricao.Length < minLength) || (descricao.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
