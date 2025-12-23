namespace КГ_ЛР8_Красько_ИВТ_4_2курс
{
    partial class FormUFOFight
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
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonGiveUp = new System.Windows.Forms.Button();
            this.timerGameStep = new System.Windows.Forms.Timer(this.components);
            this.timerEnemy = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGame
            // 
            this.pictureBoxGame.Location = new System.Drawing.Point(16, 15);
            this.pictureBoxGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxGame.Name = "pictureBoxGame";
            this.pictureBoxGame.Size = new System.Drawing.Size(1547, 837);
            this.pictureBoxGame.TabIndex = 0;
            this.pictureBoxGame.TabStop = false;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(16, 868);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(280, 54);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.Text = "Играть";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonGiveUp
            // 
            this.buttonGiveUp.Location = new System.Drawing.Point(1283, 868);
            this.buttonGiveUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGiveUp.Name = "buttonGiveUp";
            this.buttonGiveUp.Size = new System.Drawing.Size(280, 54);
            this.buttonGiveUp.TabIndex = 4;
            this.buttonGiveUp.TabStop = false;
            this.buttonGiveUp.Text = "Начать сначала";
            this.buttonGiveUp.UseVisualStyleBackColor = true;
            this.buttonGiveUp.Click += new System.EventHandler(this.buttonGiveUp_Click);
            // 
            // timerGameStep
            // 
            this.timerGameStep.Interval = 20;
            this.timerGameStep.Tick += new System.EventHandler(this.timerGameStep_Tick);
            // 
            // timerEnemy
            // 
            this.timerEnemy.Interval = 500;
            // 
            // FormUFOFight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1576, 926);
            this.Controls.Add(this.buttonGiveUp);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.pictureBoxGame);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1594, 973);
            this.MinimumSize = new System.Drawing.Size(1594, 973);
            this.Name = "FormUFOFight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бой «летающих тарелок»";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGame;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonGiveUp;
        private System.Windows.Forms.Timer timerGameStep;
        private System.Windows.Forms.Timer timerEnemy;
    }
}

