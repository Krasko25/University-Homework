using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ_ЛР13_Красько_ИВТ_4_2курс
{
    public partial class Form1 : Form
    {
        const int NMAX = 100;
        const double BIG = 1.0e30;
        Graphics dc; Pen p;
        int n; int[] v;
        double[] x, y;
        public Form1()
        {
            InitializeComponent();
            dc = pictureBox.CreateGraphics();
            p = new Pen(Brushes.Black, 2);
            x = new double[NMAX];
            y = new double[NMAX];
            v = new int[NMAX];
        }
        /* Метод преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }
        /* Метод преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox.Size.Height - y *

            (pictureBox.Size.Height / 7.0) + 0.5;

            return (int)yy;
        }
        /* Функция вычерчивания линии (экран 10х7 условн. единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        // Функция вычисления длины диагонали
        private bool counter_clock(int h, int i, int j, ref
        double pdist)

        {
        
            double xh = x[v[h]], xi = x[v[i]], xj = x[v[j]],
            yh = y[v[h]], yi = y[v[i]], yj = y[v[j]],
            x_hi, y_hi, x_hj, y_hj, Determ;

            x_hi = xi - xh; y_hi = yi - yh;
            x_hj = xj - xh; y_hj = yj - yh;
            pdist = x_hj * x_hj + y_hj * y_hj;
            Determ = x_hi * y_hj - x_hj * y_hi;
            return (Determ > 1e-6);
        }
        /* Функция рисования полигона */
        private void draw_polygon()
        {
            int i; double xold, yold;
            xold = x[n - 1]; yold = y[n - 1];
            for (i = 0; i < n; i++)
            {
                Draw(xold, yold, x[i], y[i]);
                xold = x[i]; yold = y[i];
            }
        }
        /* Главная функция разбиения полигона на треугольники */
        private void poly_Tria()
        {
            int i, h, j, m, k, imin = 0;
            double diag = 0, min_diag;
            /* Заполнение массива v номерами вершин */
            for (i = 0; i < n; i++) { v[i] = i; }
            /* Отрисовка полигона */
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            draw_polygon();
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            m = n;
            while (m > 3)
            {
                min_diag = BIG;
                for (i = 0; i < m; i++)
                {
                    /* h - предыдущая вершина, i - текущая, j - следующая */
                
                    if (i == 0) h = m - 1; else h = i - 1;
                    if (i == m - 1) j = 0; else j = i + 1;
                    /* Запоминаем самую короткую диагональ */
                    if (counter_clock(h, i, j, ref diag) && (diag < min_diag))
                    { min_diag = diag; imin = i; }
                }
                i = imin;
                if (i == 0) h = m - 1; else h = i - 1;
                if (i == m - 1) j = 0; else j = i + 1;
                if (min_diag == BIG)
                {
                    var result = MessageBox.Show("Неправильное направление обхода!", "Ошибка!",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    Application.Exit();
                }
                /* Вывод шриховой линии между вершинами h и j */
                Draw(x[v[h]], y[v[h]], x[v[j]], y[v[j]]);
                /* Уменьшение количества вершин */
                m--;
                /* Исключаем из последовательности вершин вершину i */
                for (k = i; k < m; k++) v[k] = v[k + 1];
            }
        }

        private bool ReadCoordinatesFromGrid()
        {
            if (!int.TryParse(textBoxVertexAmount.Text, out n) || n < 21 || n > NMAX)
            {
                MessageBox.Show($"Введите количество вершин от 21 до {NMAX}.", "Ошибка");
                return false;
            }
            //на случай, если не нажата кнопка ОК
            dataGridViewCoordinates.RowCount = n;

            for (int i = 0; i < n; i++)
            {
                var row = dataGridViewCoordinates.Rows[i];
                if (row.Cells[0].Value == null || row.Cells[1].Value == null ||
                    !double.TryParse(row.Cells[0].Value.ToString(), out x[i]) ||
                    !double.TryParse(row.Cells[1].Value.ToString(), out y[i]))
                {
                    MessageBox.Show($"Ошибка в строке {i + 1}: введите два вещественных числа", "Ошибка");
                    return false;
                }
            }
            return true;
        }

        private void buttonUpdateTable_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxVertexAmount.Text, out int N) || N < 21 || N > NMAX)
            {
                MessageBox.Show($"Введите целое число от 21 до {NMAX}.", "Ошибка");
                return;
            }
            dataGridViewCoordinates.RowCount = N;
            //Убираем старые числа
            for (int i = 0; i < N; i++)
            {
                dataGridViewCoordinates.Rows[i].Cells[0].Value = null;
                dataGridViewCoordinates.Rows[i].Cells[1].Value = null;
            }
        }

        private void labelVertexAmount_Click(object sender, EventArgs e)
        {

        }

        /* Основной код программы */
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            if (!ReadCoordinatesFromGrid())
                return;

            dc.Clear(Color.White);

            // Автомасштабирование
            double xmin = x.Take(n).Min();
            double xmax = x.Take(n).Max();
            double ymin = y.Take(n).Min();
            double ymax = y.Take(n).Max();
            double scaleX = 9.0 / (xmax - xmin);  
            double scaleY = 6.0 / (ymax - ymin);
            double scale = Math.Min(scaleX, scaleY);
            double offsetX = 0.5 - xmin * scale + (9.0 - scale * (xmax - xmin)) / 2.0;
            double offsetY = 0.5 - ymin * scale + (6.0 - scale * (ymax - ymin)) / 2.0;

            // Преобразуем координаты для отрисовки
            double[] scaledX = new double[n];
            double[] scaledY = new double[n];
            for (int i = 0; i < n; i++)
            {
                scaledX[i] = x[i] * scale + offsetX;
                scaledY[i] = y[i] * scale + offsetY;
            }

            Array.Copy(scaledX, x, n);
            Array.Copy(scaledY, y, n);

            poly_Tria();
        }
    }
}