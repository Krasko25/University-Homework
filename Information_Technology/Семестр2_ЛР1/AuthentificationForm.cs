using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//для чтения файла с данными пользователя
using System.IO;


namespace Семестр2_ЛР1
{
    public partial class AuthentificationForm : Form
    {
        public AuthentificationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = (char)0;
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
        }

        private void tableLayoutPanelAuthentification_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void buttonLogInCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            // Путь к файлу, в котором будет надёжно спрятаны данные пользователя
            string filePath = "doNOTopenPleaseee.txt";

            // Проверяем, существует ли файл
            if (File.Exists(filePath))
            {
                // Считываем все строки из файла
                string[] credentials = File.ReadAllLines(filePath);

                // Проверяем, что в файле есть хотя бы 2 строки
                if (credentials.Length >= 2)
                {
                    string correctLogin = credentials[0];
                    string correctPassword = credentials[1];

    
                    if (username == correctLogin && password == correctPassword)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль неверные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Файл поврежден или пустой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не найден файл с данными!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
