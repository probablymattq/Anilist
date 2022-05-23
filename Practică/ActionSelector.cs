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
    public partial class ActionSelector : Form
    {
        public ActionSelector()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Form1.OpenedControl == "UserProfile")
            {
                DataAcces db = new DataAcces();
                var email = db.GetCurrentSession().First().email;
                var id2 = UserProfileControl.AnimeData2.Where(a => a.PictureBoxName == UserProfileControl.PB2).First().ClickedAnimeId;

                if (db.GetAnimePersonal(id2, email).Count > 0)
                {
                    AnimeInformation ai = new AnimeInformation();
                    ai.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Acest anime nu face parte din lista dvs. personala");
                    this.Close();
                }
            } else
            {
                AnimeInformation ai = new AnimeInformation();
                ai.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserProfileControl profile = new UserProfileControl();
            DataAcces db = new DataAcces();
            var email = db.GetCurrentSession().First().email;
            var id = Main.AnimeData.Where(a => a.PictureBoxName == Main.PB).First().ClickedAnimeId;
            var anime = db.GetAnime().Where(a => a.idanime == id).First();
            var animeinpersonal = db.GetAnimePersonal(id, email).Count();

            if (animeinpersonal <= 0)
            {
                db.InsertInPersonal(anime.idanime, email, anime.numeanime, anime.nrepisoade, anime.status, anime.dataaparitie, anime.idstudio, anime.idgen, anime.idsezon, anime.animeimage);
                MessageBox.Show("Anime-ul " + anime.numeanime + " a fost adaugat in lista personala");
            }
            else
            {
                MessageBox.Show("Acest anime deja este in lista dvs. personala");
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                timer1.Stop();
                this.Close();
            }
            Opacity -= .2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer2.Stop();
            }
            Opacity += .2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UserProfileControl profile = new UserProfileControl();
            DataAcces db = new DataAcces();
            var email = db.GetCurrentSession().First().email;
            var id = UserProfileControl.AnimeData2.Where(a => a.PictureBoxName == UserProfileControl.PB2).First().ClickedAnimeId;
            var anime = db.GetAnimePersonal(id, email);

            if(anime.Count <= 0)
            {
                MessageBox.Show("Acest anime nu mai face parte din lista dvs. personala");
            } else
            {
                db.RemoveFromPersonal(id);
                MessageBox.Show("Anime-ul " + anime.First().numeanime + " a fost sters din lista dvs. personala.");
            }
            this.Close();
        }

        private void ActionSelector_Load_1(object sender, EventArgs e)
        {
            if (Form1.OpenedControl == "Main")
            {
                pictureBox2.Show();
                pictureBox4.Hide();
            }
            else if (Form1.OpenedControl == "UserProfile")
            {
                pictureBox2.Hide();
                pictureBox4.Show();
            }
        }
    }
}
