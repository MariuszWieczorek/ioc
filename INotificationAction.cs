using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    interface INotificationAction
    {
        void ActOnNotification(string message);
    }
}
