using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    class IISAppPoolWatcherM
    {
        // Handler naszego interfejsu do którego zostanie przypisana konkretna implementacja
        INotificationAction action = null;
        public void Notify(INotificationAction concreteAction, string message)
        {
            this.action = concreteAction;
            action.ActOnNotification(message);
        }
    }
}
