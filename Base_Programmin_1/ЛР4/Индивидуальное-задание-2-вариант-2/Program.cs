using System;
using System.Text;

class Program
{
    // Использование методов String и StringBuilder
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string inputText = Console.ReadLine();

        string result = ReplaceDigitsWithWordsStringBuilder(inputText);
        Console.WriteLine("\nРезультат через методы String/StringBuilder:");
        Console.WriteLine(result);
    }

    static string ReplaceDigitsWithWordsStringBuilder(string input)
    {
        StringBuilder result = new StringBuilder(input);

        result.Replace("1", "one");
        result.Replace("2", "two");
        result.Replace("3", "three");
        result.Replace("4", "four");
        result.Replace("5", "five");

        return result.ToString();
    }
}
