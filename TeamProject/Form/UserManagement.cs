using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class UserMannegement : Form
    {
        public UserMannegement()
        {
            InitializeComponent();
            DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
            ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성
            DataSet ds;
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            string sql = "select *from UserInfo";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);
            ds = new DataSet();
            da.Fill(ds, "UserInfo");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "UserInfo";         
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;


        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {         
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserData.User = textBox1.Text;
            string sql = "select maze_sec,catchMole_score,bounceball_score from Score Where UserId='" + UserData.User + "'";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, DatabaseConnection.conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Score");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "Score";

            groupBox3.Visible = true;
            dataGridView2.Visible = true;
            
        }

        

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
