using System;
using System.IO;

class Program
{
    // Структура для хранения информации о транспорте
    struct Transport
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

    static void Main()
    {
        Transport[] transports = new Transport[50];
        LogEntry[] logs = new LogEntry[50];
        int transportCount = 0;
        int logCount = 0;
        DateTime lastActionTime = DateTime.Now; 
        TimeSpan maxIdleTime = TimeSpan.Zero;

        // Чтение данных из файла при запуске программы
        LoadData(ref transports, ref transportCount, ref logs, ref logCount);

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

            // Сохранение данных в файл
            SaveData(transports, transportCount, logs, logCount);

            switch (choice)
            {
                case 1:
                    ViewTable(transports, transportCount);
                    break;
                case 2:
                    SortTable(ref transports, transportCount);
                    break;
                case 3:
                    AddRecord(ref transports, ref transportCount, ref logs, ref logCount);
                    break;
                case 4:
                    DeleteRecord(ref transports, ref transportCount, ref logs, ref logCount);
                    break;
                case 5:
                    UpdateRecord(transports, transportCount, ref logs, ref logCount);
                    break;
                case 6:
                    SearchRecords(transports, transportCount);
                    break;
                case 7:
                    ViewLog(logs, logCount, maxIdleTime);
                    break;
                case 8:
                    Console.WriteLine("Завершение работы программы.");
                    // Сохранение данных в файл
                    SaveData(transports, transportCount, logs, logCount);
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите пункт из списка.");
                    break;

            }
        }
    }

    // Метод для отображения таблицы
    static void ViewTable(Transport[] transports, int count)
    {
        Console.WriteLine("\nСписок транспорта");
        Console.WriteLine("--------------------------------------------------------------" +
            "----------------------");
        Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", "Тип транспорта",
            "Маршрут", "Дистанция (км)", "Длительность (мин)");
        Console.WriteLine("--------------------------------------------------------------" +
            "----------------------");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", transports[i].Type,
                transports[i].RouteNumber, transports[i].Length, transports[i].Time);
        }
        Console.WriteLine("-------------------------------------------------------" +
            "-----------------------------");
    }

    // Метод для сортировки таблицы
    static void SortTable(ref Transport[] transports, int count)
    {
        Console.WriteLine("\nВыберите столбец для сортировки:");
        Console.WriteLine("1 – По длине маршрута");
        Console.WriteLine("2 – По времени маршрута");
        Console.Write("Введите номер столбца: ");
        int sortChoice = Convert.ToInt32(Console.ReadLine());

        // Сортировка выбором
        for (int i = 0; i < count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < count; j++)
            {
                bool condition = false;

                // Условие сортировки по длине маршрута
                if (sortChoice == 1 && transports[j].Length < transports[minIndex].Length)
                {
                    condition = true;
                }
                // Условие сортировки по времени маршрута
                else if (sortChoice == 2 && transports[j].Time < transports[minIndex].Time)
                {
                    condition = true;
                }

                if (condition)
                {
                    minIndex = j;
                }
            }

            // Меняем элементы местами
            if (minIndex != i)
            {
                Transport temp = transports[i];
                transports[i] = transports[minIndex];
                transports[minIndex] = temp;
            }
        }

        // После сортировки показываем таблицу
        ViewTable(transports, count);
    }

    // Метод для добавления записи
    static void AddRecord(ref Transport[] transports, ref int count, ref LogEntry[] logs,
        ref int logCount)
    {
        // Проверяем, есть ли место в массиве для добавления новой записи
        if (count >= transports.Length)
        {
            Array.Resize(ref transports, transports.Length + 10);
        }

        Transport newTransport = new Transport();

        string[] validTypes = { "Тр", "А", "М" };
        bool validType = false;

        // Цикл, пока пользователь не введёт правильный тип транспорта
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

        transports[count++] = newTransport;

        // Добавляем запись в лог действий
        AddLog(ref logs, ref logCount, "Добавление", $"Добавлен маршрут " +
            $"{newTransport.RouteNumber}");
    }

    static void DeleteRecord(ref Transport[] transports, ref int count,
       ref LogEntry[] logs, ref int logCount)
    {
        Console.Write("Введите номер записи для удаления: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index < 0 || index >= count)
        {
            Console.WriteLine("Некорректный номер записи.");
            return;
        }

        string deletedDetails = transports[index].RouteNumber;

        // Смещение записей
        for (int i = index; i < count - 1; i++)
        {
            transports[i] = transports[i + 1];
        }
        count--;

        AddLog(ref logs, ref logCount, "Удаление", $"Удален маршрут {deletedDetails}");
    }

    static void UpdateRecord(Transport[] transports, int count, ref LogEntry[] logs,
        ref int logCount)
    {
        Console.Write("Введите номер записи для обновления: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index < 0 || index >= count)
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

        string oldDetails = transports[index].RouteNumber;
        transports[index] = updatedTransport;

        AddLog(ref logs, ref logCount, "Обновление", $"Обновлен маршрут {oldDetails}");
    }

    static void SearchRecords(Transport[] transports, int count)
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
            for (int i = 0; i < count; i++)
            {
                if (transports[i].Length >= minLength)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", transports[i].Type,
                        transports[i].RouteNumber, transports[i].Length, transports[i].Time);
                }
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
            for (int i = 0; i < count; i++)
            {
                if (transports[i].Time >= minTime)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-20}", transports[i].Type,
                        transports[i].RouteNumber, transports[i].Length, transports[i].Time);
                }
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор фильтра.");
        }
        Console.WriteLine("---------------------------------------------------------------" +
            "---------------------");
    }

    // Метод для записи данных в файл

    static void SaveData(Transport[] transports, int transportCount, LogEntry[] logs, int logCount)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open("lab.dat", FileMode.Create)))
        {
            // Записываем количество элементов в массиве
            writer.Write(transportCount);
            writer.Write(logCount);

            // Записываем данные о транспорте
            for (int i = 0; i < transportCount; i++)
            {
                writer.Write(transports[i].Type);
                writer.Write(transports[i].RouteNumber);
                writer.Write(transports[i].Length);
                writer.Write(transports[i].Time);
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
    static void LoadData(ref Transport[] transports, ref int transportCount, ref LogEntry[] logs, ref int logCount)
    {
        if (File.Exists("lab.dat"))
        {
            using (BinaryReader reader = new BinaryReader(File.Open("lab.dat", FileMode.Open)))
            {
                transportCount = reader.ReadInt32();
                logCount = reader.ReadInt32();

                // Загружаем данные о транспорте
                transports = new Transport[transportCount];
                for (int i = 0; i < transportCount; i++)
                {
                    transports[i].Type = reader.ReadString();
                    transports[i].RouteNumber = reader.ReadString();
                    transports[i].Length = reader.ReadDouble();
                    transports[i].Time = reader.ReadInt32();
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
