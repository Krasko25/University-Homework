using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите полный путь к файлу:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);

            string[] words = fileContent.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Словарь для подсчета частоты слов
            Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in words)
            {
                string cleanedWord = word.Trim().ToLower();
                if (wordCounts.ContainsKey(cleanedWord))
                {
                    wordCounts[cleanedWord]++;
                }
                else
                {
                    wordCounts[cleanedWord] = 1;
                }
            }

            // Сортировка по частоте и по алфавиту в случае равенства
            var sortedWords = wordCounts.OrderByDescending(kvp => kvp.Value)
                                        .ThenBy(kvp => kvp.Key) 
                                        .Take(10);

            Console.WriteLine("\n10 наиболее встречаемых слов:");
            foreach (var kvp in sortedWords)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        else
        {
            Console.WriteLine("Ошибка! Файл не существует по указанному пути.");
        }
    }
}
