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
            GenerateCaptcha();
            pwd = true;
        }
        private void GenerateCaptcha()
        {
            int width = 235;  
            int height = 76;  
            Bitmap bitmap = new Bitmap(width, height);
            Random rand = new Random();

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.LightGray);
                string captchaText = GenerateRandomString(4);
                Font font = new Font("Arial", 24, FontStyle.Bold);
                int padding = 10; 
                float startX = 20;
                for (int i = 0; i < captchaText.Length; i++)
                {
                    float angle = (float)(rand.NextDouble() * 10 - 5);
                    g.RotateTransform(angle);
                    float x = startX + (i * (font.Size + padding));
                    float y = (height - font.Height) / 2;
                    g.DrawString(captchaText[i].ToString(), font, Brushes.Black, x, y);
                    g.RotateTransform(-angle);
                    using (Pen pen = new Pen(Color.Black, 3))
                    {
                        g.DrawLine(pen, x, y + font.Height / 2, x + font.Size, y + font.Height / 2);
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }
            return new string(stringChars);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "user")
            {
                Form Main = new Main();
                Main.Show();
                this.Hide();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
