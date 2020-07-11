using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TeamProject
{
    public partial class Main : Form
    {
        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                 int nTop,
                 int nRight,
                 int nBottotm,
                 int nWidthEllipse,
                 int nHeightEllipse

            );

        int color = 1;
        Random rando = new Random();


        public Main()
        {
           
            InitializeComponent();
            



            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            SoundPlayer simpleSound = new SoundPlayer(@"챌린저.wav");
            simpleSound.PlayLooping();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LogIn().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please LogIn");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please LogIn");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please LogIn");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            switch (color)
            {
                case 1:
                    {
                        label1.ForeColor = Color.Red;
                        label2.ForeColor = Color.Red;
                        break;
                    }
                case 2:
                    {
                        label1.ForeColor = Color.Blue;
                        label2.ForeColor = Color.Blue;
                        break;
                    }
                case 3:
                    {
                        label1.ForeColor= Color.Yellow;
                        label2.ForeColor = Color.Yellow;
                        break;
                    }
                case 4:
                    {
                        label1.ForeColor = Color.Violet;
                        label2.ForeColor = Color.Violet;
                        break;
                    }
                case 5:
                    {
                        label1.ForeColor = Color.SteelBlue;
                        label2.ForeColor = Color.SteelBlue;
                        break;
                    }
                case 6:
                    {
                        label1.ForeColor = Color.Green;
                        label2.ForeColor = Color.Green;
                        break;
                    }
                case 7:
                    {
                        label1.ForeColor = Color.Gold;
                        label2.ForeColor = Color.Gold;
                        break;
                    }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            color = rando.Next(1,7);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 30, 30));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 30, 30));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 30, 30));
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
