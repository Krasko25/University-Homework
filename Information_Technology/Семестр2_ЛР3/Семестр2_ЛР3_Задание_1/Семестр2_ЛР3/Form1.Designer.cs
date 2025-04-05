namespace Семестр2_ЛР3
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьДиректориюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВодянойЗнакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетныйРежимОбработкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстВодяногоЗнакаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаДляЭкспортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelSmallGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainerTableAndImageView = new System.Windows.Forms.SplitContainer();
            this.dataGridViewImageData = new System.Windows.Forms.DataGridView();
            this.columnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCopyrightText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerImageViewAndbuttons = new System.Windows.Forms.SplitContainer();
            this.panelForImageBox = new System.Windows.Forms.Panel();
            this.pictureBoxForChoosenImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelForButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCopyrightText = new System.Windows.Forms.Button();
            this.buttonBatchMode = new System.Windows.Forms.Button();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonAddCopyright = new System.Windows.Forms.Button();
            this.buttonOpenDirectory = new System.Windows.Forms.Button();
            this.buttonOpenImage = new System.Windows.Forms.Button();
            this.progressBarBatch = new System.Windows.Forms.ProgressBar();
            this.contextMenuStripGalleryRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наложитьВодянойЗнакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTableAndImageView)).BeginInit();
            this.splitContainerTableAndImageView.Panel1.SuspendLayout();
            this.splitContainerTableAndImageView.Panel2.SuspendLayout();
            this.splitContainerTableAndImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImageData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImageViewAndbuttons)).BeginInit();
            this.splitContainerImageViewAndbuttons.Panel1.SuspendLayout();
            this.splitContainerImageViewAndbuttons.Panel2.SuspendLayout();
            this.splitContainerImageViewAndbuttons.SuspendLayout();
            this.panelForImageBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForChoosenImage)).BeginInit();
            this.tableLayoutPanelForButtons.SuspendLayout();
            this.contextMenuStripGalleryRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьИзображениеToolStripMenuItem,
            this.открытьДиректориюToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьИзображениеToolStripMenuItem
            // 
            this.открытьИзображениеToolStripMenuItem.Name = "открытьИзображениеToolStripMenuItem";
            this.открытьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.открытьИзображениеToolStripMenuItem.Text = "Открыть изображение";
            this.открытьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.открытьИзображениеToolStripMenuItem_Click);
            // 
            // открытьДиректориюToolStripMenuItem
            // 
            this.открытьДиректориюToolStripMenuItem.Name = "открытьДиректориюToolStripMenuItem";
            this.открытьДиректориюToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.открытьДиректориюToolStripMenuItem.Text = "Открыть директорию";
            this.открытьДиректориюToolStripMenuItem.Click += new System.EventHandler(this.открытьДиректориюToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВодянойЗнакToolStripMenuItem,
            this.сохранитьИзображениеToolStripMenuItem,
            this.пакетныйРежимОбработкиToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // добавитьВодянойЗнакToolStripMenuItem
            // 
            this.добавитьВодянойЗнакToolStripMenuItem.Name = "добавитьВодянойЗнакToolStripMenuItem";
            this.добавитьВодянойЗнакToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.добавитьВодянойЗнакToolStripMenuItem.Text = "Добавить водяной знак";
            this.добавитьВодянойЗнакToolStripMenuItem.Click += new System.EventHandler(this.добавитьВодянойЗнакToolStripMenuItem_Click);
            // 
            // сохранитьИзображениеToolStripMenuItem
            // 
            this.сохранитьИзображениеToolStripMenuItem.Name = "сохранитьИзображениеToolStripMenuItem";
            this.сохранитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.сохранитьИзображениеToolStripMenuItem.Text = "Сохранить изображение";
            this.сохранитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображениеToolStripMenuItem_Click);
            // 
            // пакетныйРежимОбработкиToolStripMenuItem
            // 
            this.пакетныйРежимОбработкиToolStripMenuItem.Name = "пакетныйРежимОбработкиToolStripMenuItem";
            this.пакетныйРежимОбработкиToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.пакетныйРежимОбработкиToolStripMenuItem.Text = "Пакетный режим обработки";
            this.пакетныйРежимОбработкиToolStripMenuItem.Click += new System.EventHandler(this.пакетныйРежимОбработкиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текстВодяногоЗнакаToolStripMenuItem,
            this.папкаДляЭкспортаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // текстВодяногоЗнакаToolStripMenuItem
            // 
            this.текстВодяногоЗнакаToolStripMenuItem.Name = "текстВодяногоЗнакаToolStripMenuItem";
            this.текстВодяногоЗнакаToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.текстВодяногоЗнакаToolStripMenuItem.Text = "Текст водяного знака";
            this.текстВодяногоЗнакаToolStripMenuItem.Click += new System.EventHandler(this.текстВодяногоЗнакаToolStripMenuItem_Click);
            // 
            // папкаДляЭкспортаToolStripMenuItem
            // 
            this.папкаДляЭкспортаToolStripMenuItem.Name = "папкаДляЭкспортаToolStripMenuItem";
            this.папкаДляЭкспортаToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.папкаДляЭкспортаToolStripMenuItem.Text = "Папка для экспорта";
            this.папкаДляЭкспортаToolStripMenuItem.Click += new System.EventHandler(this.папкаДляЭкспортаToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanelSmallGallery);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerTableAndImageView);
            this.splitContainerMain.Size = new System.Drawing.Size(800, 513);
            this.splitContainerMain.SplitterDistance = 173;
            this.splitContainerMain.TabIndex = 4;
            this.splitContainerMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerMain_SplitterMoved);
            // 
            // flowLayoutPanelSmallGallery
            // 
            this.flowLayoutPanelSmallGallery.AutoScroll = true;
            this.flowLayoutPanelSmallGallery.AutoSize = true;
            this.flowLayoutPanelSmallGallery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelSmallGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSmallGallery.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSmallGallery.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelSmallGallery.Name = "flowLayoutPanelSmallGallery";
            this.flowLayoutPanelSmallGallery.Size = new System.Drawing.Size(173, 513);
            this.flowLayoutPanelSmallGallery.TabIndex = 0;
            this.flowLayoutPanelSmallGallery.WrapContents = false;
            this.flowLayoutPanelSmallGallery.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelSmallGallery_Paint);
            // 
            // splitContainerTableAndImageView
            // 
            this.splitContainerTableAndImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTableAndImageView.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTableAndImageView.Name = "splitContainerTableAndImageView";
            this.splitContainerTableAndImageView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTableAndImageView.Panel1
            // 
            this.splitContainerTableAndImageView.Panel1.Controls.Add(this.dataGridViewImageData);
            // 
            // splitContainerTableAndImageView.Panel2
            // 
            this.splitContainerTableAndImageView.Panel2.Controls.Add(this.splitContainerImageViewAndbuttons);
            this.splitContainerTableAndImageView.Size = new System.Drawing.Size(623, 513);
            this.splitContainerTableAndImageView.SplitterDistance = 144;
            this.splitContainerTableAndImageView.SplitterWidth = 1;
            this.splitContainerTableAndImageView.TabIndex = 0;
            // 
            // dataGridViewImageData
            // 
            this.dataGridViewImageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImageData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFileName,
            this.columnWidth,
            this.columnHeight,
            this.columnCopyrightText});
            this.dataGridViewImageData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewImageData.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewImageData.Name = "dataGridViewImageData";
            this.dataGridViewImageData.RowHeadersWidth = 51;
            this.dataGridViewImageData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImageData.Size = new System.Drawing.Size(623, 144);
            this.dataGridViewImageData.TabIndex = 0;
            // 
            // columnFileName
            // 
            this.columnFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnFileName.HeaderText = "Название";
            this.columnFileName.MinimumWidth = 6;
            this.columnFileName.Name = "columnFileName";
            this.columnFileName.ReadOnly = true;
            // 
            // columnWidth
            // 
            this.columnWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnWidth.HeaderText = "Ширина";
            this.columnWidth.MinimumWidth = 6;
            this.columnWidth.Name = "columnWidth";
            this.columnWidth.ReadOnly = true;
            // 
            // columnHeight
            // 
            this.columnHeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnHeight.HeaderText = "Высота";
            this.columnHeight.MinimumWidth = 6;
            this.columnHeight.Name = "columnHeight";
            this.columnHeight.ReadOnly = true;
            // 
            // columnCopyrightText
            // 
            this.columnCopyrightText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnCopyrightText.HeaderText = "Текст";
            this.columnCopyrightText.MinimumWidth = 6;
            this.columnCopyrightText.Name = "columnCopyrightText";
            this.columnCopyrightText.ReadOnly = true;
            // 
            // splitContainerImageViewAndbuttons
            // 
            this.splitContainerImageViewAndbuttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerImageViewAndbuttons.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerImageViewAndbuttons.IsSplitterFixed = true;
            this.splitContainerImageViewAndbuttons.Location = new System.Drawing.Point(0, 0);
            this.splitContainerImageViewAndbuttons.Name = "splitContainerImageViewAndbuttons";
            // 
            // splitContainerImageViewAndbuttons.Panel1
            // 
            this.splitContainerImageViewAndbuttons.Panel1.Controls.Add(this.panelForImageBox);
            this.splitContainerImageViewAndbuttons.Panel1MinSize = 300;
            // 
            // splitContainerImageViewAndbuttons.Panel2
            // 
            this.splitContainerImageViewAndbuttons.Panel2.Controls.Add(this.tableLayoutPanelForButtons);
            this.splitContainerImageViewAndbuttons.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerImageViewAndbuttons_Panel2_Paint);
            this.splitContainerImageViewAndbuttons.Panel2MinSize = 140;
            this.splitContainerImageViewAndbuttons.Size = new System.Drawing.Size(623, 368);
            this.splitContainerImageViewAndbuttons.SplitterDistance = 470;
            this.splitContainerImageViewAndbuttons.TabIndex = 0;
            // 
            // panelForImageBox
            // 
            this.panelForImageBox.Controls.Add(this.pictureBoxForChoosenImage);
            this.panelForImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForImageBox.Location = new System.Drawing.Point(0, 0);
            this.panelForImageBox.Name = "panelForImageBox";
            this.panelForImageBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.panelForImageBox.Size = new System.Drawing.Size(470, 368);
            this.panelForImageBox.TabIndex = 0;
            // 
            // pictureBoxForChoosenImage
            // 
            this.pictureBoxForChoosenImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxForChoosenImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxForChoosenImage.Name = "pictureBoxForChoosenImage";
            this.pictureBoxForChoosenImage.Size = new System.Drawing.Size(470, 364);
            this.pictureBoxForChoosenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxForChoosenImage.TabIndex = 1;
            this.pictureBoxForChoosenImage.TabStop = false;
            // 
            // tableLayoutPanelForButtons
            // 
            this.tableLayoutPanelForButtons.ColumnCount = 1;
            this.tableLayoutPanelForButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForButtons.Controls.Add(this.buttonCopyrightText, 0, 7);
            this.tableLayoutPanelForButtons.Controls.Add(this.buttonBatchMode, 0, 4);
            this.tableLayoutPanelForButtons.Controls.Add(this.buttonSaveImage, 0, 3);
            this.tableLayoutPanelForButtons.Controls.Add(this.buttonAddCopyright, 0, 2);
            this.tableLayoutPanelForButtons.Controls.Add(this.buttonOpenDirectory, 0, 1);
            this.tableLayoutPanelForButtons.Controls.Add(this.buttonOpenImage, 0, 0);
            this.tableLayoutPanelForButtons.Controls.Add(this.progressBarBatch, 0, 6);
            this.tableLayoutPanelForButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForButtons.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelForButtons.Name = "tableLayoutPanelForButtons";
            this.tableLayoutPanelForButtons.RowCount = 8;
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelForButtons.Size = new System.Drawing.Size(149, 368);
            this.tableLayoutPanelForButtons.TabIndex = 5;
            // 
            // buttonCopyrightText
            // 
            this.buttonCopyrightText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyrightText.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonCopyrightText.Location = new System.Drawing.Point(12, 274);
            this.buttonCopyrightText.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.buttonCopyrightText.Name = "buttonCopyrightText";
            this.buttonCopyrightText.Size = new System.Drawing.Size(127, 38);
            this.buttonCopyrightText.TabIndex = 9;
            this.buttonCopyrightText.Text = "Текст водяного знака";
            this.buttonCopyrightText.UseVisualStyleBackColor = true;
            this.buttonCopyrightText.Click += new System.EventHandler(this.buttonCopyrightText_Click);
            // 
            // buttonBatchMode
            // 
            this.buttonBatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBatchMode.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonBatchMode.Location = new System.Drawing.Point(12, 193);
            this.buttonBatchMode.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.buttonBatchMode.Name = "buttonBatchMode";
            this.buttonBatchMode.Size = new System.Drawing.Size(127, 38);
            this.buttonBatchMode.TabIndex = 8;
            this.buttonBatchMode.Text = "Пакетный режим обработки";
            this.buttonBatchMode.UseVisualStyleBackColor = true;
            this.buttonBatchMode.Click += new System.EventHandler(this.buttonBatchMode_Click);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveImage.Location = new System.Drawing.Point(12, 145);
            this.buttonSaveImage.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(127, 38);
            this.buttonSaveImage.TabIndex = 7;
            this.buttonSaveImage.Text = "Сохранить изображение";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // buttonAddCopyright
            // 
            this.buttonAddCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCopyright.Location = new System.Drawing.Point(12, 97);
            this.buttonAddCopyright.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.buttonAddCopyright.Name = "buttonAddCopyright";
            this.buttonAddCopyright.Size = new System.Drawing.Size(127, 38);
            this.buttonAddCopyright.TabIndex = 6;
            this.buttonAddCopyright.Text = "Добавить водяной знак";
            this.buttonAddCopyright.UseVisualStyleBackColor = true;
            this.buttonAddCopyright.Click += new System.EventHandler(this.buttonAddCopyright_Click);
            // 
            // buttonOpenDirectory
            // 
            this.buttonOpenDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenDirectory.Location = new System.Drawing.Point(12, 49);
            this.buttonOpenDirectory.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.buttonOpenDirectory.Name = "buttonOpenDirectory";
            this.buttonOpenDirectory.Size = new System.Drawing.Size(127, 38);
            this.buttonOpenDirectory.TabIndex = 5;
            this.buttonOpenDirectory.Text = "Открыть директорию";
            this.buttonOpenDirectory.UseVisualStyleBackColor = true;
            this.buttonOpenDirectory.Click += new System.EventHandler(this.buttonOpenDirectory_Click);
            // 
            // buttonOpenImage
            // 
            this.buttonOpenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenImage.Location = new System.Drawing.Point(12, 1);
            this.buttonOpenImage.Margin = new System.Windows.Forms.Padding(10, 1, 10, 10);
            this.buttonOpenImage.Name = "buttonOpenImage";
            this.buttonOpenImage.Size = new System.Drawing.Size(127, 38);
            this.buttonOpenImage.TabIndex = 4;
            this.buttonOpenImage.Text = "Открыть изображение";
            this.buttonOpenImage.UseVisualStyleBackColor = true;
            this.buttonOpenImage.Click += new System.EventHandler(this.buttonOpenImage_Click);
            // 
            // progressBarBatch
            // 
            this.progressBarBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarBatch.Location = new System.Drawing.Point(13, 241);
            this.progressBarBatch.Margin = new System.Windows.Forms.Padding(13, 0, 10, 10);
            this.progressBarBatch.Name = "progressBarBatch";
            this.progressBarBatch.Size = new System.Drawing.Size(126, 23);
            this.progressBarBatch.TabIndex = 2;
            this.progressBarBatch.Visible = false;
            // 
            // contextMenuStripGalleryRightClick
            // 
            this.contextMenuStripGalleryRightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripGalleryRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.просмотрToolStripMenuItem,
            this.наложитьВодянойЗнакToolStripMenuItem});
            this.contextMenuStripGalleryRightClick.Name = "contextMenuStripGalleryRightClick";
            this.contextMenuStripGalleryRightClick.Size = new System.Drawing.Size(207, 70);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            // 
            // наложитьВодянойЗнакToolStripMenuItem
            // 
            this.наложитьВодянойЗнакToolStripMenuItem.Name = "наложитьВодянойЗнакToolStripMenuItem";
            this.наложитьВодянойЗнакToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.наложитьВодянойЗнакToolStripMenuItem.Text = "Наложить водяной знак";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(753, 574);
            this.Name = "FormMain";
            this.Text = "Копирайтер";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerTableAndImageView.Panel1.ResumeLayout(false);
            this.splitContainerTableAndImageView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTableAndImageView)).EndInit();
            this.splitContainerTableAndImageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImageData)).EndInit();
            this.splitContainerImageViewAndbuttons.Panel1.ResumeLayout(false);
            this.splitContainerImageViewAndbuttons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImageViewAndbuttons)).EndInit();
            this.splitContainerImageViewAndbuttons.ResumeLayout(false);
            this.panelForImageBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForChoosenImage)).EndInit();
            this.tableLayoutPanelForButtons.ResumeLayout(false);
            this.contextMenuStripGalleryRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьДиректориюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВодянойЗнакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пакетныйРежимОбработкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстВодяногоЗнакаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаДляЭкспортаToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerTableAndImageView;
        private System.Windows.Forms.SplitContainer splitContainerImageViewAndbuttons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSmallGallery;
        private System.Windows.Forms.DataGridView dataGridViewImageData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGalleryRightClick;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наложитьВодянойЗнакToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCopyrightText;
        private System.Windows.Forms.Panel panelForImageBox;
        private System.Windows.Forms.PictureBox pictureBoxForChoosenImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForButtons;
        private System.Windows.Forms.Button buttonBatchMode;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonAddCopyright;
        private System.Windows.Forms.Button buttonOpenDirectory;
        private System.Windows.Forms.Button buttonOpenImage;
        private System.Windows.Forms.Button buttonCopyrightText;
        private System.Windows.Forms.ProgressBar progressBarBatch;
    }
}

