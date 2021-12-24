using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gabazzoo
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string admin = "admin";
            SqlConnection conn = new SqlConnection("Server=tcp:gabazzo-ipt-server.database.windows.net,1433;Initial Catalog=gabazzo-db;Persist Security Info=False;User ID=mugheera;Password=Gabazzo+-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from RegisteredUsers where Email='" + Email.Text + "' and Password='" + Password.Text + "' and Role='" + admin +"'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count == 1)
            { 
                 MainScreen main = new MainScreen();
                 main.Show();
                 this.Hide();
                  
             }
            else
            {
                MessageBox.Show("Invalid Email or Password");
            }
                 
                }
            }
        }
    

