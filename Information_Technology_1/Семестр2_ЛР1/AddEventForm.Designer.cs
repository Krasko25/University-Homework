namespace Семестр2_ЛР1
{
    partial class AddEventForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxTypeOfTheNewRecord = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.monthCalendarDatePicker = new System.Windows.Forms.MonthCalendar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.43758F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.10719F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.32913F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDescription, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTypeOfTheNewRecord, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(666, 126);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(5, 97);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(127, 24);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 30, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тип записи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 30, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Текст";
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(10, 62);
            this.dateTimePickerTime.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.Size = new System.Drawing.Size(127, 20);
            this.dateTimePickerTime.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 30, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Время";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(147, 62);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(357, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // comboBoxTypeOfTheNewRecord
            // 
            this.comboBoxTypeOfTheNewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTypeOfTheNewRecord.FormattingEnabled = true;
            this.comboBoxTypeOfTheNewRecord.Location = new System.Drawing.Point(514, 62);
            this.comboBoxTypeOfTheNewRecord.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.comboBoxTypeOfTheNewRecord.Name = "comboBoxTypeOfTheNewRecord";
            this.comboBoxTypeOfTheNewRecord.Size = new System.Drawing.Size(142, 21);
            this.comboBoxTypeOfTheNewRecord.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(514, 97);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(142, 24);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Готово";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // monthCalendarDatePicker
            // 
            this.monthCalendarDatePicker.CalendarDimensions = new System.Drawing.Size(4, 1);
            this.monthCalendarDatePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendarDatePicker.Location = new System.Drawing.Point(0, 0);
            this.monthCalendarDatePicker.MinimumSize = new System.Drawing.Size(438, 168);
            this.monthCalendarDatePicker.Name = "monthCalendarDatePicker";
            this.monthCalendarDatePicker.TabIndex = 7;
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 372);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.monthCalendarDatePicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(516, 409);
            this.Name = "AddEventForm";
            this.Text = "Добавить событие";
            this.Load += new System.EventHandler(this.AddEventForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxTypeOfTheNewRecord;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.MonthCalendar monthCalendarDatePicker;
        private System.Windows.Forms.Button buttonCancel;
    }
}