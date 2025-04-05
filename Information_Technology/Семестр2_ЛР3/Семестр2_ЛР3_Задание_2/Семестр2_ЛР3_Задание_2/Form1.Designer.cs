namespace Семестр2_ЛР3_Задание_2
{
    partial class FormCardsTable
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
            this.SuspendLayout();
            // 
            // FormCardsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "FormCardsTable";
            this.Text = "Стол с картами";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormCardsTable_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCardsTable_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCardsTable_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormCardsTable_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCardsTable_MouseUp);
            this.Resize += new System.EventHandler(this.FormCardsTable_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

