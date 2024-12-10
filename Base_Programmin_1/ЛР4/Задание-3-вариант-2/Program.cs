using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст, завершённый точкой:");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input) || !input.EndsWith('.'))
        {
            Console.WriteLine("Текст должен быть завершён точкой.");
            return;
        }

        string content = input.TrimEnd('.');
        string[] words = content.Split(new[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);

        StringBuilder reversedString = new StringBuilder();
        reversedString.Append(string.Join(" ", words));
        reversedString.Append('.');

        Console.WriteLine(reversedString.ToString());
    }
}
