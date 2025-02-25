using System;
using System.Text.RegularExpressions;

class Program
{
    //решение, с использованием регулярных выражений
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        Console.WriteLine("\nСлова, начинающиеся с заглавной латинской буквы и заканчивающиеся на 2 цифры:");
        Regex regex = new Regex(@"\b[A-Z][a-zA-Z]*\d{2}\b");

        MatchCollection matches = regex.Matches(input);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
