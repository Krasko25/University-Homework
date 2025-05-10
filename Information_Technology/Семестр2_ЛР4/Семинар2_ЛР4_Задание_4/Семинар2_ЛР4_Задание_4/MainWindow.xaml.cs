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

namespace Семинар2_ЛР4_Задание_4
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
                double x = Convert.ToDouble(XInput.Text);
                int n = Convert.ToInt32(NInput.Text);

                double result = 1;
                for (int k = 0; k <= n; k++)
                {
                  
                    result *= (1 + Math.Sin(k * x) / (4 * x - k));
                }

                ResultTextBlock.Text = $"S(x) = {result}";
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Ошибка ввода!";
            }
        }
    }
}