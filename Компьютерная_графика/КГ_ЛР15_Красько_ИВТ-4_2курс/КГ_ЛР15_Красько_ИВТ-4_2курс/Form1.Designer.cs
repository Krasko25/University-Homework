namespace КГ_ЛР15_Красько_ИВТ_4_2курс
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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBarPhi = new System.Windows.Forms.TrackBar();
            this.trackBarTeta = new System.Windows.Forms.TrackBar();
            this.labelTetaAngle = new System.Windows.Forms.Label();
            this.labelPhiAngle = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelAside = new System.Windows.Forms.Label();
            this.trackBarAside = new System.Windows.Forms.TrackBar();
            this.labelBside = new System.Windows.Forms.Label();
            this.trackBarBside = new System.Windows.Forms.TrackBar();
            this.labelCside = new System.Windows.Forms.Label();
            this.trackBarCside = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCside)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(813, 357);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(159, 48);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(799, 613);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // trackBarPhi
            // 
            this.trackBarPhi.Location = new System.Drawing.Point(868, 109);
            this.trackBarPhi.Maximum = 360;
            this.trackBarPhi.Minimum = 1;
            this.trackBarPhi.Name = "trackBarPhi";
            this.trackBarPhi.Size = new System.Drawing.Size(104, 56);
            this.trackBarPhi.TabIndex = 2;
            this.trackBarPhi.Value = 1;
            this.trackBarPhi.Scroll += new System.EventHandler(this.trackBarPhi_Scroll_1);
            // 
            // trackBarTeta
            // 
            this.trackBarTeta.Location = new System.Drawing.Point(868, 47);
            this.trackBarTeta.Maximum = 360;
            this.trackBarTeta.Name = "trackBarTeta";
            this.trackBarTeta.Size = new System.Drawing.Size(104, 56);
            this.trackBarTeta.TabIndex = 3;
            this.trackBarTeta.Scroll += new System.EventHandler(this.trackBarTeta_Scroll_1);
            // 
            // labelTetaAngle
            // 
            this.labelTetaAngle.AutoSize = true;
            this.labelTetaAngle.Location = new System.Drawing.Point(823, 47);
            this.labelTetaAngle.Name = "labelTetaAngle";
            this.labelTetaAngle.Size = new System.Drawing.Size(27, 16);
            this.labelTetaAngle.TabIndex = 4;
            this.labelTetaAngle.Text = "θ = ";
            // 
            // labelPhiAngle
            // 
            this.labelPhiAngle.AutoSize = true;
            this.labelPhiAngle.Location = new System.Drawing.Point(823, 109);
            this.labelPhiAngle.Name = "labelPhiAngle";
            this.labelPhiAngle.Size = new System.Drawing.Size(29, 16);
            this.labelPhiAngle.TabIndex = 5;
            this.labelPhiAngle.Text = "φ = ";
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelAside
            // 
            this.labelAside.AutoSize = true;
            this.labelAside.Location = new System.Drawing.Point(823, 171);
            this.labelAside.Name = "labelAside";
            this.labelAside.Size = new System.Drawing.Size(29, 16);
            this.labelAside.TabIndex = 7;
            this.labelAside.Text = "A = ";
            // 
            // trackBarAside
            // 
            this.trackBarAside.Location = new System.Drawing.Point(868, 171);
            this.trackBarAside.Maximum = 50;
            this.trackBarAside.Minimum = 10;
            this.trackBarAside.Name = "trackBarAside";
            this.trackBarAside.Size = new System.Drawing.Size(104, 56);
            this.trackBarAside.TabIndex = 6;
            this.trackBarAside.Value = 10;
            this.trackBarAside.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // labelBside
            // 
            this.labelBside.AutoSize = true;
            this.labelBside.Location = new System.Drawing.Point(823, 233);
            this.labelBside.Name = "labelBside";
            this.labelBside.Size = new System.Drawing.Size(29, 16);
            this.labelBside.TabIndex = 9;
            this.labelBside.Text = "B = ";
            // 
            // trackBarBside
            // 
            this.trackBarBside.Location = new System.Drawing.Point(868, 233);
            this.trackBarBside.Maximum = 50;
            this.trackBarBside.Minimum = 10;
            this.trackBarBside.Name = "trackBarBside";
            this.trackBarBside.Size = new System.Drawing.Size(104, 56);
            this.trackBarBside.TabIndex = 8;
            this.trackBarBside.Value = 10;
            this.trackBarBside.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // labelCside
            // 
            this.labelCside.AutoSize = true;
            this.labelCside.Location = new System.Drawing.Point(823, 295);
            this.labelCside.Name = "labelCside";
            this.labelCside.Size = new System.Drawing.Size(29, 16);
            this.labelCside.TabIndex = 11;
            this.labelCside.Text = "C = ";
            // 
            // trackBarCside
            // 
            this.trackBarCside.Location = new System.Drawing.Point(868, 295);
            this.trackBarCside.Maximum = 50;
            this.trackBarCside.Minimum = 10;
            this.trackBarCside.Name = "trackBarCside";
            this.trackBarCside.Size = new System.Drawing.Size(104, 56);
            this.trackBarCside.TabIndex = 10;
            this.trackBarCside.Value = 10;
            this.trackBarCside.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 613);
            this.Controls.Add(this.labelCside);
            this.Controls.Add(this.trackBarCside);
            this.Controls.Add(this.labelBside);
            this.Controls.Add(this.trackBarBside);
            this.Controls.Add(this.labelAside);
            this.Controls.Add(this.trackBarAside);
            this.Controls.Add(this.labelPhiAngle);
            this.Controls.Add(this.labelTetaAngle);
            this.Controls.Add(this.trackBarTeta);
            this.Controls.Add(this.trackBarPhi);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonStart);
            this.MaximumSize = new System.Drawing.Size(1007, 660);
            this.MinimumSize = new System.Drawing.Size(1007, 660);
            this.Name = "Form";
            this.Text = "ЛР15 Проволочная модель";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCside)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBarPhi;
        private System.Windows.Forms.TrackBar trackBarTeta;
        private System.Windows.Forms.Label labelTetaAngle;
        private System.Windows.Forms.Label labelPhiAngle;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelAside;
        private System.Windows.Forms.TrackBar trackBarAside;
        private System.Windows.Forms.Label labelBside;
        private System.Windows.Forms.TrackBar trackBarBside;
        private System.Windows.Forms.Label labelCside;
        private System.Windows.Forms.TrackBar trackBarCside;
    }
}

