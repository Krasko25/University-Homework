using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nЗадание 2. Нахождение числа Pi\n\n");
        
        //ввод количества слагаемых
        Console.Write("Введите количество слагаемых для " +
        "вычисления pi: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double pi = 0;

        //вычисление π
        for (int i = 0; i < n; i++)
        {
            // Чередование знаков
            if (i % 2 == 0)
            {
                pi += 1.0 / (2 * i + 1);
            }
            else
            {
                pi -= 1.0 / (2 * i + 1);
            }
        }

        // Умножаем результат на 4, чтобы получить pi
        pi *= 4;

        // Вывод результата
        Console.WriteLine($"Число Pi = {pi}");
    }
}

