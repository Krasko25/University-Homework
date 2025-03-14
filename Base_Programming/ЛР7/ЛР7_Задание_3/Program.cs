using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к исполняемой программе:");
        string programPath = Console.ReadLine();

        // Проверка, существует ли файл по указанному пути
        if (File.Exists(programPath))
        {
            // Засекаем время выполнения программы
            MeasureExecutionTime(programPath);
        }
        else
        {
            Console.WriteLine("Ошибка: Указанный файл не существует.");
        }
    }

    // Метод для измерения времени выполнения программы
    static void MeasureExecutionTime(string programPath)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Настройка процесса для запуска программы
        Process process = new Process();
        process.StartInfo.FileName = programPath;
        process.StartInfo.RedirectStandardOutput = true; // Перенаправление вывода программы в консоль
        process.StartInfo.RedirectStandardError = true; // Перенаправление ошибок в консоль

        try
        {
            process.Start();
            process.WaitForExit();
            stopwatch.Stop();
            Console.WriteLine($"Программа завершена. Время выполнения: {stopwatch.Elapsed.Seconds} секунд и {stopwatch.Elapsed.Milliseconds} миллисекунд.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при запуске программы: {ex.Message}");
        }
    }
}
