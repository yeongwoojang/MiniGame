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
    public partial class MazeGame : Form
    {
        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성
        public MazeGame()
        {
            InitializeComponent();
            this.TopMost = true;
            MoveToStart();
          

        }
        int flag = 0;
   
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            
            timer1.Enabled = false;
            MessageBox.Show("Congratulation~!");
            
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=cs1234;");
            DatabaseConnection.conn.Open();
            MySqlDataReader myRead;
            string sql = "select maze_sec from Score where userId='" + UserData.Myid + "'";
            impSql.getSql(sql);

            myRead = impSql.cmd.ExecuteReader();

            if (myRead.HasRows)
            {
                if (myRead.Read())
                {
                    if (Convert.ToInt16(myRead["maze_sec"]) < count&& Convert.ToInt16(myRead["maze_sec"])!=0)
                    {
                        MessageBox.Show("이전 기록보다 더 늦습니다.");
                    }
                    else if(Convert.ToInt16(myRead["maze_sec"])==0)
                    {
                       myRead.Close();
                        sql = "update Score set maze_sec = '" + count + "' where userId ='" + UserData.Myid + "'";
                          impSql.getSql(sql);
                         impSql.cmd.ExecuteNonQuery();
                      

                    }
                    else if(Convert.ToInt16(myRead["maze_sec"])> count)
                    {
                        myRead.Close();
                        sql = "update  Score set maze_sec = '" + count + "' where userId ='" + UserData.Myid + "'";
                        impSql.getSql(sql);
                        impSql.cmd.ExecuteNonQuery();
                    }
                }
            }
            myRead.Close();
            dbConn.disPose();
            DatabaseConnection.conn.Close();
            this.Close();
           
        }
        private void MoveToStart()
        {
            Point startingPoint = panel1.Location;
            startingPoint.Offset(10, 10);
            Cursor.Position = PointToScreen(startingPoint);
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if(flag == 0)
            {
                label2.Enabled = true;
                label2.Visible = true;
                flag = 1;
            }
            else
            {
                label2.Enabled = false;
                label2.Visible = false;
                flag = 0;
            }
            label3.Text = count+"초";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                label27.Enabled = true;
                label27.Visible = true;
                flag = 1;
            }
            else
            {
                label27.Enabled = false;
                label27.Visible = false;
                flag = 0;
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label21_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label23_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label19_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label20_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label22_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label29_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label28_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }


        private void label12_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label30_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label31_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label33_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label35_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label36_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label37_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label34_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label40_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label41_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label25_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label24_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label32_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label38_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label45_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label46_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label43_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label42_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label44_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label48_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label39_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label8_MouseEnter_1(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label27_MouseEnter_1(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label49_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label30_MouseEnter_1(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label32_MouseEnter_1(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label4_MouseEnter_1(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label47_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label31_MouseEnter_1(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }
    }
}
