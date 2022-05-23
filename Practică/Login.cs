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
    public partial class Login : Form
    {

        public Point mouseLocation;

        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
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
                Register register = new Register();
                register.Show();
            }
            Opacity -= .2;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                timer4.Stop();
                this.Hide();
                Form1 main = new Form1();
                main.Show();
            }
            Opacity -= .2;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            if (db.GetLoginData(customTextBox1.Texts, customTextBox2.Texts) == "invalid")
            {
                MessageBox.Show("Datele de logare sunt incorecte");
            }
            else
            {
                MessageBox.Show("Te-ai logat cu succes");
                timer4.Start();

                db.SetCurrentSession(customTextBox1.Texts, db.GetLoginData(customTextBox1.Texts, customTextBox2.Texts));
            };
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

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataAcces db = new DataAcces();
                if (db.GetLoginData(customTextBox1.Texts, customTextBox2.Texts) == "invalid")
                {
                }
                else
                {
                    MessageBox.Show("Te-ai logat cu succes");
                    timer4.Start();

                    db.SetCurrentSession(customTextBox1.Texts, db.GetLoginData(customTextBox1.Texts, customTextBox2.Texts));
                };
            }
        }
    }
}
