using System;
using System.Text;

class Program
{
    // Использование массива символов
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string inputText = Console.ReadLine();

        string result = ReplaceDigitsWithWordsArray(inputText);
        Console.WriteLine("\nРезультат через обработку массива символов:");
        Console.WriteLine(result);
    }

    static string ReplaceDigitsWithWordsArray(string input)
    {
        char[] chars = input.ToCharArray();
        StringBuilder result = new StringBuilder();

        foreach (char c in chars)
        {
            switch (c)
            {
                case '1': result.Append("one"); break;
                case '2': result.Append("two"); break;
                case '3': result.Append("three"); break;
                case '4': result.Append("four"); break;
                case '5': result.Append("five"); break;
                default: result.Append(c); break;
            }
        }

        return result.ToString();
    }
}
