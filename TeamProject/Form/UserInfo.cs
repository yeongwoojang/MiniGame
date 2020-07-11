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
    public partial class UserInfo : Form
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
        public UserInfo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Modify().Show();
           

        }

      

        private void witToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

           

            DialogResult result = MessageBox.Show("Really?", "",MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {

                dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
                string sql = "delete from Score Where userId = '"+UserData.Myid+"'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);

                DataSet ds = new DataSet();
                da.Fill(ds, "Score");
                
                sql = "delete from UserInfo Where Id = '" + UserData.Myid + "'";
                da = new MySqlDataAdapter(sql, DatabaseConnection.conn);
                 ds = new DataSet();
                da.Fill(ds, "Score");
                this.Close();
               // new Main().Show();

            }
        }

        private void Ranking_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            string sql = "select UserId, maze_sec from Score where maze_sec !=0 order By maze_sec ASC;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Score");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Score";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            string sql = "select UserId, catchMole_score from Score where catchMole_score !=0 order By catchMole_score DESC;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Score");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Score";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856");
            string sql = "select UserId, bounceball_score from Score where bounceball_score !=0 order By bounceball_score DESC;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Score");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Score";
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 30, 30));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 30, 30));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 30, 30)); 
           
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
