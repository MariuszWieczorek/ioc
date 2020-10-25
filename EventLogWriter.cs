using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    class EventLogWriter : INotificationAction
    {
        public void ActOnNotification(string message)
        {
            Console.WriteLine("zapis do pliku: {0}", message);
        }
    }
}
