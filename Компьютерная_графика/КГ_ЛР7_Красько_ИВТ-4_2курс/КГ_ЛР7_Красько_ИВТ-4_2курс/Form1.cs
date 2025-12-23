using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ_ЛР7_Красько_ИВТ_4_2курс
{
    public partial class FormRocket : Form
    {
        // Битовая картинка pictureBox
        Bitmap pictureBoxBitMap;
        // Битовая картинка динамического изображения
        Bitmap spriteBitMap;
        // Битовая картинка для временного хранения области экрана
        Bitmap cloneBitMap;
        // Графический контекст picturebox
        Graphics g_pictureBox;
        // Графический контекст спрайта
        Graphics g_sprite;
        int x, y; // Координаты ракеты
        int width = 75, height = 155; // размер ракеты
        Timer timer;

        public FormRocket() { InitializeComponent(); }

        // Функция рисования спрайта (ракеты)
        void DrawSprite()
        {
            //Очистка
            g_sprite.Clear(Color.Transparent);

            // Основной корпус
            g_sprite.FillRectangle(new SolidBrush(Color.Silver), 20, 20, 30, 100);
            g_sprite.DrawRectangle(new Pen(Color.Black, 1), 20, 20, 30, 100);

            //Колпак
            Point[] nosePoints = new Point[4] {
                new Point(20, 20), new Point(35, 0),
                new Point(50, 20), new Point(20, 20)
            };
            g_sprite.FillPolygon(new SolidBrush(Color.Red), nosePoints);
            g_sprite.DrawPolygon(new Pen(Color.Black, 1), nosePoints);

            //Иллюминатор
            g_sprite.FillEllipse(new SolidBrush(Color.Blue), 30, 50, 10, 10);
            g_sprite.DrawEllipse(new Pen(Color.Black, 1), 30, 50, 10, 10);

            //Прямоугольник-турбина
            g_sprite.FillRectangle(new SolidBrush(Color.Silver), 23, 115, 24, 8);
            g_sprite.DrawRectangle(new Pen(Color.Black, 1), 23, 115, 24, 8);

            // Огонь
            // Ораньжевый огонь
            Point[] outerFlame = new Point[4] {
                new Point(23, 123), new Point(35, 145),
                new Point(47, 123), new Point(23, 123)
            };
            g_sprite.FillPolygon(new SolidBrush(Color.Orange), outerFlame);
            g_sprite.DrawPolygon(new Pen(Color.Black, 1), outerFlame);

            // Желтый огонь
            Point[] innerFlame = new Point[4] {
                new Point(27, 123), new Point(35, 140),
                new Point(43, 123), new Point(27, 123)
            };
            g_sprite.FillPolygon(new SolidBrush(Color.Yellow), innerFlame);
            g_sprite.DrawPolygon(new Pen(Color.Black, 1), innerFlame);

            // Левое крыло
            Point[] leftWing = new Point[4] {
                new Point(20, 70), new Point(0, 110),
                new Point(5, 115), new Point(20, 115)
            };
            g_sprite.FillPolygon(new SolidBrush(Color.Silver), leftWing);
            g_sprite.DrawPolygon(new Pen(Color.Black, 1), leftWing);

            // Правое крыло
            Point[] rightWing = new Point[4] {
                new Point(50, 70), new Point(70, 110),
                new Point(65, 115), new Point(50, 115)
            };
            g_sprite.FillPolygon(new SolidBrush(Color.Silver), rightWing);
            g_sprite.DrawPolygon(new Pen(Color.Black, 1), rightWing);
        }

        // Функция сохранения части изображения
        void SavePart(int xt, int yt)
        {
            Rectangle cloneRect = new Rectangle(xt, yt, width, height);
            System.Drawing.Imaging.PixelFormat format = pictureBoxBitMap.PixelFormat;
            // Клонируем изображение, заданное прямоугольной областью
            cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
        }

        private void FormRocket_Load(object sender, EventArgs e)
        {
            // Создаём Bitmap для pictureBox1 и графический контекст
            pictureBoxBitMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g_pictureBox = Graphics.FromImage(pictureBoxBitMap);
            Bitmap backgroundBitmap;
            backgroundBitmap = new Bitmap(@"background.png");
            g_pictureBox.DrawImage(backgroundBitmap, 0, 0, pictureBox1.Width, pictureBox1.Height);

            // Создаём Bitmap для спрайта и графический контекст
            spriteBitMap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g_sprite = Graphics.FromImage(spriteBitMap);

            // Рисуем ракету на графическом контексте g_sprite
            DrawSprite();

            // Создаём Bitmap для временного хранения части изображения
            cloneBitMap = new Bitmap(width, height);

            //начальные координаты ракеты
            x = (pictureBox1.Width - width) / 2 + 60; 
            y = pictureBox1.Height - height - 30;

            // Сохраняем область экрана перед первым выводом объекта
            SavePart(x, y);

            // Выводим ракету на графический контекст g_pictureBox
            g_pictureBox.DrawImage(spriteBitMap, x, y);

            // Устанавливаем изображение в PictureBox
            pictureBox1.Image = pictureBoxBitMap;

            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();

            // Создаём таймер с интервалом 50 миллисекунд
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        // Обрабатываем событие от таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Восстанавливаем затёртую область статического изображения
            g_pictureBox.DrawImage(cloneBitMap, x, y);

            y -= 8;  // Двигаем вверх

            // Проверяем на выход изображения ракеты за верхнюю границу
            if (y < -height)
            {
                // Возвращаем ракету вниз для нового взлета
                y = pictureBox1.Height - height - 30;
            }

            // Сохраняем область экрана перед выводом ракеты
            SavePart(x, y);

            // Выводим ракету
            g_pictureBox.DrawImage(spriteBitMap, x, y);

            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
        }

        // Включаем таймер по нажатию на кнопку
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        // Останавливаем таймер по нажатию на кнопку
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }
    }
}