namespace КГ_ЛР4_Красько_ИВТ_4_2курс
{
    partial class DrawADragon
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
            this.pictureBox_FieldForDragon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_DrawDragon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FieldForDragon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_FieldForDragon
            // 
            this.pictureBox_FieldForDragon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_FieldForDragon.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_FieldForDragon.Name = "pictureBox_FieldForDragon";
            this.pictureBox_FieldForDragon.Size = new System.Drawing.Size(1182, 562);
            this.pictureBox_FieldForDragon.TabIndex = 1;
            this.pictureBox_FieldForDragon.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_DrawDragon, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 568);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 85);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Btn_DrawDragon
            // 
            this.Btn_DrawDragon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Btn_DrawDragon.Location = new System.Drawing.Point(404, 8);
            this.Btn_DrawDragon.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.Btn_DrawDragon.Name = "Btn_DrawDragon";
            this.Btn_DrawDragon.Size = new System.Drawing.Size(381, 67);
            this.Btn_DrawDragon.TabIndex = 3;
            this.Btn_DrawDragon.Text = "Вывести кривую дракона";
            this.Btn_DrawDragon.UseVisualStyleBackColor = true;
            this.Btn_DrawDragon.Click += new System.EventHandler(this.Btn_DrawDragon_Click);
            // 
            // DrawADragon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox_FieldForDragon);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "DrawADragon";
            this.Text = "Кривая дракона";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FieldForDragon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_FieldForDragon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Btn_DrawDragon;
    }
}

