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
    public partial class Join : Form

    {
        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성
        
        public Join()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
        private bool isChecked = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isChecked)
            {
                MessageBox.Show("Check your ID");

            }
            else
            {
                dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
                DatabaseConnection.conn.Open();
                MySqlDataReader myRead;
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Fill All Items!");
                }
                else if (textBox2.Text == "admin")
                {
                    MessageBox.Show("Unusable Id");
                }
                else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    string sql = "select id from UserInfo where id='" + textBox2.Text + "'";
                    impSql.getSql(sql);

                    myRead = impSql.cmd.ExecuteReader();
                    if (myRead.HasRows)  //하나 이상의 행이 있는지
                    {
                        if (myRead.Read())  //다음레코드를 이동해서 데이터가 있으면 true, 없으면 false  
                        {
                            if (myRead["id"].ToString() == textBox2.Text)
                            {
                                MessageBox.Show("Already Exist");
                            }
                        }
                        myRead.Close();
                    }

                    else
                    {
                        impSql.getSql("insert into UserInfo(name,id,password) values " +
                        "('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "')");
                        myRead.Close();
                        impSql.cmd.ExecuteNonQuery();

                        sql = "INSERT INTO Score(userId)Values" + "('" + textBox2.Text + "')";

                        impSql.getSql(sql);
                        impSql.cmd.ExecuteNonQuery();
                        MessageBox.Show("Success!");


                    }
                }

                dbConn.disPose(); //데이터베이스 연결 해제
                DatabaseConnection.conn.Close(); //데이터베이스 닫음
                this.Close();
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            DatabaseConnection.conn.Open();
            string sql = "select id from UserInfo where id='" + textBox2.Text + "'";
            impSql.getSql(sql);

            MySqlDataReader myRead = impSql.cmd.ExecuteReader();
            if (textBox2.Text == "")
            {
                MessageBox.Show("Fill ID");
            }
            else if(textBox2.Text == "admin")
            {
                MessageBox.Show("Unusable Id");
            }
            else
            {
                if (myRead.HasRows)
                {
                    if (myRead.Read())
                    {
                        if (myRead["id"].ToString() == textBox2.Text)
                        {
                            MessageBox.Show("Already Exist");
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("Available ID");
                }
            }
            myRead.Close();
            DatabaseConnection.conn.Close();
            dbConn.disPose(); //데이터베이스 연결 해제
            DatabaseConnection.conn.Close(); //데이터베이스 닫음 
            isChecked = true;
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eXITToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

