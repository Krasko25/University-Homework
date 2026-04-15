namespace КГ_ЛР11_2_Красько_ИВТ_4_2курс
{
    partial class Form
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
            this.buttonReadAndDisplay = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAdjustBorders = new System.Windows.Forms.Button();
            this.textBoxXmin = new System.Windows.Forms.TextBox();
            this.labelXmin = new System.Windows.Forms.Label();
            this.labelXmax = new System.Windows.Forms.Label();
            this.textBoxXmax = new System.Windows.Forms.TextBox();
            this.labelYmin = new System.Windows.Forms.Label();
            this.textBoxYmin = new System.Windows.Forms.TextBox();
            this.labelYmax = new System.Windows.Forms.Label();
            this.textBoxYmax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadAndDisplay
            // 
            this.buttonReadAndDisplay.Location = new System.Drawing.Point(12, 548);
            this.buttonReadAndDisplay.Name = "buttonReadAndDisplay";
            this.buttonReadAndDisplay.Size = new System.Drawing.Size(328, 48);
            this.buttonReadAndDisplay.TabIndex = 0;
            this.buttonReadAndDisplay.Text = "Прочитать из файла и отобразить";
            this.buttonReadAndDisplay.UseVisualStyleBackColor = true;
            this.buttonReadAndDisplay.Click += new System.EventHandler(this.buttonReadAndDisplay_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(703, 501);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(387, 548);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(328, 48);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить область вывода";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAdjustBorders
            // 
            this.buttonAdjustBorders.Location = new System.Drawing.Point(752, 250);
            this.buttonAdjustBorders.Name = "buttonAdjustBorders";
            this.buttonAdjustBorders.Size = new System.Drawing.Size(202, 48);
            this.buttonAdjustBorders.TabIndex = 3;
            this.buttonAdjustBorders.Text = "Изменить область вывода";
            this.buttonAdjustBorders.UseVisualStyleBackColor = true;
            this.buttonAdjustBorders.Click += new System.EventHandler(this.buttonAdjustBorders_Click);
            // 
            // textBoxXmin
            // 
            this.textBoxXmin.Location = new System.Drawing.Point(783, 134);
            this.textBoxXmin.Name = "textBoxXmin";
            this.textBoxXmin.Size = new System.Drawing.Size(53, 22);
            this.textBoxXmin.TabIndex = 4;
            // 
            // labelXmin
            // 
            this.labelXmin.AutoSize = true;
            this.labelXmin.Location = new System.Drawing.Point(786, 115);
            this.labelXmin.Name = "labelXmin";
            this.labelXmin.Size = new System.Drawing.Size(36, 16);
            this.labelXmin.TabIndex = 5;
            this.labelXmin.Text = "Xmin";
            // 
            // labelXmax
            // 
            this.labelXmax.AutoSize = true;
            this.labelXmax.Location = new System.Drawing.Point(866, 115);
            this.labelXmax.Name = "labelXmax";
            this.labelXmax.Size = new System.Drawing.Size(40, 16);
            this.labelXmax.TabIndex = 7;
            this.labelXmax.Text = "Xmax";
            // 
            // textBoxXmax
            // 
            this.textBoxXmax.Location = new System.Drawing.Point(863, 134);
            this.textBoxXmax.Name = "textBoxXmax";
            this.textBoxXmax.Size = new System.Drawing.Size(53, 22);
            this.textBoxXmax.TabIndex = 6;
            // 
            // labelYmin
            // 
            this.labelYmin.AutoSize = true;
            this.labelYmin.Location = new System.Drawing.Point(786, 179);
            this.labelYmin.Name = "labelYmin";
            this.labelYmin.Size = new System.Drawing.Size(37, 16);
            this.labelYmin.TabIndex = 9;
            this.labelYmin.Text = "Ymin";
            // 
            // textBoxYmin
            // 
            this.textBoxYmin.Location = new System.Drawing.Point(783, 198);
            this.textBoxYmin.Name = "textBoxYmin";
            this.textBoxYmin.Size = new System.Drawing.Size(53, 22);
            this.textBoxYmin.TabIndex = 8;
            // 
            // labelYmax
            // 
            this.labelYmax.AutoSize = true;
            this.labelYmax.Location = new System.Drawing.Point(866, 179);
            this.labelYmax.Name = "labelYmax";
            this.labelYmax.Size = new System.Drawing.Size(41, 16);
            this.labelYmax.TabIndex = 11;
            this.labelYmax.Text = "Ymax";
            // 
            // textBoxYmax
            // 
            this.textBoxYmax.Location = new System.Drawing.Point(863, 198);
            this.textBoxYmax.Name = "textBoxYmax";
            this.textBoxYmax.Size = new System.Drawing.Size(53, 22);
            this.textBoxYmax.TabIndex = 10;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 613);
            this.Controls.Add(this.labelYmax);
            this.Controls.Add(this.textBoxYmax);
            this.Controls.Add(this.labelYmin);
            this.Controls.Add(this.textBoxYmin);
            this.Controls.Add(this.labelXmax);
            this.Controls.Add(this.textBoxXmax);
            this.Controls.Add(this.labelXmin);
            this.Controls.Add(this.textBoxXmin);
            this.Controls.Add(this.buttonAdjustBorders);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonReadAndDisplay);
            this.MaximumSize = new System.Drawing.Size(1007, 660);
            this.MinimumSize = new System.Drawing.Size(1007, 660);
            this.Name = "Form";
            this.Text = "Автоматический подбор размеров и позиций";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReadAndDisplay;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAdjustBorders;
        private System.Windows.Forms.TextBox textBoxXmin;
        private System.Windows.Forms.Label labelXmin;
        private System.Windows.Forms.Label labelXmax;
        private System.Windows.Forms.TextBox textBoxXmax;
        private System.Windows.Forms.Label labelYmin;
        private System.Windows.Forms.TextBox textBoxYmin;
        private System.Windows.Forms.Label labelYmax;
        private System.Windows.Forms.TextBox textBoxYmax;
    }
}

