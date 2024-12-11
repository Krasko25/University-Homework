using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку с математической операцией (например, '17 + 40 = 57'):");
        string input = Console.ReadLine();

        // Регулярное выражение для поиска чисел, оператора и результата
        Regex regex = new Regex
            (@"^\s*(-?\d+)\s*([+-/*])\s*(-?\d+)\s*=\s*(-?\d+)\s*$");

        Match match = regex.Match(input);

        if (match.Success)
        {
            // Извлекаем операнды и результат
            int operand1 = int.Parse(match.Groups[1].Value);
            string operatorSign = match.Groups[2].Value;
            int operand2 = int.Parse(match.Groups[3].Value);
            int result = int.Parse(match.Groups[4].Value);

            // Выводим на консоль все извлеченные значения
            Console.WriteLine($"Операнд 1: {operand1}");
            Console.WriteLine($"Оператор: {operatorSign}");
            Console.WriteLine($"Операнд 2: {operand2}");
            Console.WriteLine($"Результат: {result}");
        }
        else
        {
            Console.WriteLine("Строка не соответствует формату.");
        }
    }
}
