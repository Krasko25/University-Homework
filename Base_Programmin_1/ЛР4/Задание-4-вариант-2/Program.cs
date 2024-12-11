using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = new string[7];
        Console.WriteLine("Введите 7 строк:");
        for (int i = 0; i < 7; i++)
        {
            lines[i] = Console.ReadLine();
        }

        Console.WriteLine("\nСтроки, содержащие слова, оканчивающиеся на '.com':");
        for (int i = 0; i < lines.Length; i++)
        {
            // Разбиваем строку на слова, игнорируя пробелы, точки и запятые
            string[] words = lines[i].Split(new[] { ' ', ',', '.' },
            StringSplitOptions.RemoveEmptyEntries);
            if (words.Any(word => word.EndsWith("com", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(lines[i]);
            }
        }

        int minSpacesIndex = -1;
        int minSpacesCount = int.MaxValue;

        for (int i = 0; i < lines.Length; i++)
        {
            // Считаем пробелы в строке
            int spaces = lines[i].Count(c => c == ' ');
            if (spaces < minSpacesCount)
            {
                minSpacesCount = spaces;
                minSpacesIndex = i;
            }
        }

        Console.WriteLine($"\nСтрока с минимальным количеством пробелов находится под номером: {minSpacesIndex + 1}");
    }
}
