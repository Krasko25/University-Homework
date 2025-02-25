using System.Windows.Forms.DataVisualization.Charting;

namespace Семестр_2_ЛР2
{
    public partial class FormFileManager : Form
    {
        public FormFileManager()
        {
            InitializeComponent();
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDirectoryStructure(folderDialog.SelectedPath);
                }
            }
        }

        private void LoadDirectoryStructure(string path)
        {
            treeView.Nodes.Clear(); // Убираем старую информацию
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            TreeNode rootNode = new TreeNode(dirInfo.Name);
            rootNode.Tag = dirInfo; // Сохраняем корневой каталог
            LoadSubDirectoriesAndFiles(dirInfo, rootNode);
            treeView.Nodes.Add(rootNode);
        }


        private void LoadSubDirectoriesAndFiles(DirectoryInfo dirInfo, TreeNode parentNode)
        {
            // Загружаем файлы в текущей директории
            foreach (var file in dirInfo.GetFiles())
            {
                TreeNode fileNode = new TreeNode(file.Name);
                fileNode.Tag = file; // Сохраняем информацию о файле в теге
                parentNode.Nodes.Add(fileNode);
            }

            // Загружаем подкаталоги
            foreach (var subDir in dirInfo.GetDirectories())
            {
                TreeNode subNode = new TreeNode(subDir.Name);
                subNode.Tag = subDir;  // Сохраняем информацию о подкаталоге
                parentNode.Nodes.Add(subNode);
                LoadSubDirectoriesAndFiles(subDir, subNode); // Рекурсивный вызов для подпапок
            }
        }




        private void LoadFiles(FileInfo[] files)
        {
            listView.Items.Clear(); // Очищаем старые элементы

            foreach (var file in files)
            {
                // Создаем новый элемент ListView
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add((file.Length / 1024.0).ToString("F2")); // Размер в KB
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(file.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                item.Tag = file;  // Привязываем информацию о файле к элементу ListView

                // Добавляем чекбокс в первый столбец
                item.Checked = true; 

                // Получаем категорию файла и меняем цвет фона
                string category = GetCategory(file);
                switch (category)
                {
                    case "Графика":
                        item.BackColor = Color.LightBlue; // Графический файл
                        break;
                    case "Документы":
                        item.BackColor = Color.LightGreen; // Офисный файл
                        break;
                    case "Архивы":
                        item.BackColor = Color.LightYellow; // Архивы
                        break;
                    case "Программы":
                        item.BackColor = Color.LightCoral; // Exe
                        break;
                    default:
                        item.BackColor = Color.White; // Остальные файлы
                        break;
                }

                listView.Items.Add(item);
            }

            // Обновление статистики
            UpdateStatusStrip();
            UpdateChartWithFileData();
        }

        private string GetCategory(FileInfo file)
        {
            // Категории файлов
            if (file.Extension == ".png" || file.Extension == ".jpg" || file.Extension == ".bmp" || file.Extension == ".gif")
                return "Графика";
            if (file.Extension == ".docx" || file.Extension == ".xlsx" || file.Extension == ".pdf" || file.Extension == ".txt")
                return "Документы";
            if (file.Extension == ".zip" || file.Extension == ".rar" || file.Extension == ".7z")
                return "Архивы";
            if (file.Extension == ".exe" || file.Extension == ".dll")
                return "Программы";

            return "Другое";
        }



        private void UpdateStatusStrip()
        {
            double totalSizeKB = 0; 
            int selectedFiles = 0;

            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked) // Подсчет только выбранных файлов
                {
                    if (item.Tag is FileInfo file)
                    {
                        totalSizeKB += file.Length / 1024.0;
                        selectedFiles++;
                    }
                }
            }

            // Cтатусная строка
            toolStripStatusLabelFilesSize.Text = $"Вес файлов (Кб): {totalSizeKB:F2}";
            toolStripStatusLabelFilesNumber.Text = $"Выделено файлов: {selectedFiles} / {listView.Items.Count}";
        }


        private void toolStripButtonSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (TreeNode node in treeView.Nodes)
                    {
                        SaveNodeStructure(node, writer, 0);
                    }
                }
            }
        }

        private void SaveNodeStructure(TreeNode node, StreamWriter writer, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);

            // Записываем информацию о текущей папке или файле
            writer.WriteLine($"{indent}{node.Text}");

            // Проверка, является ли текущий элемент элементом с дочерними элементами
            if (node.Tag is DirectoryInfo dir)
            {
                foreach (TreeNode subNode in node.Nodes) 
                {
                    SaveNodeStructure(subNode, writer, indentLevel + 1);
                }
            }
            else if (node.Tag is FileInfo file)
            {
                // Для файла сохраняем метаданные
                writer.WriteLine($"{indent} - Размер: {file.Length / 1024.0:F2} KB");
                writer.WriteLine($"{indent} - Последнее изменение: {file.LastWriteTime.ToString("dd.MM.yyyy HH:mm")}");
            }
        }



        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonInfo_Click(object sender, EventArgs e)
        {

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView.Items.Clear(); // Очистка списка

            // Проверяем, выбран ли каталог или файл
            if (e.Node.Tag is DirectoryInfo dirInfo)
            {
                // Загружаем файлы из этого каталога
                LoadFiles(dirInfo.GetFiles()); 
            }
            else if (e.Node.Tag is FileInfo file)
            {
                LoadFiles(new FileInfo[] { file });  // Показываем только выбранный файл
            }
        }

        private void SaveTreeAndChartData(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Сохранение структуры дерева
                writer.WriteLine("Структура дерева:");
                foreach (TreeNode node in treeView.Nodes)
                {
                    SaveNodeStructure(node, writer, 0);
                }

                writer.WriteLine();

                // Группировка файлов по длине имени
                var shortNames = new List<FileInfo>();
                var mediumNames = new List<FileInfo>();
                var longNames = new List<FileInfo>();

                // Разделение файлов по длине имени
                foreach (ListViewItem item in listView.Items)
                {
                    if (item.Checked && item.Tag is FileInfo file) // Только для выбранных файлов
                    {
                        int nameLength = file.Name.Length;

                        if (nameLength <= 11)
                            shortNames.Add(file);
                        else if (nameLength > 11 && nameLength <= 20)
                            mediumNames.Add(file);
                        else
                            longNames.Add(file);
                    }
                }

                // Сохранение среднего размера файлов
                writer.WriteLine("Средний размер файлов по длине имени:");
                writer.WriteLine($"Короткие имена (до 11 символов): {CalculateAverageFileSize(shortNames):F2} КБ");
                writer.WriteLine($"Средние имена (12-20 символов): {CalculateAverageFileSize(mediumNames):F2} КБ");
                writer.WriteLine($"Длинные имена (более 20 символов): {CalculateAverageFileSize(longNames):F2} КБ");
            }
        }






        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                listView.Font = fontDialog.Font;
                treeView.Font = fontDialog.Font;
                toolStripStatusLabelFilesSize.Font = fontDialog.Font;
                toolStripStatusLabelFilesNumber.Font = fontDialog.Font;
                chart.Font = fontDialog.Font;

                toolStripButtonOpenFile.Font = fontDialog.Font;
                toolStripButtonSaveFile.Font = fontDialog.Font;
                toolStripButtonChangeFont.Font = fontDialog.Font;
                toolStripButtonInfo.Font = fontDialog.Font;
                menuStripMain.Font = fontDialog.Font;

                chart.Legends[0].Font = fontDialog.Font;

                foreach (var chartArea in chart.ChartAreas)
                {
                    chartArea.AxisX.LabelStyle.Font = fontDialog.Font;
                    chartArea.AxisY.LabelStyle.Font = fontDialog.Font;
                }
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                listView.ForeColor = colorDialog.Color;
                treeView.ForeColor = colorDialog.Color;
                toolStripStatusLabelFilesSize.ForeColor = colorDialog.Color;
                toolStripStatusLabelFilesNumber.ForeColor = colorDialog.Color;
                chart.ForeColor = colorDialog.Color;

                toolStripButtonOpenFile.ForeColor = colorDialog.Color;
                toolStripButtonSaveFile.ForeColor = colorDialog.Color;
                toolStripButtonChangeFont.ForeColor = colorDialog.Color;
                toolStripButtonInfo.ForeColor = colorDialog.Color;
                menuStripMain.ForeColor = colorDialog.Color;

                chart.Legends[0].ForeColor = colorDialog.Color;

                foreach (var chartArea in chart.ChartAreas)
                {
                    chartArea.AxisX.LabelStyle.ForeColor = colorDialog.Color;
                    chartArea.AxisY.LabelStyle.ForeColor = colorDialog.Color;
                }
            }
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDirectoryStructure(folderDialog.SelectedPath);
                }
            }
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTreeAndChartData(saveFileDialog.FileName); // Сохранение структуры и данных
            }
        }



        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Очищаем данные 
            treeView.Nodes.Clear();  
            listView.Items.Clear();  
            chart.Series.Clear(); 
            toolStripStatusLabelFilesSize.Text = "Вес файлов (Кб): 0.00";
            toolStripStatusLabelFilesNumber.Text = "Выделено файлов: 0 / 0";

            // this.Close();
        }

        private double CalculateAverageFileSize(List<FileInfo> files)
        {
            if (files.Count > 0)
                return files.Average(file => file.Length) / 1024.0; // Размер в КБ
            else
                return 0;
        }




        private void UpdateChartWithFileData()
        {
            var shortNames = new List<FileInfo>();  
            var mediumNames = new List<FileInfo>();
            var longNames = new List<FileInfo>();  

            // Разделение файлов по длине имени для выбранных файлов
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked && item.Tag is FileInfo file) // Только для выбранных файлов
                {
                    int nameLength = file.Name.Length;

                    if (nameLength <= 11)
                        shortNames.Add(file);
                    else if (nameLength > 11 && nameLength <= 20)
                        mediumNames.Add(file);
                    else
                        longNames.Add(file);
                }
            }

            // Очистка диаграммы
            chart.Series.Clear();

            // Создаем новую серию данных
            Series series = new Series("Средний размер файлов для этой категории (КБ)");
            series.ChartType = SeriesChartType.Column; // Столбчатая диаграмма

            // Добавляем данные в график
            if (shortNames.Count > 0)
                series.Points.AddXY("Короткие имена", CalculateAverageFileSize(shortNames) / 1024.0);

            if (mediumNames.Count > 0)
                series.Points.AddXY("Средние имена", CalculateAverageFileSize(mediumNames) / 1024.0); 

            if (longNames.Count > 0)
                series.Points.AddXY("Длинные имена", CalculateAverageFileSize(longNames) / 1024.0);

            // Добавляем серию в диаграмму
            chart.Series.Add(series);
        }


        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateStatusStrip(); 
            UpdateChartWithFileData();
            UpdateColumnHeader();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Для выбора всех файлов
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Проверка клика только по необходимой колонке
            if (e.Column == 4)
            {
                if (AreAllItemsChecked())
                {
                    UncheckAllItems();
                }
                else
                {
                    CheckAllItems(); 
                }
            }
        }


        private bool AreAllItemsChecked()
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (!item.Checked) 
                {
                    return false;
                }
            }
            return true; 
        }

       
        private void CheckAllItems()
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = true;
            }

            UpdateStatusStrip();
            UpdateChartWithFileData();
            UpdateColumnHeader();
        }

        private void UncheckAllItems()
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = false; 
            }

            UpdateStatusStrip(); 
            UpdateChartWithFileData();
            UpdateColumnHeader();
        }


        private void UpdateColumnHeader()
        {
            // Проверяем, выбраны ли все элементы в ListView
            if (AreAllItemsChecked())
            {
                listView.Columns[4].Text = "Снять все чекбоксы"; 
            }
            else
            {
                listView.Columns[4].Text = "Отметить все чекбоксы"; 
            }
        }

        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Приложение: Семестр_2_ЛР2\n";
            info += "Описание: Это приложение предназначено для обработки файлов и директорий.\n";
            info += "Автор: Красько Михаил Андреевич\n";
            info += "Студент группы ИВТ-4\n";
            info += "Дата релиза: Январь 2025\n";

            MessageBox.Show(info, "О приложении", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormFileManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                открытьToolStripMenuItem.PerformClick();  // Вызываем функцию открытия
                e.Handled = true;  // Событие обработано
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                сохранитьToolStripMenuItem.PerformClick(); 
                e.Handled = true; 
            }
        }

        private void FormFileManager_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonChangeFont_Click(object sender, EventArgs e)
        {
           шрифтToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripButtonChangeColor_Click(object sender, EventArgs e)
        {
            цветToolStripMenuItem_Click(this, EventArgs.Empty);
        }
    }
}
