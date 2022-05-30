using Ganss.Excel;

namespace Practică
{
    public partial class Form1 : Form
    {

        public Point mouseLocation;
        public static String OpenedControl = "Main";
        public Form1()
        {
            InitializeComponent();
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

        private void label5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            Opacity -= 0.3;
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            ActionSelector action = new ActionSelector();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenedControl = "UserProfile";
            userProfileControl1.Show();
            cafe1.Hide();
            main1.Hide();
            pictureBox2.Hide();
            pictureBox3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            main1.Show();
            userProfileControl1.Hide();
            pictureBox3.Hide();
            pictureBox2.Show();
            cafe1.Hide();

            DataAcces db = new DataAcces();
            label1.Text = "Current session: " + db.GetCurrentSession().First().username;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenedControl = "Main";
            userProfileControl1.Hide();
            cafe1.Hide();
            main1.Show();
            pictureBox3.Hide();
            pictureBox2.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DataAcces db = new DataAcces();
            List<ExportData> animeListPublic = new List<ExportData>();
            List<ExportData> animeListPersonal = new List<ExportData>();
            List<CafeData> cafeDataExport = new List<CafeData>();


            if (OpenedControl == "Main")
            {
                var result = MessageBox.Show("Doriti sa exportati lista publica?", "Export in Excel", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    db.GetAnime().ForEach(a =>
                    {
                        animeListPublic.Add(new ExportData
                        {
                            idanime = a.idanime,
                            numeanime = a.numeanime,
                            nrepisoade = a.nrepisoade,
                            status = a.status,
                            dataaparitie = a.dataaparitie.Split(' ')[0].ToString(),
                            studio = db.GetStudio(a.idstudio),
                            gen = db.GetGen(a.idgen),
                            sezon = db.GetSezon(a.idsezon)
                        }); 
                    });
                    ExcelMapper mapper = new ExcelMapper();
                    var newFile = @"..\..\..\..\ExportPublic.xlsx";
                    mapper.Save(newFile, animeListPublic, "Sheet", true);
                    MessageBox.Show("Lista publica a fost exportata in fisier excel");

                }

            }
            else if (OpenedControl == "UserProfile")
            {
                var result = MessageBox.Show("Doriti sa exportati lista personala?", "Export in Excel", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    var email = db.GetCurrentSession().First().email;
                    db.GetAnimePersonal2(email).ForEach(a =>
                    {
                        animeListPersonal.Add(new ExportData
                        {
                            idanime = a.idanime,
                            numeanime = a.numeanime,
                            nrepisoade = a.nrepisoade,
                            status = a.status,
                            dataaparitie = a.dataaparitie.Split(' ')[0].ToString(),
                            studio = db.GetStudio(a.idstudio),
                            gen = db.GetGen(a.idgen),
                            sezon = db.GetSezon(a.idsezon)
                        });
                    });

                    ExcelMapper mapper = new ExcelMapper();
                    var newFile = @"..\..\..\..\ExportPersonal.xlsx";
                    mapper.Save(newFile, animeListPersonal, "Sheet", true);
                    MessageBox.Show("Lista personala a fost exportata in fisier excel");
                }
            }
            else if (OpenedControl == "Cafe")
            {
                var result = MessageBox.Show("Doriti sa exportati datele personale din cafenea?", "Export in Excel", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var email = db.GetCurrentSession().First().email;
                    db.GetCafeData(email).ForEach(a =>
                    {
                        cafeDataExport.Add(new CafeData
                        {
                            email = a.email,
                            felulintai = a.felulintai,
                            feluldoi = a.feluldoi,
                            desert = a.desert,
                        });
                    });

                    ExcelMapper mapper = new ExcelMapper();
                    var newFile = @"..\..\..\..\ExportCafe.xlsx";
                    mapper.Save(newFile, cafeDataExport, "Sheet", true);
                    MessageBox.Show("Datele personale din cafenea au fost exportate in fisier excel");
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenedControl = "Cafe";
            cafe1.Show();
            userProfileControl1.Hide();
        }
    }
}