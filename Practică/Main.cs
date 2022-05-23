using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Drawing;


namespace Practică
{
    public partial class Main : UserControl
    {
        public static List<AnimeDataAcces> AnimeData = new List<AnimeDataAcces>();
        public static String PB;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            int i = 1, k = 0;

            for (int m = 0; m < Controls.Count; m++)
            {
                if (Controls[m].GetType().ToString() == "System.Windows.Forms.Label")
                {
                    k++;
                }
            }

            for (int j = 0; j < Controls.Count; j++)
            {
                if (Controls[j].GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    PictureBox c = (PictureBox)Controls[j];
                    String image = db.GetAnime().Where(id => id.idanime == i).First().animeimage;
                    String namepb = Controls[j].Name.ToString();

                    AnimeData.Add(new AnimeDataAcces { PictureBoxName = namepb, ClickedAnimeId = i });
                    c.ImageLocation = image;
                    c.SizeMode = PictureBoxSizeMode.StretchImage;
                    c.LoadAsync();
                    i++;

                    Controls[j].Click += new EventHandler(ShowActionSelector);

                }
                else if (Controls[j].GetType().ToString() == "System.Windows.Forms.Label")
                {
                    Label c = (Label)Controls[j];
                    String name = db.GetAnime().Where(id => id.idanime == k).First().numeanime;
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
                    k--;
                }
            }
        }

        private void ShowActionSelector(object sender, EventArgs e)
        {
            ActionSelector action = new ActionSelector();
            Control clickedControl = (Control)sender;
            PB = clickedControl.Name;
            action.StartPosition = FormStartPosition.Manual;
            var locationOnForm = this.PointToScreen(new Point(this.Location.X - 24 - action.Width, this.Location.Y - 43));
            action.Location = locationOnForm;
            action.ShowDialog();
        }
    }
}
