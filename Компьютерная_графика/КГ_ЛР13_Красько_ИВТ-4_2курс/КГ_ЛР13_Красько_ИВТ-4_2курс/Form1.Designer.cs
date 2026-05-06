namespace КГ_ЛР13_Красько_ИВТ_4_2курс
{
    partial class Form1
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
            this.buttonDraw = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dataGridViewCoordinates = new System.Windows.Forms.DataGridView();
            this.textBoxVertexAmount = new System.Windows.Forms.TextBox();
            this.labelVertexAmount = new System.Windows.Forms.Label();
            this.buttonUpdateTable = new System.Windows.Forms.Button();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoordinates)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(279, 553);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(200, 48);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Нарисовать";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(758, 547);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // dataGridViewCoordinates
            // 
            this.dataGridViewCoordinates.AllowUserToAddRows = false;
            this.dataGridViewCoordinates.AllowUserToDeleteRows = false;
            this.dataGridViewCoordinates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoordinates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnY});
            this.dataGridViewCoordinates.Location = new System.Drawing.Point(777, 88);
            this.dataGridViewCoordinates.Name = "dataGridViewCoordinates";
            this.dataGridViewCoordinates.RowHeadersWidth = 51;
            this.dataGridViewCoordinates.RowTemplate.Height = 24;
            this.dataGridViewCoordinates.Size = new System.Drawing.Size(200, 513);
            this.dataGridViewCoordinates.TabIndex = 2;
            // 
            // textBoxVertexAmount
            // 
            this.textBoxVertexAmount.Location = new System.Drawing.Point(777, 57);
            this.textBoxVertexAmount.Name = "textBoxVertexAmount";
            this.textBoxVertexAmount.Size = new System.Drawing.Size(123, 22);
            this.textBoxVertexAmount.TabIndex = 3;
            // 
            // labelVertexAmount
            // 
            this.labelVertexAmount.AutoSize = true;
            this.labelVertexAmount.Location = new System.Drawing.Point(775, 34);
            this.labelVertexAmount.Name = "labelVertexAmount";
            this.labelVertexAmount.Size = new System.Drawing.Size(172, 16);
            this.labelVertexAmount.TabIndex = 4;
            this.labelVertexAmount.Text = "Количество вершин (>20):";
            this.labelVertexAmount.Click += new System.EventHandler(this.labelVertexAmount_Click);
            // 
            // buttonUpdateTable
            // 
            this.buttonUpdateTable.Location = new System.Drawing.Point(919, 55);
            this.buttonUpdateTable.Name = "buttonUpdateTable";
            this.buttonUpdateTable.Size = new System.Drawing.Size(58, 27);
            this.buttonUpdateTable.TabIndex = 5;
            this.buttonUpdateTable.Text = "ОК";
            this.buttonUpdateTable.UseVisualStyleBackColor = true;
            this.buttonUpdateTable.Click += new System.EventHandler(this.buttonUpdateTable_Click);
            // 
            // ColumnX
            // 
            this.ColumnX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnX.HeaderText = "X";
            this.ColumnX.MinimumWidth = 6;
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnY
            // 
            this.ColumnY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.MinimumWidth = 6;
            this.ColumnY.Name = "ColumnY";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 613);
            this.Controls.Add(this.buttonUpdateTable);
            this.Controls.Add(this.labelVertexAmount);
            this.Controls.Add(this.textBoxVertexAmount);
            this.Controls.Add(this.dataGridViewCoordinates);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonDraw);
            this.MaximumSize = new System.Drawing.Size(1007, 660);
            this.MinimumSize = new System.Drawing.Size(1007, 660);
            this.Name = "Form1";
            this.Text = "ЛР13 Декомпозиция полигонов на треугольники";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoordinates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.DataGridView dataGridViewCoordinates;
        private System.Windows.Forms.TextBox textBoxVertexAmount;
        private System.Windows.Forms.Label labelVertexAmount;
        private System.Windows.Forms.Button buttonUpdateTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
    }
}

