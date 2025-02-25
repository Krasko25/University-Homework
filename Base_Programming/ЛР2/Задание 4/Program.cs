using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nЗадание 4. Ряд Тейлора\n\n");
        
        //Ввод значений
        Console.Write("x (радианы): ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("q (точность): ");
        double q = Convert.ToDouble(Console.ReadLine());

        int sign = -1; // Для чередования знаков
        double factorial = 1;
        double sum = 1; // Первое слагаемое
        double temporary = 1; // Текущее слагаемое
        int n = 0; // Счётчик слагаемых

        while (Math.Abs(temporary) >= q)
        {
            n++;

            // Обновляем факториал
            factorial *= (2 * n - 1) * (2 * n); 


            temporary = Math.Pow(x, 2 * n) / factorial;
            sum += sign * temporary;

            // Меняем знак для следующего слагаемого
            sign *= -1;
        }

        // Вывод результата
        Console.WriteLine($"Примерный cos({x}) = {sum}");
        Console.WriteLine($"Количество учтенных слагаемых: {n}");
    }
}

