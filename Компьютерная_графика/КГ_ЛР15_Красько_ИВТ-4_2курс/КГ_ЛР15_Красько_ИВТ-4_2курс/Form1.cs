using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ_ЛР15_Красько_ИВТ_4_2курс
{
    public partial class Form : System.Windows.Forms.Form
    {
        Graphics dc; Pen p;
        /* Коэффициенты матрицы видового преобразования */
        double v11, v12, v13, v21, v22, v23, v32, v33, v43;
        /* Сферические координаты точки наблюдения */
        double rho = 120.0, theta = 20.0, phi = 75.0;
        /* Расстояние от точки наблюдения до экрана */
        double screen_dist = 120.0;
        /* Cмещение относительно левого нижнего угла экрана */
        double c1 = 5.0, c2 = 3.5;
        //Размеры параллелепипеда (половина ребра)
        double a = 2.5, b = 1.5, c = 2.0;

        bool timerRunning = false;

        public Form()
        {
            InitializeComponent();
            dc = pictureBox.CreateGraphics();
            p = new Pen(Brushes.Black, 2);

            trackBarTeta.Value = (int)theta;
            trackBarPhi.Value = (int)phi;

            // значение ползунка равно длине стороны * 10
            trackBarAside.Value = (int)(a * 10);
            trackBarBside.Value = (int)(b * 10);
            trackBarCside.Value = (int)(c * 10);

            labelTetaAngle.Text = $"θ = {theta}°";
            labelPhiAngle.Text = $"φ = {phi}°";
            labelAside.Text = $"A = {a:F1}";
            labelBside.Text = $"B = {b:F1}";
            labelCside.Text = $"C = {c:F1}";
        }

        /* Функция преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }

        /* Функция преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox.Size.Height - y *
                (pictureBox.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }

        /* Вычисление коэффициентов, не зависящих от вершин*/
        private void coeff(double rho, double theta, double phi)
        {
            double th, ph, costh, sinth, cosph, sinph, factor;
            factor = Math.PI / 180.0; // из градусов в радианы
            th = theta * factor;
            ph = phi * factor;
            costh = Math.Cos(th);
            sinth = Math.Sin(th);
            cosph = Math.Cos(ph);
            sinph = Math.Sin(ph);

            v11 = -sinth; v12 = -cosph * costh; v13 = -sinph * costh;
            v21 = costh; v22 = -cosph * sinth; v23 = -sinph * sinth;
            v32 = sinph; v33 = -cosph; v43 = rho;
        }

        /* Функция видового и перспективного преобразования координат */
        private void perspective(double x, double y, double z,
                                 ref double pX, ref double pY)
        {
            double xe, ye, ze;
            xe = v11 * x + v21 * y;
            ye = v12 * x + v22 * y + v32 * z;
            ze = v13 * x + v23 * y + v33 * z + v43;
            /* Экранные координаты,вычисляемые по формулам
            X= d* (x/z)+c1, Y= d*(y/z)+c2,
            где - расстояние от точки наблюдения до экрана
            */
            pX = screen_dist * xe / ze + c1;
            pY = screen_dist * ye / ze + c2;
        }

        /* Функция вычерчивания линии (экран 10х7 условн. единиц) */
        private void dw(double x1, double y1, double z1,
                        double x2, double y2, double z2)
        {
            double X1 = 0, Y1 = 0, X2 = 0, Y2 = 0;

            /* Преобразование мировых координат в экранные */
            perspective(x1, y1, z1, ref X1, ref Y1);
            perspective(x2, y2, z2, ref X2, ref Y2);
            /* Вычерчивание линии */
            Point point1 = new Point(IX(X1), IY(Y1));
            Point point2 = new Point(IX(X2), IY(Y2));
            dc.DrawLine(p, point1, point2);
        }

        //Рисование проволочной модели параллелепипеда
        private void drawParallelepiped()
        {
            double[,] v = new double[8, 3]
            {
                {-a, -b, -c}, { a, -b, -c}, { a,  b, -c}, {-a,  b, -c},
                {-a, -b,  c}, { a, -b,  c}, { a,  b,  c}, {-a,  b,  c}
            };

            int[,] edges = new int[12, 2]
            {
                {0,1}, {1,2}, {2,3}, {3,0},
                {4,5}, {5,6}, {6,7}, {7,4},
                {0,4}, {1,5}, {2,6}, {3,7}
            };

            for (int i = 0; i < 12; i++)
            {
                int i1 = edges[i, 0];
                int i2 = edges[i, 1];
                dw(v[i1, 0], v[i1, 1], v[i1, 2],
                   v[i2, 0], v[i2, 1], v[i2, 2]);
            }
        }


        private void Redraw()
        {
            dc.Clear(Color.White);
            coeff(rho, theta, phi);
            drawParallelepiped();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerRunning = !timerRunning;
            if (timerRunning)
            {
                timer.Start();
                buttonStart.Text = "Стоп";
            }
            else
            {
                timer.Stop();
                buttonStart.Text = "Старт";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            theta = (theta + 2) % 360;
            phi = phi + 1;
            if (phi > 359) phi = 1;

            trackBarTeta.Value = (int)theta;
            trackBarPhi.Value = (int)phi;
            labelTetaAngle.Text = $"θ = {theta}°";
            labelPhiAngle.Text = $"φ = {phi}°";
            Redraw();
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                timer.Stop();
                timerRunning = false;
                buttonStart.Text = "Старт";
            }


            if (sender == trackBarAside)
            {
                a = trackBarAside.Value * 0.1;

                labelAside.Text = $"A = {a:F1}";
            }
            else if (sender == trackBarBside)
            {
                b = trackBarBside.Value * 0.1;
                labelBside.Text = $"B = {b:F1}";
            }
            else if (sender == trackBarCside)
            {
                c = trackBarCside.Value * 0.1;
                labelCside.Text = $"C = {c:F1}";
            }

            Redraw();
        }

        private void trackBarTeta_Scroll_1(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                timer.Stop();
                timerRunning = false;
                buttonStart.Text = "Старт";
            }
            theta = trackBarTeta.Value;
            labelTetaAngle.Text = $"θ = {theta}°";
            Redraw();
        }

        private void trackBarPhi_Scroll_1(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                timer.Stop();
                timerRunning = false;
                buttonStart.Text = "Старт";
            }
            phi = trackBarPhi.Value;
            labelPhiAngle.Text = $"φ = {phi}°";
            Redraw();
        }
    }
}