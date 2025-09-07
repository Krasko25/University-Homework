using System;

class Program
{
    //функция для циклического сдвига массива на k позиций влево
    static void LeftShiftArray(int[] arr, int k)
    {
        int n = arr.Length;              //размер массива
        k = k % n;                       //оптимизация для k, превышающих длину массива
        int[] temp = new int[k];         //временный массив для хранения первых k элементов

        //копирование первых k элементов во временный массив
        for (int i = 0; i < k; i++)
        {
            temp[i] = arr[i];
        }

        //сдвиг оставшихся элементов массива на k позиций влево
        for (int i = 0; i < n - k; i++)
        {
            arr[i] = arr[i + k];
        }

        //перенос элементов из временного массива в конец основного массива
        for (int i = 0; i < k; i++)
        {
            arr[n - k + i] = temp[i];
        }
    }

    //функция для вывода массива на экран
    static void PrintArray(int[] arr)
    {
        foreach (int element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Задание 3:\n\n");
        //запрос размера массива и количества позиций для сдвига
        Console.Write("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество позиций для сдвига: ");
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        
        //заполнение массива случайными числами от 1 до 100
        Console.WriteLine("Исходный массив: ");
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            arr[i] = rand.Next(1, 101); //генерация случайного числа в диапазоне [1, 100]
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        //вызов функции для циклического сдвига массива на k позиций влево
        LeftShiftArray(arr, k);

        //вывод сдвинутого массива
        Console.WriteLine("Сдвинутый массив: ");
        PrintArray(arr);
    }
}
