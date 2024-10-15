using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nИндивидуальное задание 1\n\n");
        
        // Ввод сторон треугольника
        Console.Write("Сторона a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Сторона b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Сторона c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        // Проверка на отрицательные значения
        if (a < 0 || b < 0 || c < 0){
            Console.WriteLine("Error");
            return; // Завершение программы
        }

        // Проверка
        bool flag = false;

        if (a == b){
            flag = true;}
        else if (a == c){
            flag = true;}
        else if (b == c){
            flag = true;}

        if (flag){
            Console.WriteLine("true");
        }
        else{
            Console.WriteLine("false");
        }

    }
}

