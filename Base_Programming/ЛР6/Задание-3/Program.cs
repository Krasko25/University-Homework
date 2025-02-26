using System;
using System.IO;

class Program
{
    // Функция для замены символов в файле
    static void ReplaceSymbolsInFile(string inputFilePath, string outputFilePath)
    {
        int replacementsCount = 0; 

        // Cуществует ли исходный файл
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Ошибка: файл {inputFilePath} не найден.");
            return;
        }

        
        string content = File.ReadAllText(inputFilePath);

        // Замена символов
        content = content.Replace("<", "{");
        content = content.Replace(">", "}");

        // Подсчитываем количество замен
        replacementsCount = (content.Split('{').Length - 1) + (content.Split('}').Length - 1);

        // Запись в новый файл
        File.WriteAllText(outputFilePath, content);

        Console.WriteLine($"Количество замен: {replacementsCount}");
        Console.WriteLine($"Изменённый файл сохранён как: {outputFilePath}");
    }

    static void Main()
    {
        Console.Write("Введите имя исходного файла: ");
        string inputFilePath = Console.ReadLine();

        Console.Write("Введите имя нового файла для сохранения изменений: ");
        string outputFilePath = Console.ReadLine();

        // Замена символов в файле
        ReplaceSymbolsInFile(inputFilePath, outputFilePath);
    }
}
