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
using System.Runtime.InteropServices;

namespace TeamProject
{
    public partial class LogIn : Form
    {
       
        DatabaseConnection dbConn = new DatabaseConnection(); //데이터베이스 연결 객체 생성
        ImplementSql impSql = new ImplementSql();  //sql실행 객체 생성

        
        public LogIn()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            dbConn.GetConnection("server=localhost;database=test;uid=root;pwd=jang7856;");
            DatabaseConnection.conn.Open();
            MySqlDataReader myRead;
            string sql = "select id, password from UserInfo where id='" + textBox1.Text + "'";
            impSql.getSql(sql);
            myRead = impSql.cmd.ExecuteReader();
            if (textBox1.Text != "" && textBox2.Text != "")
            { 
                if(myRead.HasRows)
                {
                    if(myRead.Read())
                    {
                        if (myRead["password"].ToString() == textBox2.Text)
                        {
                            MessageBox.Show("Welcome " + myRead["id"]+"!");
                            UserData.Myid = textBox1.Text;
                            this.Close();
                            new Main2().Show();
                        }
                      
                        else
                            MessageBox.Show("Wrong Password");
                    }                   
                }
                else if(textBox1.Text == "admin" && textBox2.Text == "1234")
                {
                    MessageBox.Show("Welcome Admin");
                    myRead.Close();
                    DatabaseConnection.conn.Close();
                    this.Close();
                    new UserMannegement().Show();
                }
                else
                {
                    MessageBox.Show("This Id is not exist");
                }
              
            }
            else
            {
                
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Input your information");
                }
                else if (textBox2.Text != "")
                {
                    MessageBox.Show("Input your Id");
                }
                else
                {
                    MessageBox.Show("Input your password");
                }
            }
                myRead.Close();
                DatabaseConnection.conn.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Join().ShowDialog();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
