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

namespace Семестр2_ЛР4_Задание_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(SideA.Text);
                double b = Convert.ToDouble(SideB.Text);
                double c = Convert.ToDouble(SideC.Text);

                // Полупериметр
                double p = (a + b + c) / 2;

                // Площадь
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                ResultTextBlock.Text = $"Площадь: {area:F2}";
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Некорректный ввод!";
            }
        }
    }
}