using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ_ЛР6_Красько_ИВТ_4_2курс
{
    public partial class FormSpaceShip : Form
    {
        public FormSpaceShip()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush mySky = new SolidBrush(Color.DarkBlue);
            SolidBrush myGrass = new SolidBrush(Color.DarkGreen);
            SolidBrush myTray = new SolidBrush(Color.Silver);
            SolidBrush myTop = new SolidBrush(Color.Cyan);
            SolidBrush myBeam = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            SolidBrush myMoon = new SolidBrush(Color.LightYellow);
            SolidBrush myStar = new SolidBrush(Color.White);
            SolidBrush myFlower1 = new SolidBrush(Color.Red);
            SolidBrush myFlower2 = new SolidBrush(Color.Yellow);
            SolidBrush myFlowerCenter = new SolidBrush(Color.Brown);
            Pen myGrassPen = new Pen(Color.LawnGreen, 1);
            Pen myLegPen = new Pen(Color.Gray, 4);

            // Небо и поляна
            g.FillRectangle(mySky, 0, 0, 1200, 534);
            g.FillRectangle(myGrass, 0, 534, 1200, 266);

            // Трава
            g.DrawLine(myGrassPen, 100, 594, 100, 584);
            g.DrawLine(myGrassPen, 200, 634, 200, 624);
            g.DrawLine(myGrassPen, 300, 594, 300, 582);
            g.DrawLine(myGrassPen, 400, 634, 400, 624);
            g.DrawLine(myGrassPen, 500, 594, 500, 584);
            g.DrawLine(myGrassPen, 600, 634, 600, 624);
            g.DrawLine(myGrassPen, 700, 594, 700, 584);
            g.DrawLine(myGrassPen, 800, 634, 800, 624);
            g.DrawLine(myGrassPen, 900, 594, 900, 582);
            g.DrawLine(myGrassPen, 1000, 634, 1000, 624);

            //Звезды
            g.FillEllipse(myStar, 160, 80, 4, 4);
            g.FillEllipse(myStar, 240, 140, 2, 2);
            g.FillEllipse(myStar, 400, 60, 4, 4);
            g.FillEllipse(myStar, 560, 120, 2, 2);
            g.FillEllipse(myStar, 700, 100, 4, 4);
            g.FillEllipse(myStar, 840, 160, 2, 2);
            g.FillEllipse(myStar, 200, 200, 4, 4);
            g.FillEllipse(myStar, 360, 180, 2, 2);
            g.FillEllipse(myStar, 500, 220, 4, 4);
            g.FillEllipse(myStar, 640, 200, 2, 2);

            // летающая тарелка
            // Корпус
            g.FillEllipse(myTray, 700, 334, 320, 80);
            g.DrawEllipse(Pens.Gray, 700, 334, 320, 80);

            //Верхняя часть
            g.FillEllipse(myTop, 780, 274, 160, 80);
            g.DrawEllipse(Pens.DarkCyan, 780, 274, 160, 80);

            // Ноги тарелки
            g.DrawLine(myLegPen, 760, 414, 740, 494);
            g.DrawLine(myLegPen, 740, 494, 720, 494);

            g.DrawLine(myLegPen, 860, 414, 860, 494);
            g.DrawLine(myLegPen, 860, 494, 840, 494);

            g.DrawLine(myLegPen, 960, 414, 980, 494);
            g.DrawLine(myLegPen, 980, 494, 1000, 494);

            // Луч
            Point[] beamPoints = {
                new Point(850, 414),
                new Point(830, 614),
                new Point(890, 614),
                new Point(870, 414)
            };

            g.FillPolygon(myBeam, beamPoints);

            // 1 цветок
            int x1 = 410;
            int y1 = 707;

            g.DrawLine(Pens.Green, x1, y1, x1, y1 - 30);
            g.FillEllipse(myFlower1, x1 - 16, y1 - 40, 12, 12);
            g.FillEllipse(myFlower1, x1 + 4, y1 - 40, 12, 12);
            g.FillEllipse(myFlower1, x1 - 16, y1 - 60, 12, 12);
            g.FillEllipse(myFlower1, x1 + 4, y1 - 60, 12, 12);
            g.FillEllipse(myFlowerCenter, x1 - 6, y1 - 50, 12, 12);

            //2 цветок
            int x2 = 750;
            int y2 = 567;

            g.DrawLine(Pens.Green, x2, y2, x2, y2 - 30);
            g.FillEllipse(myFlower2, x2 - 16, y2 - 40, 12, 12);
            g.FillEllipse(myFlower2, x2 + 4, y2 - 40, 12, 12);
            g.FillEllipse(myFlower2, x2 - 16, y2 - 60, 12, 12);
            g.FillEllipse(myFlower2, x2 + 4, y2 - 60, 12, 12);
            g.FillEllipse(myFlowerCenter, x2 - 6, y2 - 50, 12, 12);

            // ******* 8 - Рисуем луну ********************
            g.FillEllipse(myMoon, 40, 40, 120, 120);
            g.DrawEllipse(Pens.Gold, 40, 40, 120, 120);
        }
    }
}