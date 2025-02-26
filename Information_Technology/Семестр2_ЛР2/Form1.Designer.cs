namespace Семестр_2_ЛР2
{
    partial class FormFileManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПриложенииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonChangeFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonChangeColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInfo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFilesSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilesNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEditDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCheckAll = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStripMain.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1084, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.цветToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.шрифтToolStripMenuItem.Text = "Шрифт";
            this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.шрифтToolStripMenuItem_Click);
            // 
            // цветToolStripMenuItem
            // 
            this.цветToolStripMenuItem.Name = "цветToolStripMenuItem";
            this.цветToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.цветToolStripMenuItem.Text = "Цвет";
            this.цветToolStripMenuItem.Click += new System.EventHandler(this.цветToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПриложенииToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПриложенииToolStripMenuItem
            // 
            this.оПриложенииToolStripMenuItem.Name = "оПриложенииToolStripMenuItem";
            this.оПриложенииToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.оПриложенииToolStripMenuItem.Text = "О приложении";
            this.оПриложенииToolStripMenuItem.Click += new System.EventHandler(this.оПриложенииToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpenFile,
            this.toolStripButtonSaveFile,
            this.toolStripButtonChangeFont,
            this.toolStripButtonChangeColor,
            this.toolStripButtonInfo});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(1084, 32);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonOpenFile
            // 
            this.toolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenFile.Image = global::Семестр_2_ЛР2.Properties.Resources.open_folder_icon;
            this.toolStripButtonOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
            this.toolStripButtonOpenFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButtonOpenFile.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonOpenFile.Text = "toolStripButton1";
            this.toolStripButtonOpenFile.Click += new System.EventHandler(this.toolStripButtonOpenFile_Click);
            // 
            // toolStripButtonSaveFile
            // 
            this.toolStripButtonSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveFile.Image = global::Семестр_2_ЛР2.Properties.Resources.save_icon;
            this.toolStripButtonSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveFile.Name = "toolStripButtonSaveFile";
            this.toolStripButtonSaveFile.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSaveFile.Text = "toolStripButton2";
            this.toolStripButtonSaveFile.Click += new System.EventHandler(this.toolStripButtonSaveFile_Click);
            // 
            // toolStripButtonChangeFont
            // 
            this.toolStripButtonChangeFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChangeFont.Image = global::Семестр_2_ЛР2.Properties.Resources.change_font_icon;
            this.toolStripButtonChangeFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeFont.Name = "toolStripButtonChangeFont";
            this.toolStripButtonChangeFont.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonChangeFont.Text = "Шрифт";
            this.toolStripButtonChangeFont.Click += new System.EventHandler(this.toolStripButtonChangeFont_Click);
            // 
            // toolStripButtonChangeColor
            // 
            this.toolStripButtonChangeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChangeColor.Image = global::Семестр_2_ЛР2.Properties.Resources.change_color_icon;
            this.toolStripButtonChangeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeColor.Name = "toolStripButtonChangeColor";
            this.toolStripButtonChangeColor.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonChangeColor.Text = "toolStripButton1";
            this.toolStripButtonChangeColor.Click += new System.EventHandler(this.toolStripButtonChangeColor_Click);
            // 
            // toolStripButtonInfo
            // 
            this.toolStripButtonInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInfo.Image = global::Семестр_2_ЛР2.Properties.Resources.information_icon;
            this.toolStripButtonInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInfo.Name = "toolStripButtonInfo";
            this.toolStripButtonInfo.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonInfo.Text = "toolStripButton4";
            this.toolStripButtonInfo.Click += new System.EventHandler(this.toolStripButtonInfo_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFilesSize,
            this.toolStripStatusLabelFilesNumber});
            this.statusStrip.Location = new System.Drawing.Point(0, 608);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // toolStripStatusLabelFilesSize
            // 
            this.toolStripStatusLabelFilesSize.Name = "toolStripStatusLabelFilesSize";
            this.toolStripStatusLabelFilesSize.Size = new System.Drawing.Size(179, 17);
            this.toolStripStatusLabelFilesSize.Text = "Вес файлов (Кб) в директории: ";
            // 
            // toolStripStatusLabelFilesNumber
            // 
            this.toolStripStatusLabelFilesNumber.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.toolStripStatusLabelFilesNumber.Name = "toolStripStatusLabelFilesNumber";
            this.toolStripStatusLabelFilesNumber.Size = new System.Drawing.Size(195, 16);
            this.toolStripStatusLabelFilesNumber.Text = "Количество выделенных файлов: ";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.14771F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.85229F));
            this.tableLayoutPanelMain.Controls.Add(this.chart, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.listView, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.treeView, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 56);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.43911F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.56089F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1084, 552);
            this.tableLayoutPanelMain.TabIndex = 8;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.tableLayoutPanelMain.SetColumnSpan(this.chart, 2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 342);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1078, 207);
            this.chart.TabIndex = 8;
            this.chart.Text = "chart1";
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize,
            this.columnHeaderType,
            this.columnHeaderEditDate,
            this.columnHeaderCheckAll});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(286, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(795, 333);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Имя файла";
            this.columnHeaderName.Width = 200;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Размер (Кб)";
            this.columnHeaderSize.Width = 110;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Тип";
            this.columnHeaderType.Width = 80;
            // 
            // columnHeaderEditDate
            // 
            this.columnHeaderEditDate.Text = "Дата последнего изменения";
            this.columnHeaderEditDate.Width = 219;
            // 
            // columnHeaderCheckAll
            // 
            this.columnHeaderCheckAll.Text = "Снять все чекбоксы";
            this.columnHeaderCheckAll.Width = 216;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(5, 5);
            this.treeView.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(275, 331);
            this.treeView.TabIndex = 5;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // FormFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 630);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1100, 669);
            this.Name = "FormFileManager";
            this.Text = "Файловый менеджер";
            this.Load += new System.EventHandler(this.FormFileManager_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFileManager_KeyDown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem выйтиToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem шрифтToolStripMenuItem;
        private ToolStripMenuItem цветToolStripMenuItem;
        private ToolStripMenuItem помощьToolStripMenuItem;
        private ToolStripMenuItem оПриложенииToolStripMenuItem;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButtonOpenFile;
        private ToolStripButton toolStripButtonSaveFile;
        private ToolStripButton toolStripButtonChangeFont;
        private ToolStripButton toolStripButtonInfo;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabelFilesSize;
        private ToolStripStatusLabel toolStripStatusLabelFilesNumber;
        private TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private ListView listView;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderSize;
        private ColumnHeader columnHeaderType;
        private ColumnHeader columnHeaderEditDate;
        private TreeView treeView;
        private ColumnHeader columnHeaderCheckAll;
        private ToolStripButton toolStripButtonChangeColor;
    }
}
