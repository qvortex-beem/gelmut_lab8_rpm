// Паттерн Адаптер для объекта. Решение на языке C#
using static System.Console;

namespace ConsoleApp10
{
    // Исходный класс Original, который содержит 3 метода
    // OriginalDouble(), OriginalInt(), OriginalChar()
    class Original
    {
        public void OriginalDouble(double value)
        {
            WriteLine("Method Original.OriginalDouble(), value = {0}", value);
        }

        public void OriginalInt(int value)
        {
            WriteLine("Method Original.OriginalInt(), value = {0}", value);
        }

        public void OriginalChar(char value)
        {
            WriteLine("Method Original.OriginalChar, value = {0}", value);
        }
    }

    // Объявить интерфейс ITarget,
    // который содержит названия методов, которые нужны для клиента
    interface ITarget
    {
        void ClientDouble(double value);
        void ClientInt(int value);
        void ClientChar(char value);
    }

    // Класс Adapter - реализует интерфейс ITarget.
    // Класс получает входящим параметром ссылку на Original в конструкторе.
    class Adapter : Original, ITarget
    {
        // Ссылка на класс, который нужно адаптировать
        private Original obj;

        // Конструктор класса
        public Adapter(Original obj)
        {
            this.obj = obj;
        }

        public void ClientDouble(double value)
        {
            // в середине метода ClientDouble() вызвать метод OriginalDouble()
            obj.OriginalDouble(value);
        }

        public void ClientInt(int value)
        {
            obj.OriginalInt(value * 2);
        }

        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
                obj.OriginalChar(value);
        }
    }

    // Класс Client - получает ссылку на интерфейс ITarget в конструкторе
    class Client
    {
        private ITarget client; // ссылка на интерфейс ITarget

        // Конструктор
        public Client(ITarget _client)
        {
            client = _client;
        }

        // Метод, который вызывает все методы интерфейса
        public void Show()
        {
            client.ClientDouble(2.88);
            client.ClientInt(39);
            client.ClientChar('f');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация паттерна Adapter для класса.

            // 1. Объявить экземпляр класса Original
            Original obj = new Original();

            // 2. Объявить экземпляр класса Adapter, передать ему obj
            Adapter adapter = new Adapter(obj);

            // 3. Объявить экземпляр класса Client и передать ему экземпляр адаптера
            Client client = new Client(adapter);

            // 4. Вызвать метод Show() клиента
            client.Show();

            Console.ReadKey();
        }
    }
}
