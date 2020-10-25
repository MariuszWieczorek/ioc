using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    class IISAppPoolWatcherC
    {
        // Handler naszego interfejsu do którego zostanie przypisana konkretna implementacja
        INotificationAction action = null;
        public IISAppPoolWatcherC(INotificationAction concreteImplementation)
        {
            this.action = concreteImplementation;
        }
       
        public void Notify(string message)
        {
            if (action == null)
            {
                action = new EventLogWriter();
            }
            action.ActOnNotification(message);
        }

    }
}
