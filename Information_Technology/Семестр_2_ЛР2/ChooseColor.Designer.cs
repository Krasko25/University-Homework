namespace Семестр_2_ЛР2
{
    partial class ChooseColor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panelArchiveFilesColorIndicator2 = new System.Windows.Forms.Panel();
            this.panelGrahicalFilesColorIndicator = new System.Windows.Forms.Panel();
            this.panelGrahicalFilesColorIndicator2 = new System.Windows.Forms.Panel();
            this.panelOfficeFilesColorIndicator = new System.Windows.Forms.Panel();
            this.panelOfficeFilesColorIndicator2 = new System.Windows.Forms.Panel();
            this.panelArchiveFilesColorIndicator = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panelExecutiveFilesColorIndicator = new System.Windows.Forms.Panel();
            this.panelExecutiveFilesColorIndicator2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выбрать цвет для файлов-изображений";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.3787F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.53391F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.08739F));
            this.tableLayoutPanel1.Controls.Add(this.panelExecutiveFilesColorIndicator2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.panelExecutiveFilesColorIndicator, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panelArchiveFilesColorIndicator, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelOfficeFilesColorIndicator2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelOfficeFilesColorIndicator, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelGrahicalFilesColorIndicator2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelGrahicalFilesColorIndicator, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelArchiveFilesColorIndicator2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 275);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(143, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 52);
            this.button2.TabIndex = 0;
            this.button2.Text = "Выбрать цвет для графических файлов";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(143, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 52);
            this.button3.TabIndex = 1;
            this.button3.Text = "Выбрать цвет для офисных файлов";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(143, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 52);
            this.button4.TabIndex = 2;
            this.button4.Text = "Выбрать цвет для архивов";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panelArchiveFilesColorIndicator2
            // 
            this.panelArchiveFilesColorIndicator2.Location = new System.Drawing.Point(326, 139);
            this.panelArchiveFilesColorIndicator2.Name = "panelArchiveFilesColorIndicator2";
            this.panelArchiveFilesColorIndicator2.Size = new System.Drawing.Size(135, 52);
            this.panelArchiveFilesColorIndicator2.TabIndex = 4;
            // 
            // panelGrahicalFilesColorIndicator
            // 
            this.panelGrahicalFilesColorIndicator.Location = new System.Drawing.Point(3, 23);
            this.panelGrahicalFilesColorIndicator.Name = "panelGrahicalFilesColorIndicator";
            this.panelGrahicalFilesColorIndicator.Size = new System.Drawing.Size(134, 52);
            this.panelGrahicalFilesColorIndicator.TabIndex = 7;
            // 
            // panelGrahicalFilesColorIndicator2
            // 
            this.panelGrahicalFilesColorIndicator2.Location = new System.Drawing.Point(326, 23);
            this.panelGrahicalFilesColorIndicator2.Name = "panelGrahicalFilesColorIndicator2";
            this.panelGrahicalFilesColorIndicator2.Size = new System.Drawing.Size(135, 52);
            this.panelGrahicalFilesColorIndicator2.TabIndex = 8;
            // 
            // panelOfficeFilesColorIndicator
            // 
            this.panelOfficeFilesColorIndicator.Location = new System.Drawing.Point(3, 81);
            this.panelOfficeFilesColorIndicator.Name = "panelOfficeFilesColorIndicator";
            this.panelOfficeFilesColorIndicator.Size = new System.Drawing.Size(134, 52);
            this.panelOfficeFilesColorIndicator.TabIndex = 9;
            // 
            // panelOfficeFilesColorIndicator2
            // 
            this.panelOfficeFilesColorIndicator2.Location = new System.Drawing.Point(326, 81);
            this.panelOfficeFilesColorIndicator2.Name = "panelOfficeFilesColorIndicator2";
            this.panelOfficeFilesColorIndicator2.Size = new System.Drawing.Size(135, 52);
            this.panelOfficeFilesColorIndicator2.TabIndex = 10;
            // 
            // panelArchiveFilesColorIndicator
            // 
            this.panelArchiveFilesColorIndicator.Location = new System.Drawing.Point(3, 139);
            this.panelArchiveFilesColorIndicator.Name = "panelArchiveFilesColorIndicator";
            this.panelArchiveFilesColorIndicator.Size = new System.Drawing.Size(134, 52);
            this.panelArchiveFilesColorIndicator.TabIndex = 11;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(143, 197);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(177, 52);
            this.button5.TabIndex = 12;
            this.button5.Text = "Выбрать цвет для .exe и .dll файлов";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panelExecutiveFilesColorIndicator
            // 
            this.panelExecutiveFilesColorIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutiveFilesColorIndicator.Location = new System.Drawing.Point(3, 197);
            this.panelExecutiveFilesColorIndicator.Name = "panelExecutiveFilesColorIndicator";
            this.panelExecutiveFilesColorIndicator.Size = new System.Drawing.Size(134, 52);
            this.panelExecutiveFilesColorIndicator.TabIndex = 15;
            // 
            // panelExecutiveFilesColorIndicator2
            // 
            this.panelExecutiveFilesColorIndicator2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutiveFilesColorIndicator2.Location = new System.Drawing.Point(326, 197);
            this.panelExecutiveFilesColorIndicator2.Name = "panelExecutiveFilesColorIndicator2";
            this.panelExecutiveFilesColorIndicator2.Size = new System.Drawing.Size(135, 52);
            this.panelExecutiveFilesColorIndicator2.TabIndex = 16;
            // 
            // ChooseColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 275);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Name = "ChooseColor";
            this.Text = "Выбор цветов для категорий файлов";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panelArchiveFilesColorIndicator;
        private Panel panelOfficeFilesColorIndicator2;
        private Panel panelOfficeFilesColorIndicator;
        private Panel panelGrahicalFilesColorIndicator2;
        private Panel panelGrahicalFilesColorIndicator;
        private Panel panelArchiveFilesColorIndicator2;
        private Panel panelExecutiveFilesColorIndicator2;
        private Panel panelExecutiveFilesColorIndicator;
        private Button button5;
    }
}