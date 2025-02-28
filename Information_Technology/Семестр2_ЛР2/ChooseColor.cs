using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Семестр_2_ЛР2
{
    public partial class ChooseColor : Form
    {
        public Dictionary<string, Color> SelectedColors { get; private set; }
        public event Action ColorsChanged;


        public ChooseColor()
        {
            InitializeComponent();

            // Загружаем текущие значения цветов в панели
            panelGrahicalFilesColorIndicator.BackColor = FileCategoryColors.GraphicsColor;
            panelOfficeFilesColorIndicator.BackColor = FileCategoryColors.DocumentsColor;
            panelArchiveFilesColorIndicator.BackColor = FileCategoryColors.ArchivesColor;
            panelExecutiveFilesColorIndicator.BackColor = FileCategoryColors.ExecutableColor;

            panelGrahicalFilesColorIndicator2.BackColor = FileCategoryColors.GraphicsColor;
            panelOfficeFilesColorIndicator2.BackColor = FileCategoryColors.DocumentsColor;
            panelArchiveFilesColorIndicator2.BackColor = FileCategoryColors.ArchivesColor;
            panelExecutiveFilesColorIndicator2.BackColor = FileCategoryColors.ExecutableColor;
        }


        private void buttonChooseColorForImages_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                FileCategoryColors.SetCategoryColor("Графика", colorDialog.Color);
                panelGrahicalFilesColorIndicator.BackColor = colorDialog.Color;
                panelGrahicalFilesColorIndicator2.BackColor = colorDialog.Color;
                ColorsChanged?.Invoke();
            }
        }

        private void buttonChooseColorForImagesbuttonChooseColorForOfficeFiles_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                FileCategoryColors.SetCategoryColor("Документы", colorDialog.Color);
                panelOfficeFilesColorIndicator.BackColor = colorDialog.Color;
                panelOfficeFilesColorIndicator2.BackColor = colorDialog.Color;
                ColorsChanged?.Invoke();
            }
        }

        private void buttonChooseColorForArchives_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                FileCategoryColors.SetCategoryColor("Архивы", colorDialog.Color);
                panelArchiveFilesColorIndicator.BackColor = colorDialog.Color;
                panelArchiveFilesColorIndicator2.BackColor = colorDialog.Color;
                ColorsChanged?.Invoke();
            }
        }
        
        private void buttonChooseColorForExecutiveFiles_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                FileCategoryColors.SetCategoryColor("Программы", colorDialog.Color);
                panelExecutiveFilesColorIndicator.BackColor = colorDialog.Color;
                panelExecutiveFilesColorIndicator2.BackColor = colorDialog.Color;
                ColorsChanged?.Invoke();
            }
        }
    }

}
