using System;
using System.IO;

class Program
{
    // Функция для записи пар чисел
    static void WritePairsToFile(string filePath)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int N = 1; N <= 100; N++)
            {
                writer.Write(N);            // Записываем число N
                writer.Write(1.0 / N);      // Записываем число 1/N
            }
        }
        Console.WriteLine("Данные записаны в файл: " + filePath);
    }

    // Функция для записи всех вторых чисел в новый файл
    static void WriteSecondNumbersToFile(string inputFilePath, string outputFilePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(inputFilePath, FileMode.Open)))
        using (BinaryWriter writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int N = reader.ReadInt32();        // Считываем N
                double secondNumber = reader.ReadDouble();  // Считываем 1/N

                // Записываем только второе число
                writer.Write(secondNumber);
            }
        }
        Console.WriteLine("Вторые числа записаны в файл: " + outputFilePath);
    }

    // Функция для чтения и вывода данных из файла
    static void ReadAndDisplayFile(string filePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            Console.WriteLine($"Содержимое файла {filePath}:");
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                double number = reader.ReadDouble();  
                Console.WriteLine(number);  
            }
        }
    }

    static void Main()
    {
        // Пути к файлам
        string inputFilePath = "generater_data.dat";
        string outputFilePath = "processed_data.dat";

        WritePairsToFile(inputFilePath);

        WriteSecondNumbersToFile(inputFilePath, outputFilePath);

        ReadAndDisplayFile(outputFilePath);
    }
}
