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
    public partial class Users : Form
    {
        private string tempId;
        SqlConnection conn;
        public Users()
        {
            InitializeComponent();
            conn = new SqlConnection("Server=tcp:gabazzo-ipt-server.database.windows.net,1433;Initial Catalog=gabazzo-db;Persist Security Info=False;User ID=mugheera;Password=Gabazzo+-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

        private void ShowData_Click(object sender, EventArgs e)
        {
            Display();
        }


        public void Display()
        {


            SqlDataAdapter sda = new SqlDataAdapter("select * from RegisteredUsers", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void InsertData_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length == 0 || LastName.Text.Length == 0 || UserName.Text.Length == 0 || Email.Text.Length == 0 || Password.Text.Length == 0 || Role.Text.Length == 0)
            {
                MessageBox.Show("Input All Fields! ");
            }
            else
            {
                SqlCommand cmd;
                conn.Open();
                string Query = "INSERT INTO RegisteredUsers (UserId,FirstName,LastName,UserName,Email,Password,Role) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
                cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@p2", FirstName.Text);
                cmd.Parameters.AddWithValue("@p3", LastName.Text);
                cmd.Parameters.AddWithValue("@p4", UserName.Text);
                cmd.Parameters.AddWithValue("@p5", Email.Text);
                cmd.Parameters.AddWithValue("@p7", Role.Text);

                Guid id = Guid.NewGuid();
                var pass = BCrypt.Net.BCrypt.HashPassword(Password.Text);

                cmd.Parameters.AddWithValue("@p1", id);
                cmd.Parameters.AddWithValue("@p6", pass);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();

                Display();
                MessageBox.Show("User Inserted Successfully!");

                Clear();

            }
        }
        public void Clear()
        {
            FirstName.Clear();
            LastName.Clear();
            UserName.Clear();
            Email.Clear();
            Password.Clear();
            Role.Clear();

        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string Query = "DELETE from RegisteredUsers where UserId='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("User Deleted Successfully");
                }
            }
            conn.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                tempId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FirstName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                LastName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                UserName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Email.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Role.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();



            }
        }

        private void UpdateData_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length == 0 || LastName.Text.Length == 0 || UserName.Text.Length == 0 || Email.Text.Length == 0 || Role.Text.Length == 0)
            {
                MessageBox.Show("Input All Fields! ");
            }
            else
            {

                if (Password.Text.Length == 0)
                {
                    SqlCommand cmd;
                    conn.Open();
                    string Query = "UPDATE RegisteredUsers set FirstName=@p2,LastName=@p3,UserName=@p4,Email=@p5,Role=@p7 where UserId='" + tempId + "'";
                    cmd = new SqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@p2", FirstName.Text);
                    cmd.Parameters.AddWithValue("@p3", LastName.Text);
                    cmd.Parameters.AddWithValue("@p4", UserName.Text);
                    cmd.Parameters.AddWithValue("@p5", Email.Text);
                    cmd.Parameters.AddWithValue("@p7", Role.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Display();
                    MessageBox.Show("User Updated Successfully!");

                    Clear();
                }
                else
                {
                    SqlCommand cmd;
                    conn.Open();
                    string Query = "UPDATE RegisteredUsers set FirstName=@p2,LastName=@p3,UserName=@p4,Email=@p5,Password=@p6,Role=@p7 where UserId='" + tempId + "'";
                    cmd = new SqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@p2", FirstName.Text);
                    cmd.Parameters.AddWithValue("@p3", LastName.Text);
                    cmd.Parameters.AddWithValue("@p4", UserName.Text);
                    cmd.Parameters.AddWithValue("@p5", Email.Text);
                    cmd.Parameters.AddWithValue("@p7", Role.Text);
                    var pass = BCrypt.Net.BCrypt.HashPassword(Password.Text);

                    cmd.Parameters.AddWithValue("@p6", pass);


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Display();
                    MessageBox.Show("User Updated Successfully!");

                    Clear();

                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen main = new MainScreen();
            main.Show();
        }
    }
}
