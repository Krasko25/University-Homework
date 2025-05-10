using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Семестр2_ЛР4_Задание_1
{
    public partial class MainWindow : Window
    {
        private int[,] matrix;
        private int size;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Нажате кнопки для создания матрицы
        private void OnCreateMatrixButtonClick(object sender, RoutedEventArgs e)
        {
            // Проверяем, что пользователь ввел размер
            if (int.TryParse(SizeTextBox.Text, out size) && size > 0)
            {
                matrix = new int[size, size];

                // Заполняем матрицу случайными числами
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i, j] = random.Next(1, 100);
                    }
                }

                MatrixDataGrid.ItemsSource = ConvertMatrixToDataTable(matrix).DefaultView;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите размер матрицы.", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Нажатия кнопки для обработки матрицы
        private void OnProcessButtonClick(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Сначала создайте матрицу.", "Ошибка", MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }

            // Находим минимальный элемент в матрице
            int minValue = matrix[0, 0];
            int minRow = 0, minCol = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
                }
            }

            // Заменяем все элементы в строке и столбце на минимальное значение
            for (int i = 0; i < size; i++)
            {
                matrix[minRow, i] = minValue; 
                matrix[i, minCol] = minValue; 
            }

            // Обновляем отображение матрицы в DataGrid
            MatrixDataGrid.ItemsSource = ConvertMatrixToDataTable(matrix).DefaultView;
        }

        // Преобразование матрицы в DataTable
        private DataTable ConvertMatrixToDataTable(int[,] matrix)
        {
            var table = new DataTable();
            for (int i = 0; i < size; i++)
            {
                table.Columns.Add($"Column{i + 1}");
            }

            for (int i = 0; i < size; i++)
            {
                var row = table.NewRow();
                for (int j = 0; j < size; j++)
                {
                    row[j] = matrix[i, j];
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}