using System;

class Program
{
    //обработка строки как массива символов
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        Console.WriteLine("\nСлова, начинающиеся с заглавной латинской буквы и" +  
        "заканчивающиеся на 2 цифры:");
        string[] words = input.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' },
        StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (IsMatchingWord(word))
            {
                Console.WriteLine(word);
            }
        }
    }

    static bool IsMatchingWord(string word)
    {
        if (word.Length < 3) return false; // Слово должно быть минимум длиной 3 символа

        // Первый символ должен быть заглавной латинской буквой (A-Z)
        if (word[0] < 'A' || word[0] > 'Z') return false;

        // Последние два символа должны быть цифрами
        int length = word.Length;
        if (!char.IsDigit(word[length - 1]) || !char.IsDigit(word[length - 2])) 
            return false;

        return true;
    }
}
