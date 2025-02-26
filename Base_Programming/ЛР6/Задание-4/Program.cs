using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFilePath = @"C:\Users\Mikhail\Documents\repos\University-Homework\Base_Programming\ЛР6\Задание-1\bin\Debug\net8.0\lab.dat";

        string destinationDirectory = @"D:\backups\Lab6_Temp";

        string destinationFilePath = Path.Combine(destinationDirectory, "lab.dat");

        string backupFilePath = Path.Combine(destinationDirectory, "lab_backup.dat");

        try
        {
            // Создаем директорию, если она не существует
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
                Console.WriteLine($"Директория {destinationDirectory} была создана.");
            }

            // Проверяем, существует ли исходный файл
            if (File.Exists(sourceFilePath))
            {
                // Копируем файл lab.dat в новую директорию
                File.Copy(sourceFilePath, destinationFilePath, true);
                Console.WriteLine($"Файл {sourceFilePath} скопирован в {destinationFilePath}");

                // Создаем резервную копию lab.dat побайтово
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream backupStream = new FileStream(backupFilePath, FileMode.Create, FileAccess.Write))
                {
                    int byteRead;
                    while ((byteRead = sourceStream.ReadByte()) != -1)
                    {
                        backupStream.WriteByte((byte)byteRead);
                    }
                }
                Console.WriteLine($"Резервная копия файла создана в {backupFilePath}");

                // Записываем информацию о файле lab.dat
                FileInfo fileInfo = new FileInfo(sourceFilePath);

                Console.WriteLine("\nИнформация о файле lab.dat:");
                Console.WriteLine($"Размер: {fileInfo.Length} байт");
                Console.WriteLine($"Время последнего изменения: {fileInfo.LastWriteTime}");
                Console.WriteLine($"Время последнего доступа: {fileInfo.LastAccessTime}");
            }
            else
            {
                Console.WriteLine($"Файл {sourceFilePath} не найден.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
