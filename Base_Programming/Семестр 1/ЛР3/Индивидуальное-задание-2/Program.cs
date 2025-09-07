using System;

class Program
{
    static void Main()
    {
        Console.Write("Индивидуальное задание 2. Вариант 8:\n\n");
        int size = 50; //задаём размер массива
        int[] array = new int[size];

        //заполняем массив случайными числами
        FillArray(array);
        
        //выводим массив
        Console.WriteLine("Массив:");
        PrintArray(array);

        //считаем отрицательные числа в обеих половинах массива
        int firstHalfNegatives = CountNegatives(array, 0, size / 2);
        int secondHalfNegatives = CountNegatives(array, size / 2, size);

        //сравниваем количество отрицательных чисел и выводим результат
        if (firstHalfNegatives > secondHalfNegatives)
            Console.WriteLine("Ответ: 1"); 
        else if (firstHalfNegatives < secondHalfNegatives)
            Console.WriteLine("Ответ: 2");
        else
            Console.WriteLine("Ответ: 0"); 
    }

    //функция для заполнения массива случайными числами
    static void FillArray(int[] array)
    {
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(-10, 10); //заполняем числами от -10 до 9
        }
    }

    //функция для вывода массива
    static void PrintArray(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    //функция для подсчета отрицательных чисел в части массива
    static int CountNegatives(int[] array, int start, int end)
    {
        int count = 0;
        for (int i = start; i < end; i++)
        {
            if (array[i] < 0)
                count++;
        }
        return count;
    }
}
