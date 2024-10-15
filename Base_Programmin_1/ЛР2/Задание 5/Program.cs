using System;

class Program
{
    static void Main()
    {
        Console.Write("\n\nЗадание 5. Комбинации чисел\n\n");
        
        int N;

        // Проверка N на натуральность
        while (true){
            Console.Write("Введите натуральное число N: ");
            N = Convert.ToInt32(Console.ReadLine());
            if (N > 0){
                break; // Если число натуральное, выходим из цикла
            }
            else{
                Console.WriteLine("Вы должны были ввести " +
                "положительное целое число.");
            }
        }

        bool found = false; // Флаг для определения, найдена ли хотя бы одна комбинация

        // Перебираем все комбинации
        for (int x = 1; x * x * x <= N; x++){
            for (int y = 1; y * y * y <= N; y++){
                for (int z = 1; z * z * z <= N; z++){
                    if (x * x * x + y * y * y + z * z * z == N){
                        Console.WriteLine($"x = {x}, y = {y}, z = {z}");
                        found = true;
                    }
                }
            }
        }

        // Если не найдена ни одна комбинация
        if (!found){
            Console.WriteLine("No such combinations!");
        }
    }
}

