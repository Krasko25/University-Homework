﻿using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nЗадание 3. Ряд Фибоначчи\n\n");
        
         //Первые два числа ряда Фибоначчи
        int f0 = 1, f1 = 1;

        //счётчик четырёхзначных чисел
        int counter = 0;

        //число Фибоначчи
        int F = 0;

        //После 10000 четырехзначных чисел не будет
        while (F < 10000)
        {
            F = f0 + f1;

            // Проверяем, является ли оно четырёхзначным
            if (F >= 1000 && F <= 9999)
            {
                counter++;
            }

            // Переход к следующему числу в ряде
            f0 = f1;
            f1 = F;
        }

        // Выводим результат
        Console.WriteLine($"Количество четырёхзначных чисел" + 
        $"в ряде Фибоначчи: {counter}\n\n");
    }
}

