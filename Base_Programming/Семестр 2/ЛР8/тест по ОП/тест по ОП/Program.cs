using System;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 3, 10, 5, 7, 6, 4, 12, 20, 9, 11, 22, 24, 25 };

        // Сортируем массив т.к. для интерполяционного поиска нужен отсортированный массив
        Array.Sort(arr);
        Console.WriteLine("Отсортированный массив:");
        Console.WriteLine(string.Join(" ", arr));

        int target = 20;  // Число для поиска
        int low = 0;
        int high = arr.Length - 1;
        int step = 0;

        while (low <= high && target >= arr[low] && target <= arr[high])
        {
            // Вычисляем индекс предполагаемой позиции
            int pos = low + ((target - arr[low]) * (high - low)) / (arr[high] - arr[low]);

            step++;
            Console.WriteLine($"Шаг {step}: Проверяем позицию {pos}, значение в массиве {arr[pos]}");

            // Если нашли элемент
            if (arr[pos] == target)
            {
                Console.WriteLine($"Число {target} найдено на позиции {pos}.");
                return;
            }
            // Если значение меньше, ищем в левой части
            if (arr[pos] > target)
            {
                high = pos - 1;
            }
            // Если значение больше, ищем в правой части
            else
            {
                low = pos + 1;
            }
        }

        Console.WriteLine($"Число {target} не найдено.");
    }
}
