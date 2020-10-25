using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    class SMSSender : INotificationAction
    {
        public void ActOnNotification(string message)
        {
            Console.WriteLine("SMSSender: {0}", message);
        }
    }
}
