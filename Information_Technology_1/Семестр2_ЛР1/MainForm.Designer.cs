﻿namespace Семестр2_ЛР1
{
    partial class MainForm
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
            this.buttonAuthentification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAuthentification
            // 
            this.buttonAuthentification.Location = new System.Drawing.Point(98, 220);
            this.buttonAuthentification.Name = "buttonAuthentification";
            this.buttonAuthentification.Size = new System.Drawing.Size(75, 23);
            this.buttonAuthentification.TabIndex = 0;
            this.buttonAuthentification.Text = "Войти";
            this.buttonAuthentification.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAuthentification);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAuthentification;
    }
}