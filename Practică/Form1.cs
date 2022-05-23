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

            DataAcces db = new DataAcces();
            label1.Text = "Current session: " + db.GetCurrentSession().First().username;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenedControl = "Main";
            userProfileControl1.Hide();
            main1.Show();
            pictureBox3.Hide();
            pictureBox2.Show();
        }
    }
}