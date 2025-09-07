using System;

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
        char[] delimiters = { ' ', ',', '-' };
        string[] words = content.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        int wordIndex = 0;
        string result = string.Empty;
        int currentWordStart = 0;

        foreach (string word in words)
        {
            int wordPosition = content.IndexOf(word, currentWordStart);

            result += content.Substring(currentWordStart, wordPosition - currentWordStart);

            // Добавляем слово с индексом
            result += $"{word}({++wordIndex})";

            // Обновляем текущую позицию
            currentWordStart = wordPosition + word.Length;
        }

        if (currentWordStart < content.Length)
        {
            result += content.Substring(currentWordStart);
        }

        Console.WriteLine(result + ".");
    }
}
