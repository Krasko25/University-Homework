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

namespace КГ_ЛР12_генерация_файла_Красько_ИВТ_4_2курс
{
    public partial class Form : System.Windows.Forms.Form
    {
        Random rnd = new Random();

        public Form()
        {
            InitializeComponent();
        }

        void GenerateRandomPoints()
        {
            string filePath = "Curv.dat";
            int pointCount = 40;

            double maxXCoord = 10.0;
            double maxYCoord = 7.0;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //количество точек
                writer.WriteLine(pointCount);

                for (int i = 0; i < pointCount; i++)
                {
                    double x = rnd.NextDouble() * (maxXCoord);
                    double y = rnd.NextDouble() * (maxYCoord);
                    writer.WriteLine($"{x} {y}");
                }
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            GenerateRandomPoints();
            MessageBox.Show("40 случайных точек записаны в файл Curv.dat");
        }
    }
}