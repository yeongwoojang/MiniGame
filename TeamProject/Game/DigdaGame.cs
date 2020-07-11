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
    public partial class DigdaGame : Form
    {
        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성
        Button[,] box = new Button[6,6];
        
        Timer myTimer = new Timer();
        Timer myTimer2 = new Timer();
        Timer myTimer3 = new Timer();



        int row, col, i, j, count, time;
        
        public DigdaGame()
        {
           

            InitializeComponent();
            this.TopMost = true;
            myTimer.Tick += timer1_Tick;
            myTimer2.Tick += timer2_Tick;
            myTimer.Interval = 1300;
                myTimer2.Interval = 800;
            myTimer3.Tick += timer3_Tick;
            myTimer3.Interval = 1000;
            count = 0;
            time = 10;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    
                    box[i, j] = new Button();
                    box[i, j].FlatStyle = FlatStyle.Flat;
                    box[i, j].FlatAppearance.BorderSize = 0;
                    box[i, j].Image = Image.FromFile("두더지.PNG");
                    box[i, j].Location = new Point(i * 60,j * 60);
                    box[i, j].Width = 70;
                    box[i, j].Height = 70;
                    Controls.Add(box[i, j]);
                    box[i, j].Visible = false;
                    box[i, j].Click += Form1_Click;
                    label3.Visible = false;
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (time == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        box[i, j].Enabled = false;
                    }
                }
            }
            else
            {
                count += 10;
                label1.Text = count + "점";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            DatabaseConnection.conn.Open();
            MySqlDataReader myRead;
            string sql = "select catchMole_score from Score where userId='" + UserData.Myid + "'";
            impSql.getSql(sql);

            myRead = impSql.cmd.ExecuteReader();

            if (myRead.HasRows)
            {
                if (myRead.Read())
                {
                    if (Convert.ToInt16(myRead["catchMole_score"]) > count)
                    {
                        MessageBox.Show("이전 기록보다 더 낮습니다.");
                    }
                    else
                    {
                        myRead.Close();
                        sql = "update  Score set catchMole_score = '" + count + "' where userId ='" + UserData.Myid + "'";
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            label2.Text = "Time : " + (--time);
            if (time == 0)
            {
                myTimer3.Stop();
                label3.Visible = true;

            }
            
        }

        bool con = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(time == 0)
            {
                myTimer.Stop();
            }
            Random rando = new Random();
            row = rando.Next(0, 6);
            col = rando.Next(0, 6);
            
            i = row;
            j = col;
            box[row, col].Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                myTimer2.Stop();
            }
            box[i, j].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                button1.Enabled = false;
            if (time == 0)
            {
                label2.Text = "Time : " + (time);

            }
            else
            {

                myTimer.Start();
                myTimer2.Start();
                myTimer3.Start();
            }
        }
    }
}
