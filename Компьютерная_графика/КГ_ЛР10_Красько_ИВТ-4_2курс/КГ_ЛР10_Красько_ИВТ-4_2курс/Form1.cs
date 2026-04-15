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

        /* Своя функция вычерчивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }

        //Метод отсечения линий
        private void clip(double x1, double y1, double x2, double y2)
        {
            // центр в середине прямоугольника, полуоси равны половинам сторон
            double cx = (xmin + xmax) / 2.0;
            double cy = (ymin + ymax) / 2.0;
            double a = (xmax - xmin) / 2.0;
            double b = (ymax - ymin) / 2.0;

            double F1(double x, double y) => 1.0 - (x - cx) / a - (y - cy) / b;
            double F2(double x, double y) => 1.0 - (cx - x) / a - (y - cy) / b;
            double F3(double x, double y) => 1.0 - (cx - x) / a - (cy - y) / b;
            double F4(double x, double y) => 1.0 - (x - cx) / a - (cy - y) / b;

            var sides = new Func<double, double, double>[] { F1, F2, F3, F4 };
            double t0 = 0.0, t1 = 1.0;
            double dx = x2 - x1;
            double dy = y2 - y1;
            foreach (var F in sides)
            {
                double p1 = F(x1, y1);
                double p2 = F(x2, y2);

                if (p1 < 0 && p2 < 0) // отрезок полностью вне этой стороны
                    return;
                if (p1 >= 0 && p2 >= 0) // отрезок полностью внутри
                    continue;

                // Одна из точек снаружи, ищем пересечение
                double t = p1 / (p1 - p2);

                if (p1 < 0)
                    t0 = Math.Max(t0, t);
                else
                    t1 = Math.Min(t1, t);
            }

            if (t0 <= t1)
            {
                double newX1 = x1 + t0 * dx;
                double newY1 = y1 + t0 * dy;
                double newX2 = x1 + t1 * dx;
                double newY2 = y1 + t1 * dy;
                Draw(newX1, newY1, newX2, newY2);
            }
        }

        /* Основной код программы */
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            double pi, alpha, phi0, x0, y0, x1, y1, x2, y2;
            pi = 4.0 * Math.Atan(1.0);
            alpha = 72.0 * pi / 180.0; phi0 = 0.0; x0 = 4.0; y0 = 4.0;

            double cx = (xmin + xmax) / 2.0;
            double cy = (ymin + ymax) / 2.0;
            double a = (xmax - xmin) / 2.0;
            double b = (ymax - ymin) / 2.0;

            /* Вычерчивание границ окна */
            double[] vx = { cx + a, cx, cx - a, cx };
            double[] vy = { cy, cy + b, cy, cy - b };
            for (int i = 0; i < 4; i++)
                Draw(vx[i], vy[i], vx[(i + 1) % 4], vy[(i + 1) % 4]);

            double x_stretch = 1.5; // чтоб ромб был вытянутым
            double y_stretch = 0.7;
            double rotation = 30 * Math.PI / 180; // чтобы ромб был повёрнут

            for (double r = 0.5; r < 10.5; r += 0.5)
            {
                double[] romb_x = new double[4];
                double[] romb_y = new double[4];

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
                    romb_x[k] = x0 + x_rot;
                    romb_y[k] = y0 + y_rot;
                }

                // Рисуем стороны ромба с отсечением
                for (int i = 0; i < 4; i++)
                {
                    int next = (i + 1) % 4;
                    clip(romb_x[i], romb_y[i], romb_x[next], romb_y[next]);
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