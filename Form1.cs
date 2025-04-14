using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        private bool pwd;
        public Form1()
        {
            InitializeComponent();
            pwd = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "user")
            {
                //Form Main = new Main();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pwd)
            {
                pwd = false;
                textBox2.PasswordChar = '*';
            }
            else
            {
                pwd = true;
                textBox2.PasswordChar = '\0';
            }
        }
    }
}
