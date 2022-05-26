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
    public partial class UserProfileControl : UserControl
    {
        public static List<AnimeDataAcces> AnimeData2 = new List<AnimeDataAcces>();
        public static String PB2;
        public UserProfileControl()
        {
            InitializeComponent();
        }

        private void UserProfileControl_Load(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            String email = db.GetCurrentSession().First().email;

            if (db.GetAnimePersonal2(email).Count() <= 0)
            {
                label1.Show();
            }
            else
            {
                for (int j = 0; j < db.GetAnimePersonal2(email).Count() * 2; j++)
                {
                    if (Controls[j].GetType().ToString() == "System.Windows.Forms.PictureBox")
                    {
                        PictureBox c = (PictureBox)Controls[j];
                        String image = db.GetAnimePersonal2(email)[j / 2].animeimage;
                        String namepb = Controls[j].Name.ToString();

                        AnimeData2.Add(new AnimeDataAcces { PictureBoxName = namepb, ClickedAnimeId = db.GetAnimePersonal2(email)[j / 2].idanime });
                        c.ImageLocation = image;
                        c.SizeMode = PictureBoxSizeMode.StretchImage;
                        c.LoadAsync();
                        Controls[j].Visible = true;

                        Controls[j].Click += new EventHandler(ShowActionSelector);

                    }
                    else if (Controls[j].GetType().ToString() == "System.Windows.Forms.Label")
                    {

                        Label c = (Label)Controls[j];
                        String name = db.GetAnimePersonal2(email)[j / 2].numeanime;

                        String finalname = "";

                        if (name.Length > 18)
                        {
                            finalname = name.Substring(0, 18) + "\n" + name.Substring(name.Length - (name.Length - 18));
                        }
                        else
                        {
                            finalname = name;
                        }

                        c.Text = finalname;
                        Controls[j].Visible = true;
                    }
                }
            }
        }


        private void ShowActionSelector(object sender, EventArgs e)
        {
            ActionSelector action = new ActionSelector();
            Control clickedControl = (Control)sender;
            PB2 = clickedControl.Name;
            action.StartPosition = FormStartPosition.Manual;
            var locationOnForm = this.PointToScreen(new Point(this.Location.X - 24 - action.Width, this.Location.Y - 43));
            action.Location = locationOnForm;
            action.ShowDialog();

        }
    }
}
