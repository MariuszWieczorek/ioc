using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// DIP Dependency Inversion Principle - zasada odwracania zależności
// Zasada odwracania zależności jest wzorcem projektowym, który mówi nam o pisaniu luźno powiązanych klas
// Zgodnie z definicją:
// moduły wysokiego poziomu nie powinny zależeć od modułów niskiego poziomu
// abstrakcie nie powinny zależeć od szczegółów. To szczegóły powinny zależeć od abstrakcji.

// IoC Inversion of Control - odwrócenie sterowania
// Zasada odwracania zależności jest wzorcem projektowym, który mówi jak dwa moduły powinny od siebie zależeć.
// Odpowiedzią na to pytanie jest odwrócenie sterowania (IoC).
// Jest to mechanizm, dzięki któremu moduły wyższego poziomu mogą zależeć od abstrakcji, a nie od konkretnej implementacji modułu niższego poziomu. 

// Jeżeli chcemy zaimplementować odwrócenie sterowania w powyższym przykładzie,
// pierwszą rzeczą, jaką musi zrobić jest przygotowanie abstrakcji, od której będą zależały moduły wysokiego poziomu.
// Utwórzmy zatem interfejs, który będzie naszą abstrakcją związaną ze zgłaszaniem powiadomień z IISAppPoolWatcher: 
// public interface INotificationAction
// {
//    public void ActOnNotification(string message);
// }

// tworzymy 3 klasy, które będą implementowały powyższy interfejs
// class EventLogWriter : INotificationAction       - zapisuje treść błędu  do pliku
// class EmailSender    : INotificationAction       - wysyła email z treścią błędu
// class SMSSender      : INotificationAction       - wysyła SMS'a z treścią błędu

// wewnątrz klasy wysokiego poziomu dokonujemy mapowania abstrakcji
// użyjemy interfejsu dla konkretnej klasy
// class IISAppPoolWatcher
// INotificationAction action = null;
// action = new EventLogWriter();

// To, co zrobiliśmy tutaj to zastosowanie odwrócenia sterowania (IoC), aby spełnić zasadę odwracania zależności (DIP).
// Teraz moduły wysokiego poziomu zależą tylko od abstrakcji a nie implementacji klas niskiego poziomu, co jest dokładnie tym, co oznacza zasada odwrócenia sterowania. 

// Brakuje nam jednak jeszcze jednego elementu
// Kiedy spojrzymy na kod naszej klasy IISAppPoolWatcher, możemy zauważyć, że używa ona abstrakcji, tj. 
// Tworzenie konkretnej klasy jest ciągle wewnątrz modułu wysokiego 
// Czy nie moglibyśmy zrobić tego w taki sposób, że dodając nową klasę, która implementuje interfejs INofificationAction, nie musielibyśmy zmieniać tej klasy? 
//  to jest dokładnie to miejsce, w którym pojawia się wstrzykiwanie zależności (DI)


// DI  Dependency Injection - wstrzykiwanie zależności 
// Teraz, kiedy znamy już zasadę odwracania zależności, nauczyliśmy się jak dokonać implementacji odwrócenia sterowania, aby spełnić zasadę odwracania zależności 
// możemy poświecić uwagę wstrzykiwaniu zależności. DI służy głównie do wstrzykiwania konkretnej implementacji do klasy używającej abstrakcji, np. interfejsu.
// Główną ideą wstrzykiwania zależności jest
// redukcja połączeń pomiędzy klasami oraz
// przeniesienie łączenia abstrakcji z konkretną implementacją poza klasę zależną. 

// Wstrzykiwanie zależności może odbywać się na trzy sposoby:
//  przez konstruktor;
// Podczas wstrzykiwania zależności przed konstruktor zauważyliśmy, że obiekt klasy zależnej będzie przez cały czas używała konkretnej implementacji.
// Jeżeli chcemy za każdym razem podczas wywołania przekazywać inną implementację musimy skorzystać ze wstrzykiwania zależności za pomocą metody. 

//  przez metodę;
//  przez właściwość.



namespace ioc
{
    class Program
    {
        static void Main(string[] args)
        {

            EventLogWriter writer = new EventLogWriter();
            EmailSender email = new EmailSender();

            // Wstrzyknięcie zależności przez konstruktor
            // Obiekt klasy zależnej będzie cały czas używał tej samej implementacji
            IISAppPoolWatcher watcher = new IISAppPoolWatcher(writer);
            watcher.Notify("błąd aplikacji");

            // Wstrzyknięcie zależności przez metodę
            IISAppPoolWatcherM watcherM = new IISAppPoolWatcherM();
            watcherM.Notify(writer,"błąd aplikacji");
            watcherM.Notify(email, "błąd aplikacji");



            Console.ReadKey();
        }
    }
}
