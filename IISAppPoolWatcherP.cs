using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    // DI przez właściwość
    // Wyobraźmy sobie sytuację w której wybór konkretnej implementacji oraz wywołanie metody są w różnych miejscach w naszym programie. 
    // W tym podejściu przekażemy obiekt konkretnej klasy przez właściwość set, która będzie wystawiona klasie zależnej.
    // W tym wypadku musimy przygotować Setter lub metodę w klasie zależnej,
    // która pobierze konkretny obiekt klasy i przypisze go do interfejsu, którego używamy

    class IISAppPoolWatcherP
    {
        INotificationAction action = null;
        public INotificationAction Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }

        public void Notify(string message)
        {
            action.ActOnNotification(message);
        }

    }
}
