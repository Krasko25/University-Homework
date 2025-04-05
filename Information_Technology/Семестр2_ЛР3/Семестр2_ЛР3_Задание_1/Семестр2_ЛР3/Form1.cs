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
using Microsoft.VisualBasic;


namespace Семестр2_ЛР3
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private List<string> imagePaths = new List<string>();
        private string currentImagePath = "";
        private string copyrightText = "(c) Моя прелесть";
        private string exportDirectory = "";
        private Dictionary<string, bool> imageCopyrighted = new Dictionary<string, bool>();

        private Bitmap AddCheckIcon(Bitmap image, string checkIconPath)
        {
            if (!File.Exists(checkIconPath)) return image;

            using (Graphics g = Graphics.FromImage(image))
            using (Image checkIcon = Image.FromFile(checkIconPath))
            {
                int iconSize = Math.Max(24, image.Width / 6);
                int padding = 5;
                int x = image.Width - iconSize - padding;
                int y = image.Height - iconSize - padding;

                g.DrawImage(checkIcon, new Rectangle(x, y, iconSize, iconSize));
            }

            return image;
        }

        private Bitmap AddWatermark(Bitmap bitmap, string text)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                float fontSize = bitmap.Height * 0.1f;
                using (Font font = new Font("Arial", fontSize, FontStyle.Bold, GraphicsUnit.Pixel))
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    g.DrawString(text, font, brush, new PointF(10, bitmap.Height - fontSize - 10));
                }
            }

            return bitmap;
        }

        private bool IsImageAlreadyInGrid(string fileName, string commentPrefix = null)
        {
            foreach (DataGridViewRow row in dataGridViewImageData.Rows)
            {
                if (row.Cells[0].Value?.ToString() == fileName)
                {
                    if (commentPrefix == null || row.Cells[3].Value?.ToString().StartsWith(commentPrefix) == true)
                        return true;
                }
            }
            return false;
        }




        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpenImage_Click(sender, e);
        }

        private void открытьДиректориюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpenDirectory_Click(sender, e);
        }

        private void LoadGallery()
        {
            flowLayoutPanelSmallGallery.Controls.Clear();
            foreach (var path in imagePaths)
            {
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(path);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 150;
                pb.Height = 150;
                pb.Tag = path;
                pb.Click += Pb_Click;
                flowLayoutPanelSmallGallery.Controls.Add(pb);
                imageCopyrighted[path] = false;
            }

            // Автозагрузка первого изображения
            if (imagePaths.Any())
            {
                currentImagePath = imagePaths[0];
                pictureBoxForChoosenImage.Image = Image.FromFile(currentImagePath);
            }
        }


        private void buttonAddCopyright_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentImagePath)) return;

            using (Image originalImage = Image.FromFile(currentImagePath))
            using (Bitmap bmp = ResizeIfTooSmall(new Bitmap(originalImage)))
            {
                Bitmap watermarked = AddWatermark(bmp, copyrightText);

                pictureBoxForChoosenImage.Image?.Dispose();
                pictureBoxForChoosenImage.Image = new Bitmap(watermarked);

                // Добавляем галочку
                foreach (PictureBox pbItem in flowLayoutPanelSmallGallery.Controls)
                {
                    if (pbItem.Tag.ToString() == currentImagePath)
                    {
                        string checkIconPath = Path.Combine(Application.StartupPath, "images", "check.png");
                        using (Image original = Image.FromFile(currentImagePath))
                        using (Bitmap iconImage = new Bitmap(original))
                        {
                            Bitmap updated = AddCheckIcon(iconImage, checkIconPath);
                            pbItem.Image?.Dispose();
                            pbItem.Image = new Bitmap(updated);
                            pbItem.Invalidate();
                        }

                        break;
                    }
                }

                // Обновление таблицы
                string fileName = Path.GetFileName(currentImagePath);
                if (!IsImageAlreadyInGrid(fileName, copyrightText))
                {
                    dataGridViewImageData.Rows.Add(
                        fileName,
                        watermarked.Width,
                        watermarked.Height,
                        $"{copyrightText} [{DateTime.Now:HH:mm}]"
                    );
                }

                imageCopyrighted[currentImagePath] = true;
            }
        }





        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxForChoosenImage.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }


        private void buttonBatchMode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(exportDirectory) || !Directory.Exists(exportDirectory))
            {
                MessageBox.Show("Укажите папку для экспорта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total = flowLayoutPanelSmallGallery.Controls.Count;
            int processed = 0;

            progressBarBatch.Minimum = 0;
            progressBarBatch.Maximum = total;
            progressBarBatch.Value = 0;
            progressBarBatch.Visible = true;

            foreach (Control control in flowLayoutPanelSmallGallery.Controls)
            {
                if (control is PictureBox pb && pb.Tag is string filePath)
                {
                    try
                    {
                        if (!imageCopyrighted[filePath])
                        {
                            using (Image img = Image.FromFile(filePath))
                            using (Bitmap bitmap = ResizeIfTooSmall(new Bitmap(img)))
                            {
                                Bitmap watermarked = AddWatermark(bitmap, copyrightText);
                                string outputName = Path.Combine(exportDirectory, Path.GetFileNameWithoutExtension(filePath) + ".png");
                                watermarked.Save(outputName, System.Drawing.Imaging.ImageFormat.Png);

                                // Добавляем галочку
                                foreach (PictureBox galleryPb in flowLayoutPanelSmallGallery.Controls)
                                {
                                    if (galleryPb.Tag.ToString() == filePath)
                                    {
                                        string checkIconPath = Path.Combine(Application.StartupPath, "images", "check.png");
                                        using (Image original = Image.FromFile(filePath))
                                        using (Bitmap iconImage = new Bitmap(original))
                                        {
                                            Bitmap updated = AddCheckIcon(iconImage, checkIconPath);
                                            galleryPb.Image?.Dispose();
                                            galleryPb.Image = new Bitmap(updated);
                                            galleryPb.Invalidate();
                                        }

                                        break;
                                    }
                                }

                                // Обновляем таблицу
                                string fileName = Path.GetFileName(filePath);
                                if (!IsImageAlreadyInGrid(fileName))
                                {
                                    dataGridViewImageData.Rows.Add(
                                        fileName,
                                        watermarked.Width,
                                        watermarked.Height,
                                        $"{copyrightText} [{DateTime.Now:HH:mm}]"
                                    );
                                }

                                imageCopyrighted[filePath] = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обработке файла:\n{filePath}\n\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                processed++;
                progressBarBatch.Value = processed;
                progressBarBatch.Refresh();
            }

            progressBarBatch.Visible = false;

            // Обновление выбранного изображения
            if (!string.IsNullOrEmpty(currentImagePath) && imageCopyrighted.ContainsKey(currentImagePath) && imageCopyrighted[currentImagePath])
            {
                string exportedPath = Path.Combine(exportDirectory, Path.GetFileNameWithoutExtension(currentImagePath) + ".png");
                if (File.Exists(exportedPath))
                {
                    pictureBoxForChoosenImage.Image?.Dispose();
                    pictureBoxForChoosenImage.Image = Image.FromFile(exportedPath);
                }
            }

            MessageBox.Show("Водяные знаки успешно добавлены ко всем изображениям!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void текстВодяногоЗнакаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCopyrightText_Click(sender, e);
        }

        private void папкаДляЭкспортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                exportDirectory = fbd.SelectedPath;
            }
        }

        private void flowLayoutPanelSmallGallery_Paint(object sender, PaintEventArgs e)
        {

        }

        private Bitmap ResizeIfTooSmall(Bitmap original, int minWidth = 400, int minHeight = 400)
        {
            if (original.Width >= minWidth && original.Height >= minHeight)
                return new Bitmap(original); // Копия без изменений

            float scaleX = (float)minWidth / original.Width;
            float scaleY = (float)minHeight / original.Height;
            float scale = Math.Max(scaleX, scaleY); // сохраняем пропорции

            int newWidth = (int)(original.Width * scale);
            int newHeight = (int)(original.Height * scale);

            Bitmap resized = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newWidth, newHeight);
            }

            return resized;
        }


        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            string originalPath = pb.Tag.ToString();
            currentImagePath = originalPath;

            // Если изображение уже было обработано — подгружаем экспортированную версию
            if (imageCopyrighted.ContainsKey(originalPath) && imageCopyrighted[originalPath] && !string.IsNullOrEmpty(exportDirectory))
            {
                string exportedPath = Path.Combine(exportDirectory, Path.GetFileNameWithoutExtension(originalPath) + ".png");

                if (File.Exists(exportedPath))
                {
                    pictureBoxForChoosenImage.Image?.Dispose();
                    pictureBoxForChoosenImage.Image = Image.FromFile(exportedPath);
                    return;
                }
            }

            // Иначе подгружаем оригинал
            pictureBoxForChoosenImage.Image?.Dispose();
            pictureBoxForChoosenImage.Image = Image.FromFile(originalPath);
        }



        private void пакетныйРежимОбработкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonBatchMode_Click(sender, e);
        }

        private void splitContainerImageViewAndbuttons_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void сохранитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSaveImage_Click(sender, e);
        }

        private void добавитьВодянойЗнакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonAddCopyright_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePaths.Clear();
                imagePaths.Add(ofd.FileName);
                LoadGallery();
            }
        }

        private void buttonOpenDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                imagePaths = Directory.GetFiles(fbd.SelectedPath, "*.*")
                                      .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png"))
                                      .ToList();
                LoadGallery();
            }
        }

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message =
                "Программа «Копирайтер»\n\n" +
                "✔ Нажмите 'Открыть изображение' для того, чтобы открыть изображение, на которое нужно наложить водяной знак,\n" +
                "✔ Нажмите 'Открыть директорию' для того, чтобы открыть папку с изображениями, на которые нужно наложить водяной знак,\n" +
                "✔ Нажмите 'Добавить водяной знак' для того, чтобы добавить водяной знак,\n" +
                "✔ Нажмите 'Сохранить изображение' и выберите место сохранения для того, чтобы сохранить изображение,\n" +
                "✔ Нажмите 'Режим пакетной обработки' для того, чтобы добавить водяной знак ко всем изображениям из открытой дирректории. Предварительно нужно выбрать папку для сохранения изображений (настройки->папка для экспорта изображений),\n" +
                "✔ Нажмите 'Tекст водяного знака' для того, чтобы изменить текст водяного знака.";

            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCopyrightText_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите текст водяного знака:", "Водяной знак", copyrightText);
            if (!string.IsNullOrEmpty(input))
                copyrightText = input;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && !string.IsNullOrEmpty(currentImagePath))
            {
                DialogResult result = MessageBox.Show("Удалить изображение из галереи?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Удаление из списка путей
                    imagePaths.Remove(currentImagePath);

                    // Удаление из словаря копирайтов
                    if (imageCopyrighted.ContainsKey(currentImagePath))
                        imageCopyrighted.Remove(currentImagePath);

                    // Удаление из галереи
                    PictureBox targetPB = null;
                    foreach (PictureBox pb in flowLayoutPanelSmallGallery.Controls)
                    {
                        if (pb.Tag.ToString() == currentImagePath)
                        {
                            targetPB = pb;
                            break;
                        }
                    }
                    if (targetPB != null)
                        flowLayoutPanelSmallGallery.Controls.Remove(targetPB);

                    // Очистка изображения
                    pictureBoxForChoosenImage.Image = null;
                    currentImagePath = "";
                }
            }
        }
    }
}
