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
    public partial class ballGame : Form
    {
        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성
        public int speed_left = 4;
        public int speed_top = 4;
        public int point = 0;
        int x = 239;
        public ballGame()
        {
           

            InitializeComponent();
            this.TopMost = true;
            timer1.Enabled = true;
            Cursor.Hide();

         
            button1.Visible = false;
            label3.Visible = false;
            raket.Top = playground.Bottom - (playground.Bottom / 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            raket.Left = Cursor.Position.X - (raket.Width / 2);
            ball.Left += speed_left; //move the ball
            ball.Top += speed_top;

            if(ball.Bottom>= raket.Top && ball.Bottom <= raket.Bottom && ball.Left >= raket.Left && ball.Right <= raket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                Size size = raket.Size;
                size.Width-=10;
                raket.Size = size;
                point += 10;
                label1.Text = "Score : " + point;
            }
            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top<=playground.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                button1.Visible = true;
                Cursor.Show();
                label3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
              
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            DatabaseConnection.conn.Open();
            MySqlDataReader myRead;
            string sql = "select bounceball_score from Score where userId='" + UserData.Myid + "'";
            impSql.getSql(sql);

            myRead = impSql.cmd.ExecuteReader();
          
            if (myRead.HasRows)
            {
                if (myRead.Read())
                {
                    if (Convert.ToInt16(myRead["bounceball_score"]) >point)
                    {
                        MessageBox.Show("이전 기록보다 더 낮습니다.");
                    }                  
                    else if(Convert.ToInt16(myRead["bounceball_score"]) < point)
                    {
                        myRead.Close();
                        sql = "update  Score set bounceball_score = '" + point + "' where userId ='" + UserData.Myid + "'";
                        impSql.getSql(sql);
                        impSql.cmd.ExecuteNonQuery();
                    }                  
                }  
            }
            myRead.Close();
            dbConn.disPose();
            DatabaseConnection.conn.Close();      
            Close();
        }
    }
}
