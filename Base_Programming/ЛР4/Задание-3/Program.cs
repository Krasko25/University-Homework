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

        char[] delimiters = { ' ', ',', '-' };
        char[] inputChars = input[..^1].ToCharArray(); // Убираем точку
        string[] words = SplitToWords(inputChars, delimiters);
        Array.Reverse(words);
        Console.WriteLine(string.Join(" ", words) + ".");
    }

    static string[] SplitToWords(char[] input, char[] delimiters)
    {
        var words = new System.Collections.Generic.List<string>();
        int start = -1;

        for (int i = 0; i < input.Length; i++)
        {
            if (Array.Exists(delimiters, d => d == input[i]) || i == input.Length - 1)
            {
                if (start != -1)
                {
                    int length;
                    if (i == input.Length - 1 && !Array.Exists(delimiters, d => d == 
                    input[i]))
                    {
                        length = i - start + 1;
                    }
                    else
                    {
                        length = i - start;
                    }

                    words.Add(new string(input, start, length));
                    start = -1;
                }
            }
            else if (start == -1)
            {
                start = i;
            }
        }

        return words.ToArray();
    }
}
