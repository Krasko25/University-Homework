using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nИндивидуальное задание 2\n\n");
        
        Console.WriteLine("Трехзначные числа, у которых первая и третья цифры совпадают:");

        // Перебор всех трехзначных чисел
        for (int number = 100; number <= 999; number++)
        {
            int firstDigit = number / 100;      // Первая цифра
            int thirdDigit = number % 10;       // Третья цифра

            // Проверка на совпадение
            if (firstDigit == thirdDigit)
            {
                Console.WriteLine(number);
            }
        }
    }
}

