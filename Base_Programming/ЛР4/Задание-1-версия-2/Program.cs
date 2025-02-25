using System;
using System.Linq;

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
        string uniqueChars = new string(content.Where(c => content.Count(ch => 
            ch == c) == 1).ToArray());
        
        Console.WriteLine(uniqueChars);
    }
}
