namespace Семестр2_ЛР1
{
    partial class AuthentificationForm
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
            this.tableLayoutPanelAuthentification = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.buttonLogInCancel = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.toolTipLogin = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPassword = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelAuthentification.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAuthentification
            // 
            this.tableLayoutPanelAuthentification.AutoSize = true;
            this.tableLayoutPanelAuthentification.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAuthentification.ColumnCount = 2;
            this.tableLayoutPanelAuthentification.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAuthentification.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAuthentification.Controls.Add(this.textBoxLogin, 0, 1);
            this.tableLayoutPanelAuthentification.Controls.Add(this.labelLogin, 0, 0);
            this.tableLayoutPanelAuthentification.Controls.Add(this.buttonLogIn, 0, 4);
            this.tableLayoutPanelAuthentification.Controls.Add(this.buttonLogInCancel, 1, 4);
            this.tableLayoutPanelAuthentification.Controls.Add(this.labelPassword, 0, 2);
            this.tableLayoutPanelAuthentification.Controls.Add(this.textBoxPassword, 0, 3);
            this.tableLayoutPanelAuthentification.Controls.Add(this.cbShowPassword, 1, 2);
            this.tableLayoutPanelAuthentification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAuthentification.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelAuthentification.Name = "tableLayoutPanelAuthentification";
            this.tableLayoutPanelAuthentification.RowCount = 5;
            this.tableLayoutPanelAuthentification.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAuthentification.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAuthentification.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAuthentification.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAuthentification.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAuthentification.Size = new System.Drawing.Size(432, 298);
            this.tableLayoutPanelAuthentification.TabIndex = 0;
            this.tableLayoutPanelAuthentification.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelAuthentification_Paint);
            // 
            // textBoxLogin
            // 
            this.tableLayoutPanelAuthentification.SetColumnSpan(this.textBoxLogin, 2);
            this.textBoxLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.Location = new System.Drawing.Point(10, 65);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(412, 30);
            this.textBoxLogin.TabIndex = 0;
            this.toolTipLogin.SetToolTip(this.textBoxLogin, "Введите ваш логин");
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(5, 30);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(5, 30, 3, 5);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(208, 25);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Логин";
            this.labelLogin.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogIn.Location = new System.Drawing.Point(5, 230);
            this.buttonLogIn.Margin = new System.Windows.Forms.Padding(5, 50, 5, 25);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(206, 47);
            this.buttonLogIn.TabIndex = 1;
            this.buttonLogIn.Text = "Войти\r\n";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // buttonLogInCancel
            // 
            this.buttonLogInCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLogInCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogInCancel.Location = new System.Drawing.Point(221, 230);
            this.buttonLogInCancel.Margin = new System.Windows.Forms.Padding(5, 50, 5, 25);
            this.buttonLogInCancel.Name = "buttonLogInCancel";
            this.buttonLogInCancel.Size = new System.Drawing.Size(206, 47);
            this.buttonLogInCancel.TabIndex = 2;
            this.buttonLogInCancel.Text = "Отмена";
            this.buttonLogInCancel.UseVisualStyleBackColor = true;
            this.buttonLogInCancel.Click += new System.EventHandler(this.buttonLogInCancel_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(5, 110);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(206, 25);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль";
            // 
            // textBoxPassword
            // 
            this.tableLayoutPanelAuthentification.SetColumnSpan(this.textBoxPassword, 2);
            this.textBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.Location = new System.Drawing.Point(10, 145);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(412, 30);
            this.textBoxPassword.TabIndex = 5;
            this.toolTipPassword.SetToolTip(this.textBoxPassword, "Введите ваш пароль");
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShowPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbShowPassword.Location = new System.Drawing.Point(221, 110);
            this.cbShowPassword.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(206, 25);
            this.cbShowPassword.TabIndex = 6;
            this.cbShowPassword.Text = "Показывать пароль";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.cbShowPassword_CheckedChanged);
            // 
            // toolTipLogin
            // 
            this.toolTipLogin.AutoPopDelay = 1000;
            this.toolTipLogin.InitialDelay = 500;
            this.toolTipLogin.IsBalloon = true;
            this.toolTipLogin.ReshowDelay = 100;
            this.toolTipLogin.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // toolTipPassword
            // 
            this.toolTipPassword.AutoPopDelay = 1000;
            this.toolTipPassword.InitialDelay = 500;
            this.toolTipPassword.IsBalloon = true;
            this.toolTipPassword.ReshowDelay = 100;
            // 
            // AuthentificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 298);
            this.Controls.Add(this.tableLayoutPanelAuthentification);
            this.Name = "AuthentificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Органайзер";
            this.tableLayoutPanelAuthentification.ResumeLayout(false);
            this.tableLayoutPanelAuthentification.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAuthentification;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Button buttonLogInCancel;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.ToolTip toolTipPassword;
    }
}

