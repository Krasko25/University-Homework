using System;

class Program
{
    //функция для создания массива и заполнения его случайными числами
    static int[] GenerateRandomArray(int length)
    {
        int[] numbers = new int[length];
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            numbers[i] = random.Next(-30, 46); //диапазон от -30 до 45 включительно
        }

        return numbers;
    }

    //функция для вывода массива строками по 10 элементов
    static void DisplayArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + "\t");
            
            //после каждых 10 элементов делаем перенос строки
            if ((i + 1) % 10 == 0)
                Console.WriteLine();
        }
        
        Console.WriteLine(); //перенос строки после вывода всего массива
    }

    //функция для вывода массива в обратном порядке, игнорируя отрицательные элементы
    static void DisplayArrayReverseNonNegative(int[] numbers)
    {
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            if (numbers[i] >= 0)
            {
                Console.Write(numbers[i] + "\t");
            }
        }
        
        Console.WriteLine(); //перенос строки после вывода всех элементов
    }

    static void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        int arraySize;

        //проверка корректного ввода числа
        while (!int.TryParse(Console.ReadLine(), out arraySize) || arraySize <= 0)
        {
            Console.WriteLine("Пожалуйста, введите положительное целое число.");
        }

        //создаем и заполняем массив случайными числами
        int[] randomNumbers = GenerateRandomArray(arraySize);

        Console.WriteLine("\nМассив, заполненный случайными числами:");
        DisplayArray(randomNumbers);

        Console.WriteLine("\nМассив в обратном порядке (только положительные элементы):");
        DisplayArrayReverseNonNegative(randomNumbers);
    }
}
