using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    class EmailSender : INotificationAction
    {
        public void ActOnNotification(string message)
        {
            Console.WriteLine("EmailSender: {0}", message);
        }
    }
}
