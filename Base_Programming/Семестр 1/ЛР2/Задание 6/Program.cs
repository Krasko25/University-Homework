using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nЗадание 6\n\n");
        
        int N;

        // Проверка на число из диапозона
        while (true){
            Console.Write("Введите число N (от 1 до 100): ");
            N = Convert.ToInt32(Console.ReadLine());

            if (N >= 1 && N <= 100){
                break; 
            }
            else{
                Console.WriteLine("Введите число в диапазоне от 1 до 100.");
            }
        }

        // Определяем окончание в зависимости от значения N
        string ending;
        if (N % 10 == 1 && N % 100 != 11){
            ending = "год";
        }
        else if ((N % 10 >= 2 && N % 10 <= 4) && (N % 100 < 12 || N % 100 > 14)){
            ending = "года";
        }
        else{
            ending = "лет";
        }

        // Выводим результат
        Console.WriteLine($"{N} {ending}");


    }
}

