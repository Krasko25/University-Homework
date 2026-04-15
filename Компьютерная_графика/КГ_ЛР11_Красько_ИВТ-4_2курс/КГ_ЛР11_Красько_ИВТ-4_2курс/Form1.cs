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

namespace КГ_ЛР11_Красько_ИВТ_4_2курс
{
    public partial class Form : System.Windows.Forms.Form
    {
        struct Simple
        { public double xx; public double yy; public int ii; };
        Simple s;
        FileInfo my_file = new FileInfo("SCRATCH");
        BinaryWriter fw;
        Random rnd;
        int first = 1, phi = 0, alpha = 0;
        public Form()
        {
            InitializeComponent();
        }



        /* Создание файла Scratch и открытие его на запись */
        void pfopen()
        {
            fw = new BinaryWriter(my_file.Open(FileMode.Create,
            FileAccess.Write));

        }
        /* Запись в файл точки с флагом перемещения */
        void pmove(double x, double y)
        {
            s.xx = x; s.yy = y; s.ii = 0;
            fw.Write(s.xx); fw.Write(s.yy); fw.Write(s.ii);
        }

        /* Запись в файл точки с флагом рисования */
        void pdraw(double x, double y)
        {
            s.xx = x; s.yy = y; s.ii = 1;
            fw.Write(s.xx); fw.Write(s.yy); fw.Write(s.ii);
        }
        /* Закрытие файла */
        void pfclose()
        {
            fw.Close();
        }
        /* Функция, возвращающая новое направление кривой */
        double direction()
        {
            if (first == 1) { first = 0; rnd = new Random(); }
            alpha += rnd.Next(10000) % 13 - 6;
            if (Math.Abs(alpha) > 15) alpha = 0;
            phi += alpha;
            return ((double)phi * Math.PI / 180.0);
        }
        /* Главная функция генерации 20 вложенных шестиугольников */
        void curvgen()
        {
            pfopen();
            int numHexagons = 20;
            double centerX = 0.0, centerY = 0.0;

            for (int i = 1; i <= numHexagons; i++)
            {
                double radius = i;

                double[][] vertices = new double[6][];
                for (int k = 0; k < 6; k++)
                {
                    double angle = 2.0 * Math.PI * k / 6.0;
                    double x = centerX + radius * Math.Cos(angle);
                    double y = centerY + radius * Math.Sin(angle);
                    vertices[k] = new double[] { x, y };
                }

                //Идём к 1-й вершине
                pmove(vertices[0][0], vertices[0][1]);
                //Рисуем линии к остальным вершинам
                for (int k = 1; k < 6; k++)
                {
                    pdraw(vertices[k][0], vertices[k][1]);
                }
                //Последняя линия
                pdraw(vertices[0][0], vertices[0][1]);
            }
            pfclose();
        }
        /* Вызов функции генерации случайной кривой */
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            curvgen();
            MessageBox.Show("20 Шестиугольников сгенерированы в файл Scratch");
        }
    }
}