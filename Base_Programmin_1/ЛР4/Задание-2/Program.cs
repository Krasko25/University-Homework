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

        input = input[..^1]; // Убираем точку в конце
        char[] delimiters = { ' ', ',', '-' };
        string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        char[] inputChars = input.ToCharArray();

        int wordIndex = 0, charIndex = 0;
        while (charIndex < inputChars.Length)
        {
            if (!char.IsLetterOrDigit(inputChars[charIndex]) && 
                delimiters.Contains(inputChars[charIndex]))
            {
                Console.Write(inputChars[charIndex]);
                charIndex++;
                continue;
            }

            Console.Write(words[wordIndex] + $"({wordIndex + 1})");
            charIndex += words[wordIndex].Length;
            wordIndex++;

            while (charIndex < inputChars.Length && delimiters.Contains(inputChars[charIndex]))
            {
                Console.Write(inputChars[charIndex]);
                charIndex++;
            }
        }
        Console.WriteLine();
    }
}
