using System;

class Program
{
    // Структура для хранения информации о транспорте
    public struct Transport
    {
        public string Type;
        public string RouteNumber;
        public double Length;
        public int Time;
    }


    // Структура для записи логов действий пользователя
    struct LogEntry
    {
        public string Action;
        public string Details;
        public DateTime Timestamp;
    }

    // Узел двусвязного списка для хранения информации о транспорте
    public class TransportNode
    {
        public Transport Data;      
        public TransportNode Next;    // Ссылка на следующий узел
        public TransportNode Prev;    // Ссылка на предыдущий узел

        // Конструктор
        public TransportNode(Transport data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }



    // Двусвязный список для хранения информации о транспорте
    public class TransportList
    {
        public TransportNode Head;   // Голова списка
        public TransportNode Tail;   // Хвост списка
        public int Count;            // Количество элементов в списке

        // Конструктор
        public TransportList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // Метод для добавления записи в список
        public void Add(Transport transport)
        {
            TransportNode newNode = new TransportNode(transport);
            if (Tail == null)  // Если список пуст
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
            Count++;
        }

        // Метод для удаления записи по индексу
        public void Delete(int index)
        {
            if (index < 0 || index >= Count)
                return;

            TransportNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            if (current.Next != null)
                current.Next.Prev = current.Prev;
            if (current == Head)
                Head = current.Next;
            if (current == Tail)
                Tail = current.Prev;

            Count--;
        }

        // Метод для сортировки списка по выбранному критерию
        public void Sort(int sortChoice)
        {
            if (Head == null)
                return;

            // Алгоритм сортировки выбором (для упрощения)
            for (TransportNode i = Head; i != null; i = i.Next)
            {
                TransportNode minNode = i;
                for (TransportNode j = i.Next; j != null; j = j.Next)
                {
                    bool condition = false;

                    if (sortChoice == 1 && j.Data.Length < minNode.Data.Length)
                    {
                        condition = true;
                    }
                    else if (sortChoice == 2 && j.Data.Time < minNode.Data.Time)
                    {
                        condition = true;
                    }

                    if (condition)
                    {
                        minNode = j;
                    }
                }

                if (minNode != i)
                {
                    // Меняем данные
                    Transport temp = i.Data;
                    i.Data = minNode.Data;
                    minNode.Data = temp;
                }
            }
        }


        // Метод для получения записи по индексу
        public Transport Get(int index)
        {
            if (index < 0 || index >= Count)
                return default(Transport);

            TransportNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        // Метод для обновления записи по индексу
        public void Update(int index, Transport updatedTransport)
        {
            if (index < 0 || index >= Count)
                return;

            TransportNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = updatedTransport;
        }
    }


    static void Main()
    {
        TransportList transports = new TransportList();  // Двусвязный список
        LogEntry[] logs = new LogEntry[50];
        int logCount = 0;
        DateTime lastActionTime = DateTime.Now;
        TimeSpan maxIdleTime = TimeSpan.Zero;

        // Чтение данных из файла при запуске программы
        LoadData(ref transports, ref logs, ref logCount);

        while (true)
        {
            Console.WriteLine("\nДоступные действия:");
            Console.WriteLine("1 – Показать таблицу");
            Console.WriteLine("2 – Отсортировать таблицу");
            Console.WriteLine("3 – Добавить новую запись");
            Console.WriteLine("4 – Удалить запись");
            Console.WriteLine("5 – Обновить запись");
            Console.WriteLine("6 – Найти записи");
            Console.WriteLine("7 – Показать лог действий");
            Console.WriteLine("8 – Завершить работу");
            Console.Write("Введите номер действия: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            // Время простоя
            TimeSpan idleTime = DateTime.Now - lastActionTime;
            if (idleTime > maxIdleTime)
                maxIdleTime = idleTime;

            // Время последнего действия
            lastActionTime = DateTime.Now;

            switch (choice)
            {
                case 1:
                    ViewTable(transports);
                    break;
                case 2:
                    Console.WriteLine("\nВыберите столбец для сортировки:");
                    Console.WriteLine("1 – По длине маршрута");
                    Console.WriteLine("2 – По времени маршрута");
                    int sortChoice = Convert.ToInt32(Console.ReadLine());
                    transports.Sort(sortChoice);
                    break;
                case 3:
                    AddRecord(ref transports, ref logs, ref logCount);
                    break;
                case 4:
                    DeleteRecord(ref transports, ref logs, ref logCount);
                    break;
                case 5:
                    UpdateRecord(ref transports, ref logs, ref logCount);
                    break;
                case 6:
                    SearchRecords(transports);
                    break;
                case 7:
                    ViewLog(logs, logCount, maxIdleTime);
                    break;
                case 8:
                    Console.WriteLine("Завершение работы программы.");
                    // Сохранение данных в файл
                    SaveData(transports, logs, logCount);
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите пункт из списка.");
                    break;
            }
        }
    }


    // Метод для записи данных в файл
    static void SaveData(TransportList transports, LogEntry[] logs, int logCount)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open("lab.dat", FileMode.Create)))
        {
            // Записываем количество элементов в списке и в логе
            writer.Write(transports.Count);
            writer.Write(logCount);

            // Записываем данные о транспорте
            TransportNode current = transports.Head;
            while (current != null)
            {
                writer.Write(current.Data.Type);
                writer.Write(current.Data.RouteNumber);
                writer.Write(current.Data.Length);
                writer.Write(current.Data.Time);
                current = current.Next;
            }

            // Записываем данные о логах
            for (int i = 0; i < logCount; i++)
            {
                writer.Write(logs[i].Action);
                writer.Write(logs[i].Details);
                writer.Write(logs[i].Timestamp.ToString());
            }
        }
    }

    // Метод для чтения данных из файла
    static void LoadData(ref TransportList transports, ref LogEntry[] logs, ref int logCount)
    {
        if (File.Exists("lab.dat"))
        {
            using (BinaryReader reader = new BinaryReader(File.Open("lab.dat", FileMode.Open)))
            {
                int transportCount = reader.ReadInt32();
                logCount = reader.ReadInt32();

                // Загружаем данные о транспорте
                for (int i = 0; i < transportCount; i++)
                {
                    Transport newTransport = new Transport
                    {
                        Type = reader.ReadString(),
                        RouteNumber = reader.ReadString(),
                        Length = reader.ReadDouble(),
                        Time = reader.ReadInt32()
                    };

                    transports.Add(newTransport);
                }

                // Загружаем данные о логах
                logs = new LogEntry[logCount];
                for (int i = 0; i < logCount; i++)
                {
                    logs[i].Action = reader.ReadString();
                    logs[i].Details = reader.ReadString();
                    logs[i].Timestamp = DateTime.Parse(reader.ReadString());
                }
            }
        }
    }


    // Метод для отображения таблицы
    static void ViewTable(TransportList transports)
    {
        Console.WriteLine("\nСписок транспорта");
        Console.WriteLine("--------------------------------------------------------------" +
            "----------------------");
        Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", "Тип транспорта",
            "Маршрут", "Дистанция (км)", "Длительность (мин)");
        Console.WriteLine("--------------------------------------------------------------" +
            "----------------------");

        TransportNode current = transports.Head;
        while (current != null)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", current.Data.Type,
                current.Data.RouteNumber, current.Data.Length, current.Data.Time);
            current = current.Next;
        }
        Console.WriteLine("--------------------------------------------------------------" +
            "----------------------");
    }

    // Метод для добавления записи
    static void AddRecord(ref TransportList transports, ref LogEntry[] logs, ref int logCount)
    {
        Transport newTransport = new Transport();

        string[] validTypes = { "Тр", "А", "М" };
        bool validType = false;

        while (!validType)
        {
            Console.Write("Введите тип транспорта (Тр - трамвай, А - автобус, М - метро): ");
            newTransport.Type = Console.ReadLine().Trim();

            if (Array.Exists(validTypes, type => type == newTransport.Type))
            {
                validType = true;
            }
            else
            {
                Console.WriteLine("Неверный тип транспорта. Пожалуйста, выберите " +
                    "один из предложенных.");
            }
        }

        Console.Write("Введите номер маршрута: ");
        newTransport.RouteNumber = Console.ReadLine();

        Console.Write("Введите длину маршрута (в км): ");
        newTransport.Length = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите длительность маршрута (в минутах): ");
        newTransport.Time = Convert.ToInt32(Console.ReadLine());

        transports.Add(newTransport);

        AddLog(ref logs, ref logCount, "Добавление", $"Добавлен маршрут {newTransport.RouteNumber}");
    }

    // Метод для удаления записи
    static void DeleteRecord(ref TransportList transports, ref LogEntry[] logs, ref int logCount)
    {
        Console.Write("Введите номер записи для удаления: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index < 0 || index >= transports.Count)
        {
            Console.WriteLine("Некорректный номер записи.");
            return;
        }

        Transport deletedTransport = transports.Get(index);

        transports.Delete(index);

        AddLog(ref logs, ref logCount, "Удаление", $"Удален маршрут {deletedTransport.RouteNumber}");
    }

    // Метод для обновления записи
    static void UpdateRecord(ref TransportList transports, ref LogEntry[] logs, ref int logCount)
    {
        Console.Write("Введите номер записи для обновления: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index < 0 || index >= transports.Count)
        {
            Console.WriteLine("Ошибка: некорректный номер записи.");
            return;
        }

        Transport updatedTransport;
        Console.Write("Введите новый тип транспорта: ");
        updatedTransport.Type = Console.ReadLine();
        Console.Write("Введите новый номер маршрута: ");
        updatedTransport.RouteNumber = Console.ReadLine();
        Console.Write("Введите новую длину маршрута (в км): ");
        updatedTransport.Length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите новую длительность маршрута (в минутах): ");
        updatedTransport.Time = Convert.ToInt32(Console.ReadLine());

        transports.Update(index, updatedTransport);

        AddLog(ref logs, ref logCount, "Обновление", $"Обновлен маршрут {updatedTransport.RouteNumber}");
    }


    // Метод для поиска записей
    static void SearchRecords(TransportList transports)
    {
        Console.WriteLine("Выберите фильтр поиска:");
        Console.WriteLine("1 – Поиск по длине маршрута");
        Console.WriteLine("2 – Поиск по времени маршрута");
        Console.Write("Введите номер фильтра: ");
        int filterChoice = Convert.ToInt32(Console.ReadLine());

        if (filterChoice == 1)
        {
            Console.Write("Введите минимальную длину маршрута (в км): ");
            double minLength = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nРезультаты поиска по длине маршрута:");
            Console.WriteLine("-------------------------------------------------------------" +
                "-----------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", "Тип транспорта", "Маршрут",
                "Дистанция (км)", "Длительность (мин)");
            Console.WriteLine("--------------------------------------------------------------" +
                "----------------------");

            TransportNode current = transports.Head;
            while (current != null)
            {
                if (current.Data.Length >= minLength)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", current.Data.Type,
                        current.Data.RouteNumber, current.Data.Length, current.Data.Time);
                }
                current = current.Next;
            }
        }
        else if (filterChoice == 2)
        {
            Console.Write("Введите минимальное время маршрута (в минутах): ");
            int minTime = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nРезультаты поиска по времени маршрута:");
            Console.WriteLine("------------------------------------------------------------" +
                "------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", "Тип транспорта", "Маршрут",
                "Дистанция (км)", "Длительность (мин)");
            Console.WriteLine("--------------------------------------------------------------" +
                "----------------------");

            TransportNode current = transports.Head;
            while (current != null)
            {
                if (current.Data.Time >= minTime)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", current.Data.Type,
                        current.Data.RouteNumber, current.Data.Length, current.Data.Time);
                }
                current = current.Next;
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор фильтра.");
        }
        Console.WriteLine("---------------------------------------------------------------" +
            "---------------------");
    }


    // Метод для отображения лога
    static void ViewLog(LogEntry[] logs, int count, TimeSpan maxIdleTime)
    {
        Console.WriteLine("\nЛог действий:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{logs[i].Timestamp:HH:mm:ss} – {logs[i].Action}: {logs[i].Details}");
        }
        Console.WriteLine($"\n{maxIdleTime:hh\\:mm\\:ss} – Самый долгий период бездействия.");
    }

    // Метод для добавления записи в лог
    static void AddLog(ref LogEntry[] logs, ref int count, string action, string details)
    {
        if (count >= logs.Length)
        {
            for (int i = 1; i < logs.Length; i++)
            {
                logs[i - 1] = logs[i];
            }
            count--;
        }

        logs[count++] = new LogEntry
        {
            Action = action,
            Details = details,
            Timestamp = DateTime.Now
        };
    }
}

