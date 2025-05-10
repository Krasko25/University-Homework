using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Семестр2_ЛР4_Задание_3
{
    public partial class MainWindow : Window
    {
        private int num1;
        private int num2;

        public MainWindow()
        {
            InitializeComponent();
            Random rand = new Random();
            num1 = rand.Next(3, 5); 
            num2 = rand.Next(3, 5); 
        }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int guess1 = Convert.ToInt32(FirstGuess.Text);
                int guess2 = Convert.ToInt32(SecondGuess.Text);

                // Проверяем, что введенные числа в пределах допустимого диапазона (0-9)
                if (guess1 < 0 || guess1 > 9 || guess2 < 0 || guess2 > 9)
                {
                    ResultTextBlock.Text = "Числа должны быть от 0 до 9!";
                    return;
                }

                // Проверка, совпали ли числа
                if ((guess1 == num1 && guess2 == num2) || (guess1 == num2 && guess2 == num1))
                {
                    ResultTextBlock.Text = "Вы выиграли!";
                }
                else
                {
                    ResultTextBlock.Text = "Попробуйте снова!";

                    // Задержка на 1 секунду, затем очищаем для интерактивности
                    await Task.Delay(1000);  
                    ResultTextBlock.Text = "";
                }
            }
            catch (FormatException)
            {
                ResultTextBlock.Text = "Введите правильные числа!";
            }
        }
    }
}