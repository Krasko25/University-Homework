using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ_ЛР10_Красько_ИВТ_4_2курс
{
    public partial class Form1 : Form
    {
        float xmin = 0.5f, xmax = 9.5f, ymin = 0.15f, ymax = 6.3f;
        Graphics dc; Pen p;
        public Form1()
        {
            InitializeComponent();
            dc = pictureBox.CreateGraphics();
            p = new Pen(Brushes.Red, 1);
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
            double yy = pictureBox.Size.Height - y * (pictureBox.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }
        /* Своя функция вычечивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        /* Метод получение кода положения точки относительно окна по алгоритму Коєна-Сазерленда */
        private uint code(double x, double y)
        {
            return (uint)((Convert.ToUInt16(x < xmin) << 3) |
            (Convert.ToUInt16(x > xmax) << 2) |
            (Convert.ToUInt16(y < ymin) << 1) |
            Convert.ToUInt16(y > ymax));
        }
        /* Метод отсечения линий */
        private void clip(double x1, double y1, double x2, double y2)
        {
            uint c1;
            uint c2;
            double dx, dy;
            c1 = code(x1, y1);
            c2 = code(x2, y2);

            while ((c1 | c2) != 0)
            {
                if ((c1 & c2) != 0) return;
                dx = x2 - x1;
                dy = y2 - y1;
                if (c1 != 0)
                {
                    if (x1 < xmin) { y1 += dy * (xmin - x1) / dx; x1 = xmin; }
                    else
                    if (x1 > xmax) { y1 += dy * (xmax - x1) / dx; x1 = xmax; }
                    else
                    if (y1 < ymin) { x1 += dx * (ymin - y1) / dy; y1 = ymin; }
                    else
                    if (y1 > ymax) { x1 += dx * (ymax - y1) / dy; y1 = ymax; }
                    c1 = code(x1, y1);
                }
                else
                {
                    if (x2 < xmin) { y2 += dy * (xmin - x2) / dx; x2 = xmin; }
                    else
                    if (x2 > xmax) { y2 += dy * (xmax - x2) / dx; x2 = xmax; }
                    else
                    if (y2 < ymin) { x2 += dx * (ymin - y2) / dy; y2 = ymin; }
                    else
                    if (y2 > ymax) { x2 += dx * (ymax - y2) / dy; y2 = ymax; }
                    c2 = code(x2, y2);
                }
            }
            Draw(x1, y1, x2, y2); // Соединяем точки линией
        }
        /* Основной код программы */
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            double pi, alpha, phi0, x0, y0, x1, y1, x2, y2;
            pi = 4.0 * Math.Atan(1.0);
            alpha = 72.0 * pi / 180.0; phi0 = 0.0; x0 = 4.0; y0 = 4.0;
            /* Вычерчивание границ окна */
            Draw(xmin, ymin, xmax, ymin); Draw(xmax, ymin, xmax, ymax);
            Draw(xmax, ymax, xmin, ymax); Draw(xmin, ymax, xmin, ymin);

            double x_stretch = 1.5; // чтоб ромб был вытянутым
            double y_stretch = 0.7;
            double rotation = 30 * Math.PI / 180; // чтобы ромб был повёрнут

            for (double r = 0.5; r < 10.5; r += 0.5)
            {
                double[] vx = new double[4];
                double[] vy = new double[4];
                
                // координаты четырёх вершин ромба
                for (int k = 0; k < 4; k++)
                {
                    double phi = k * Math.PI / 2; // 0, 90, 180, 270
                    // Смещение относительно центра без поворота
                    double x_rel = r * x_stretch * Math.Cos(phi);
                    double y_rel = r * y_stretch * Math.Sin(phi);

                    // Поворачиваем смещение
                    double x_rot = x_rel * Math.Cos(rotation) - y_rel * Math.Sin(rotation);
                    double y_rot = x_rel * Math.Sin(rotation) + y_rel * Math.Cos(rotation);
                    vx[k] = x0 + x_rot;
                    vy[k] = y0 + y_rot;
                }

                // Рисуем стороны ромба с отсечением
                for (int i = 0; i < 4; i++)
                {
                    int next = (i + 1) % 4;
                    clip(vx[i], vy[i], vx[next], vy[next]);
                }
            }

            /* Подпись к лабораторной работе */
            string str = "Лабораторная работа No10.";
            Brush blueBrush = Brushes.Red;
            Font boldTimesFont = new Font("Times New Roman", 14, FontStyle.Bold);
            SizeF sizefText = dc.MeasureString(str, boldTimesFont);
            dc.DrawString(str, boldTimesFont, blueBrush, (pictureBox.Size.Width -
            sizefText.Width) / 2, 10);
        }
    }
}
