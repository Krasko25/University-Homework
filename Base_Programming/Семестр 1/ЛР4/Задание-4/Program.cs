using System;

class Program
{
    static void Main()
    {
        string[] lines = new string[7];
        Console.WriteLine("Введите 7 строк:");
        for (int i = 0; i < 7; i++)
        {
            lines[i] = Console.ReadLine();
        }

        Console.WriteLine("\nСтроки, содержащие слова, оканчивающиеся на '.com':");
        for (int i = 0; i < lines.Length; i++)
        {
            char[] chars = lines[i].ToCharArray();
            bool hasCom = false;

            for (int j = 0; j < chars.Length - 3; j++)
            {
                if (chars[j] == '.' && 
                    (chars[j + 1] == 'c' || chars[j + 1] == 'C') && 
                    (chars[j + 2] == 'o' || chars[j + 2] == 'O') && 
                    (chars[j + 3] == 'm' || chars[j + 3] == 'M') && 
                    (j + 4 == chars.Length || chars[j + 4] == ' ' || chars[j + 4] ==
                        ',' || chars[j + 4] == '.'))
                {
                    hasCom = true;
                    break;
                }
            }

            if (hasCom)
            {
                Console.WriteLine(lines[i]);
            }
        }

        int minSpacesIndex = -1;
        int minSpacesCount = int.MaxValue;

        for (int i = 0; i < lines.Length; i++)
        {
            int spaces = 0;
            foreach (char c in lines[i])
            {
                if (c == ' ') spaces++;
            }

            if (spaces < minSpacesCount)
            {
                minSpacesCount = spaces;
                minSpacesIndex = i;
            }
        }

        Console.WriteLine($"\nСтрока с минимальным количеством пробелов находится под номером: {minSpacesIndex + 1}");
    }
}
