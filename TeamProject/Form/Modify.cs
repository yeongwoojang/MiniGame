using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class Modify : Form
    {

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


        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성

        public Modify()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
                string sql = "update UserInfo set password = '" + textBox1.Text + "' Where id = '" + UserData.Myid + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Score");
                MessageBox.Show("Complete!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please input password");
            }
        }

        private void Modify_Load(object sender, EventArgs e)
        {
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 30, 30));

        }
    }
}
