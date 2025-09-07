using System;

class Program
{
    //рекурсивная функция для нахождения n-ого члена ряда Фибоначчи
    static int Fibonacci(int n)
    {
        //базовые случаи
        if (n == 0)
            return 0; //F(0) = 0
        if (n == 1)
            return 1; //F(1) = 1

        //рекурсивный вызов для вычисления F(n)
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static void Main()
    {
        Console.Write("Задание 7:\n\n");
        //ввод значения n
        Console.Write("Введите значение n (n >= 0): ");
        int n = int.Parse(Console.ReadLine());

        //вычисление n-ого члена ряда Фибоначчи
        int result = Fibonacci(n);

        //вывод результата
        Console.WriteLine($"n-ый член ряда Фибоначчи для n = {n} равен: {result}");
    }
}
