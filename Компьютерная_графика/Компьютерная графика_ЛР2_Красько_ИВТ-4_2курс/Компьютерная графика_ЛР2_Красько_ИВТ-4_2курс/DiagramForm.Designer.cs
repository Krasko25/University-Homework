namespace Компьютерная_графика_ЛР2_Красько_ИВТ_4_2курс
{
    partial class DiagramForm
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
            this.pictureBoxWithGraphic = new System.Windows.Forms.PictureBox();
            this.buttonPixels = new System.Windows.Forms.Button();
            this.buttonMillimeter = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWithGraphic
            // 
            this.pictureBoxWithGraphic.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWithGraphic.Name = "pictureBoxWithGraphic";
            this.pictureBoxWithGraphic.Size = new System.Drawing.Size(1000, 500);
            this.pictureBoxWithGraphic.TabIndex = 0;
            this.pictureBoxWithGraphic.TabStop = false;
            // 
            // buttonPixels
            // 
            this.buttonPixels.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPixels.Location = new System.Drawing.Point(61, 506);
            this.buttonPixels.Name = "buttonPixels";
            this.buttonPixels.Size = new System.Drawing.Size(75, 23);
            this.buttonPixels.TabIndex = 1;
            this.buttonPixels.Text = "Пиксели";
            this.buttonPixels.UseVisualStyleBackColor = true;
            this.buttonPixels.Click += new System.EventHandler(this.buttonPixels_Click);
            // 
            // buttonMillimeter
            // 
            this.buttonMillimeter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMillimeter.Location = new System.Drawing.Point(434, 506);
            this.buttonMillimeter.Name = "buttonMillimeter";
            this.buttonMillimeter.Size = new System.Drawing.Size(102, 23);
            this.buttonMillimeter.TabIndex = 2;
            this.buttonMillimeter.Text = "Миллиметры";
            this.buttonMillimeter.UseVisualStyleBackColor = true;
            this.buttonMillimeter.Click += new System.EventHandler(this.buttonMillimeter_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClean.Location = new System.Drawing.Point(771, 506);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(158, 23);
            this.buttonClean.TabIndex = 3;
            this.buttonClean.Text = "Очистить";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // DiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 536);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.buttonMillimeter);
            this.Controls.Add(this.buttonPixels);
            this.Controls.Add(this.pictureBoxWithGraphic);
            this.Name = "DiagramForm";
            this.Text = "График";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxWithGraphic;
        private System.Windows.Forms.Button buttonPixels;
        private System.Windows.Forms.Button buttonMillimeter;
        private System.Windows.Forms.Button buttonClean;
    }
}

