using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст, завершённый точкой:");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input) || input[^1] != '.')
        {
            Console.WriteLine("Текст должен быть завершён точкой.");
            return;
        }

        char[] characters = input[..^1].ToCharArray(); // Отбрасываем последнюю точку
        foreach (char c in characters)
        {
            if (Array.FindAll(characters, ch => ch == c).Length == 1)
            {
                Console.Write(c);
            }
        }
        Console.WriteLine();
    }
}
