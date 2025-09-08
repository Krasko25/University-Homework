using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Компьютерная_графика_ЛР2_Красько_ИВТ_4_2курс
{
    public partial class DiagramForm : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        //**************Конструктор формы *******************************
        public DiagramForm()
        {
            InitializeComponent();
            // Предоставляем объекту "g" класса Graphics
            // возможность рисования на pictureBox1:
            g = pictureBoxWithGraphic.CreateGraphics();
        }
      

        private void buttonPixels_Click(object sender, EventArgs e)
        {
            // экранные координаты
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            // математические значения
            double x = 0, y = 0;
            // цвет осей и рамки
            Pen axesPen = new Pen(Color.Red, 1);
            // цвет графика
            Pen graphicsPen = new Pen(Color.FromArgb(0, 255, 0), 1);
            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBoxWithGraphic.BackColor = Color.FromName("Azure");
            pictureBoxWithGraphic.Refresh();
            // Стандарт страничного пространства в Pixel
            g.PageUnit = GraphicsUnit.Pixel;
            //Рисуем прямоугольник:
            g.DrawRectangle(axesPen, 0, 0,
            pictureBoxWithGraphic.Size.Width - 1, pictureBoxWithGraphic.Size.Height - 1);
            // Рисуем оси
            g.DrawLine(axesPen, 0, (pictureBoxWithGraphic.Size.Height - 1) / 2,
            pictureBoxWithGraphic.Size.Width - 1, (pictureBoxWithGraphic.Size.Height - 1) / 2);
            g.DrawLine(axesPen, (pictureBoxWithGraphic.Size.Width - 1) / 2, 0,
            (pictureBoxWithGraphic.Size.Width - 1) / 2, pictureBoxWithGraphic.Size.Height - 1);
            // Рисуем график функции y=Sin(x)
            x = -1;
            for (ex = 0; ex <= 1000; ex++)
            {
                y = -6 * x * x + 3 * x;
                ey = (pictureBoxWithGraphic.Size.Height - 1) - (Convert.ToInt16(y * 200) + 250);
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + 0.002;
            }
        }

        private void buttonMillimeter_Click(object sender, EventArgs e)
        {
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            // Стандарт страничного пространства Millimeter
            g.PageUnit = GraphicsUnit.Millimeter;
            Pen axesPen = new Pen(Color.Cyan, 0.1f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 0, 255), 0.1f);
            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBoxWithGraphic.BackColor =

            Color.FromKnownColor(KnownColor.ControlLightLight);

            pictureBoxWithGraphic.Refresh();
            //Получаем ширину и высоту прямоугольника в миллиметрах
            int WidthInMM = Convert.ToInt16((pictureBoxWithGraphic.Size.Width - 1) /
            g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBoxWithGraphic.Size.Height - 1) /
            g.DpiY * 25.4);

            //Рисуем прямоугольник
            g.DrawRectangle(axesPen, 0, 0, WidthInMM, HeightInMM);
            // Рисуем оси
            g.DrawLine(axesPen, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            g.DrawLine(axesPen, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            // Рисуем график функции y=Sin(x)
            x = -1;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                y = -6 * x * x + 3 * x;
                ey = HeightInMM - (Convert.ToInt16(y *

                Convert.ToSingle(200 / g.DpiX * 25.4)) +
                Convert.ToInt16(250 / g.DpiX * 25.4));
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + 2.0f / WidthInMM;

            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(224, 224, 224));
        }
    }




}
