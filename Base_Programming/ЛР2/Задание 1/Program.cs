using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nЗадание 1. Решение квадратного уравнения\n\na: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        //вычисление дискриминанта
        double D = b * b - 4 * a * c;

        if (D > 0) //два корня
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine($"Корни уравнения: \nx1 = {x1},\nx2 = {x2}");
        }
        else if (D == 0) //один корень
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Корень уравнения: \nx = {x}");
        }
        else //нет действительных корней
        {
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-D) / (2 * a);
            Console.WriteLine($"Комплексные корни: x1 = " +
            $"{realPart} + {imaginaryPart}i, \nx2 = {realPart} - " +
            $"{imaginaryPart}i");
        }
    }
}

