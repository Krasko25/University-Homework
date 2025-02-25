using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string inputText = Console.ReadLine();

        // Регулярное выражение
        string pattern = @"\b\w+\s*&{1,2}\s*\w+\b";

        // Поиск совпадений
        MatchCollection matches = Regex.Matches(inputText, pattern);

        Console.WriteLine("\nНайденные логические выражения:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
