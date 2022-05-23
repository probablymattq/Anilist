using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practică
{
    public partial class Register : Form
    {

        List<LoginDB> data = new List<LoginDB>();

        public Point mouseLocation;
        public Register()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (customTextBox1.Texts != "" || customTextBox2.Texts != "" || customTextBox3.Texts != "" || customTextBox4.Texts != "")
            {
                var result = MessageBox.Show("Progresul actual va fi pierdut", "Vreti sa continuati?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    timer3.Start();
                }
            }
            else
            {
                timer3.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        String[] validMails = { "@gmail.com", "@mail.ru", "yahoo.com" };

        private void label7_Click(object sender, EventArgs e)
        {

            DataAcces db = new DataAcces();

            if (customTextBox2.BorderColor == Color.Crimson)
            {
                MessageBox.Show("Usernameu' e prea scurt");
            }
            else if (customTextBox1.BorderColor == Color.Crimson)
            {
                MessageBox.Show("Emailu' introdus nu-i valid");
            }
            else if (customTextBox4.BorderColor == Color.Crimson)
            {
                MessageBox.Show("Parolele nu coincid");
            }
            else if (customTextBox3.BorderColor == Color.Crimson)
            {
                MessageBox.Show("Parolă prea slaba");
            }
            else
            {
                db.InsertData(customTextBox2.Texts, customTextBox1.Texts, customTextBox4.Texts);
                customTextBox1.Texts = "";
                customTextBox1.BorderColor = Color.CornflowerBlue;
                customTextBox2.Texts = "";
                customTextBox2.BorderColor = Color.CornflowerBlue;
                customTextBox3.Texts = "";
                customTextBox3.BorderColor = Color.CornflowerBlue;
                customTextBox4.Texts = "";
                customTextBox4.BorderColor = Color.CornflowerBlue;
                MessageBox.Show("Te ai inregistrat cu succes.");

                timer3.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                timer2.Stop();
                Application.Exit();
            }
            Opacity -= .2;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                timer3.Stop();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            Opacity -= .2;
        }

        private void customTextBox3__TextChanged(object sender, EventArgs e)
        {
            switch (customTextBox3.Texts.Length)
            {
                case 1:
                case 7:
                    customTextBox3.BorderColor = Color.Crimson;
                    break;
                case 8:
                case 14:
                    customTextBox3.BorderColor = Color.Yellow;
                    break;
                case 15:
                    customTextBox3.BorderColor = Color.SpringGreen;
                    break;
                case 0:
                    customTextBox3.BorderColor = Color.CornflowerBlue;
                    break;
            }
        }

        private void customTextBox4__TextChanged(object sender, EventArgs e)
        {
            if (customTextBox3.Texts.Length <= 0)
            {
                customTextBox4.BorderColor = Color.CornflowerBlue;
            }
            else
            {

                if (customTextBox4.Texts == customTextBox3.Texts)
                {
                    customTextBox4.BorderColor = customTextBox3.BorderColor;
                }
                else
                {
                    customTextBox4.BorderColor = Color.Crimson;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            if (db.CheckMail(customTextBox1.Texts).Any())
            {
                customTextBox1.BorderColor = Color.Crimson;
            }
            else if (customTextBox1.Texts.Length != 0 && !validMails.Any(s => customTextBox1.Texts.EndsWith(s)))
            {
                customTextBox1.BorderColor = Color.Crimson;
            }
            else
            {
                customTextBox1.BorderColor = Color.SpringGreen;
            }
        }

        private void customTextBox2__TextChanged(object sender, EventArgs e)
        {
            if (customTextBox2.Texts.Length >= 5)
            {
                customTextBox2.BorderColor = Color.SpringGreen;
            }
            else
            {
                customTextBox2.BorderColor = Color.Crimson;
            }
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            Opacity -= 0.3;
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {
            Opacity = 1;
        }

        private void Register_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataAcces db = new DataAcces();

                if (customTextBox2.BorderColor == Color.Crimson)
                {
                    MessageBox.Show("Usernameu' e prea scurt");
                }
                else if (customTextBox1.BorderColor == Color.Crimson)
                {
                    MessageBox.Show("Emailu' introdus nu-i valid");
                }
                else if (customTextBox4.BorderColor == Color.Crimson)
                {
                    MessageBox.Show("Parolele nu coincid");
                }
                else if (customTextBox3.BorderColor == Color.Crimson)
                {
                    MessageBox.Show("Parolă prea slaba");
                }
                else
                {
                    db.InsertData(customTextBox2.Texts, customTextBox1.Texts, customTextBox4.Texts);
                    customTextBox1.Texts = "";
                    customTextBox1.BorderColor = Color.CornflowerBlue;
                    customTextBox2.Texts = "";
                    customTextBox2.BorderColor = Color.CornflowerBlue;
                    customTextBox3.Texts = "";
                    customTextBox3.BorderColor = Color.CornflowerBlue;
                    customTextBox4.Texts = "";
                    customTextBox4.BorderColor = Color.CornflowerBlue;
                    MessageBox.Show("Te ai inregistrat cu succes.");

                    timer3.Start();
                }
            }
        }
    }
}
