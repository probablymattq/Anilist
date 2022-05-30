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
    public partial class Cafe : UserControl
    {
        public Cafe()
        {
            InitializeComponent();
        }

        #region ButtonEvents
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.CornflowerBlue;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.CornflowerBlue;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.CornflowerBlue;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = Color.CornflowerBlue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.White;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.CornflowerBlue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.White;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.CornflowerBlue;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.White;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.CornflowerBlue;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {
            customTextBox1.Texts = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        public string felulIntai()
        {
            string felIntai = "";
            if (radioButton1.Checked == true)
            {
                felIntai = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                felIntai = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                felIntai = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                felIntai = radioButton4.Text;
            }
            return felIntai;
        }

        public string felulDoi()
        {
            string felDoi = "";
            if (radioButton8.Checked == true)
            {
                felDoi = radioButton8.Text;
            }
            else if (radioButton7.Checked == true)
            {
                felDoi = radioButton7.Text;
            }
            else if (radioButton6.Checked == true)
            {
                felDoi = radioButton6.Text;
            }
            return felDoi;
        }

        public string desert()
        {
            #region DesertIndividual
            string desertFinal = "";
            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                desertFinal = checkBox1.Text;
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
            {
                desertFinal = checkBox2.Text;
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
            {
                desertFinal = checkBox3.Text;
            }
            #endregion

            #region OptiuniMultiple
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
            {
                desertFinal = checkBox1.Text + " si " + checkBox2.Text;
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
            {
                desertFinal = checkBox1.Text + " si " + checkBox3.Text;
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            {
                desertFinal = checkBox1.Text + ", " + checkBox2.Text + " si " + checkBox3.Text;
            } else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
            {
                desertFinal = checkBox2.Text + " si " + checkBox3.Text;
            }
            #endregion

            return desertFinal;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string line1 = "";
            string line2 = "";
            string line3 = "";

            if (felulDoi() != "")
            {
                line2 = "Felul doi: " + felulDoi();
            }
            
            if (felulIntai() != "")
            {
                line1 = "Felul întâi: " + felulIntai();
            }
           
            if (desert() != "")
            {
                line3 = "Desert: " + desert();
            }

            customTextBox1.Texts = line1 + Environment.NewLine + line2 + Environment.NewLine + line3;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            if (felulIntai() != "" && felulDoi() != "" && desert() != "")
            {
                var email = db.GetCurrentSession().First().email;
                if (db.GetCafeData(email).Count > 0)
                {
                    db.UpdateCafeData(email, felulIntai(), felulDoi(), desert());
                    MessageBox.Show("Date introduse in baza de date");
                    string line1 = "Felul întâi: " + felulIntai();
                    string line2 = "Felul doi: " + felulDoi();
                    string line3 = "Desert: " + desert();
                    customTextBox1.Texts = line1 + Environment.NewLine + line2 + Environment.NewLine + line3;
                }
                else
                {
                    db.InsertCafe(email, felulIntai(), felulDoi(), desert());
                    MessageBox.Show("Date introduse in baza de date");
                    string line1 = "Felul întâi: " + felulIntai();
                    string line2 = "Felul doi: " + felulDoi();
                    string line3 = "Desert: " + desert();
                    customTextBox1.Texts = line1 + Environment.NewLine + line2 + Environment.NewLine + line3;
                }
            }
            else
            {
                MessageBox.Show("Trebuie sa fie selectate toate 3 optiuni (fel intai, doi si desert)");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            var email = db.GetCurrentSession().First().email;
            if (db.GetCafeData(email).Count > 0)
            {
                db.DeleteCafeData(email);
                MessageBox.Show("Comanda dvs a fost stearsa din baza de date");
                customTextBox1.Texts = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;

            } else
            {
                MessageBox.Show("In baza de date nu este prezenta o comanda a dvs");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            var email = db.GetCurrentSession().First().email;
            if (db.GetCafeData(email).Count > 0)
            {
                db.UpdateCafeData(email, felulIntai(), felulDoi(), desert());
                MessageBox.Show("Comanda dvs a fost modificata");
                string line1 = "Felul întâi: " + felulIntai();
                string line2 = "Felul doi: " + felulDoi();
                string line3 = "Desert: " + desert();
                customTextBox1.Texts = line1 + Environment.NewLine + line2 + Environment.NewLine + line3;
            } else
            {
                MessageBox.Show("In baza de date nu este prezenta o comanda a dvs");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            var email = db.GetCurrentSession().First().email;
            var cafeData = db.GetCafeData(email).First();
            if (db.GetCafeData(email).Count > 0)
            {

                MessageBox.Show("Comanda dvs din baza de date: " + Environment.NewLine + Environment.NewLine + "Felul intai: " + cafeData.felulintai
                    + Environment.NewLine + "Felul doi: " + cafeData.feluldoi + Environment.NewLine + "Desert: " + cafeData.desert);
            } else
            {
                MessageBox.Show("In baza de date nu este prezenta o comanda a dvs");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
