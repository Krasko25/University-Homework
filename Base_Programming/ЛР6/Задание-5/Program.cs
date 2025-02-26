using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя BMP-файла:");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                // Чтение заголовка файла
                byte[] fileHeader = new byte[14];
                fs.Read(fileHeader, 0, 14);

                // Проверка сигнатуры BMP
                if (fileHeader[0] != 'B' || fileHeader[1] != 'M')
                {
                    Console.WriteLine("Это не BMP файл.");
                    return;
                }

                // Чтение заголовка изображения
                byte[] dibHeader = new byte[40];
                fs.Read(dibHeader, 0, 40);
                int fileSize = BitConverter.ToInt32(fileHeader, 2);
                // Смещение к пиксельным данным
                int offset = BitConverter.ToInt32(fileHeader, 10);
                int width = BitConverter.ToInt32(dibHeader, 4);
                int height = BitConverter.ToInt32(dibHeader, 8);
                short bitsPerPixel = BitConverter.ToInt16(dibHeader, 14);
                // Количество пикселей на метр горизонтально
                int horResolution = BitConverter.ToInt32(dibHeader, 24);
                // Количество пикселей на метр вертикально
                int verResolution = BitConverter.ToInt32(dibHeader, 28);
                // Тип сжатия
                int compression = BitConverter.ToInt32(dibHeader, 16);

                // Вывод информации
                Console.WriteLine($"Размер файла: {fileSize} байт");
                Console.WriteLine($"Ширина изображения: {width} пикселей");
                Console.WriteLine($"Высота изображения: {height} пикселей");
                Console.WriteLine($"Бит на пиксель: {bitsPerPixel}");

                Console.WriteLine($"Горизонтальное разрешение: {horResolution} пикселей/метр");
                Console.WriteLine($"Вертикальное разрешение: {verResolution} пикселей/метр");

                // Определение типа сжатия
                string compressionType = compression switch
                {
                    0 => "Без сжатия",
                    1 => "RLE 4-бит",
                    2 => "RLE 8-бит",
                    _ => "Неизвестный тип сжатия"
                };
                Console.WriteLine($"Тип сжатия: {compressionType}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
        }
    }
}
