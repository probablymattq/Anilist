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
    public partial class AnimeInformation : Form
    {
        public AnimeInformation()
        {
            InitializeComponent();
        }

        private void AnimeInformation_Load(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();

            if (Form1.OpenedControl == "Main")
            {
                var id1 = Main.AnimeData.Where(a => a.PictureBoxName == Main.PB).First().ClickedAnimeId;
                var anime = db.GetAnime().Where(a => a.idanime == id1).First();

                label15.Text = anime.numeanime;
                label14.Text = anime.nrepisoade.ToString();
                label13.Text = anime.status;
                label12.Text = anime.dataaparitie.Split(' ')[0].ToString();
                label11.Text = db.GetStudio(anime.idstudio);
                label10.Text = db.GetGen(anime.idgen);
                label9.Text = db.GetSezon(anime.idsezon);

            }
            else if (Form1.OpenedControl == "UserProfile")
            {
                var email = db.GetCurrentSession().First().email;
                var id2 = UserProfileControl.AnimeData2.Where(a => a.PictureBoxName == UserProfileControl.PB2).First().ClickedAnimeId;
                var anime = db.GetAnimePersonal(id2, email).First();
                label15.Text = anime.numeanime;
                label14.Text = anime.nrepisoade.ToString();
                label13.Text = anime.status;
                label12.Text = anime.dataaparitie.Split(' ')[0].ToString();
                label11.Text = db.GetStudio(anime.idstudio);
                label10.Text = db.GetGen(anime.idgen);
                label9.Text = db.GetSezon(anime.idsezon);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
