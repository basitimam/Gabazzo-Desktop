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
    public partial class Contractor : Form
    {
        private string tempId;
        SqlConnection conn;
        public Contractor()
        {
            InitializeComponent();
            conn = new SqlConnection("Server=tcp:gabazzo-ipt-server.database.windows.net,1433;Initial Catalog=gabazzo-db;Persist Security Info=False;User ID=mugheera;Password=Gabazzo+-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        private void DeleteContractor_Click(object sender, EventArgs e)
        {

            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string Query = "DELETE from RegisteredContractors where ContractorId='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Contractor Deleted Successfully");
                }
            }
            conn.Close();
        }

        private void ShowContractor_Click(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {


            SqlDataAdapter sda = new SqlDataAdapter("select * from RegisteredContractors", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AddContractor_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length == 0 || lastName.Text.Length == 0 || UserName.Text.Length == 0 || Email.Text.Length == 0 || Password.Text.Length == 0 || Role.Text.Length == 0 ||Phone.Text.Length==0 ||CompanyName.Text.Length==0 || CompanyAdd.Text.Length==0 || Description.Text.Length==0)
            {
                MessageBox.Show("Input All Fields! ");
            }
            else
            {
                SqlCommand cmd;
                conn.Open();
                string Query = "INSERT INTO RegisteredContractors (ContractorId,FirstName,LastName,UserName,Email,PhoneNumber,Password,CompanyAddress,CompanyName,Description,Role) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
                cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@p2", FirstName.Text);
                cmd.Parameters.AddWithValue("@p3", lastName.Text);
                cmd.Parameters.AddWithValue("@p4", UserName.Text);
                cmd.Parameters.AddWithValue("@p5", Email.Text);
                cmd.Parameters.AddWithValue("@p6", Phone.Text);

                Guid id = Guid.NewGuid();
                var pass = BCrypt.Net.BCrypt.HashPassword(Password.Text);

                cmd.Parameters.AddWithValue("@p1", id);
                cmd.Parameters.AddWithValue("@p7", pass);

                cmd.Parameters.AddWithValue("@p8", CompanyAdd.Text);

                cmd.Parameters.AddWithValue("@p9", CompanyName.Text);
                cmd.Parameters.AddWithValue("@p10", Description.Text);
                cmd.Parameters.AddWithValue("@p11", Role.Text);


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();

                Display();
                MessageBox.Show("Contractor Inserted Successfully!");

                Clear();

            }
        }
        public void Clear()
        {
            FirstName.Clear();
            lastName.Clear();
            UserName.Clear();
            Email.Clear();
            Password.Clear();
            CompanyName.Clear();
            CompanyAdd.Clear();
            Phone.Clear();

            Description.Clear();
            Role.Clear();

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen main = new MainScreen();
            main.Show();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                tempId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FirstName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                lastName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                UserName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Email.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Phone.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                CompanyAdd.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                CompanyName.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                Description.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                Role.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();

            }
        }

        private void UpdateContractor_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length == 0 || lastName.Text.Length == 0 || UserName.Text.Length == 0 || Email.Text.Length == 0 || Role.Text.Length == 0 || Phone.Text.Length==0 || CompanyName.Text.Length==0 || CompanyAdd.Text.Length==0 ||Description.Text.Length==0)
            {
                MessageBox.Show("Input All Fields! ");
            }
            else
            {

                if (Password.Text.Length == 0)
                {
                    SqlCommand cmd;
                    conn.Open();
                    string Query = "UPDATE RegisteredContractors set FirstName=@p2,LastName=@p3,UserName=@p4,Email=@p5,PhoneNumber=@p7,CompanyAddress=@p8,CompanyName=@p9,Description=@p10,Role=@p11 where ContractorId='" + tempId + "'";
                    cmd = new SqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@p2", FirstName.Text);
                    cmd.Parameters.AddWithValue("@p3", lastName.Text);
                    cmd.Parameters.AddWithValue("@p4", UserName.Text);
                    cmd.Parameters.AddWithValue("@p5", Email.Text);
                    cmd.Parameters.AddWithValue("@p7", Phone.Text);
                    cmd.Parameters.AddWithValue("@p8", CompanyAdd.Text);
                    cmd.Parameters.AddWithValue("@p9", CompanyName.Text);
                    cmd.Parameters.AddWithValue("@p10", Description.Text);
                    cmd.Parameters.AddWithValue("@p11", Role.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Display();
                    MessageBox.Show("Contractor Updated Successfully!");

                    Clear();
                }
                else
                {
                    SqlCommand cmd;
                    conn.Open();
                    string Query = "UPDATE RegisteredContractors set FirstName=@p2,LastName=@p3,UserName=@p4,Email=@p5,Password=@p6,PhoneNumber=@p7,CompanyAddress=@p8,CompanyName=@p9,Description=@p10,Role=@p11 where ContractorId='" + tempId + "'";
                    cmd = new SqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@p2", FirstName.Text);
                    cmd.Parameters.AddWithValue("@p3", lastName.Text);
                    cmd.Parameters.AddWithValue("@p4", UserName.Text);
                    cmd.Parameters.AddWithValue("@p5", Email.Text);
                    cmd.Parameters.AddWithValue("@p7", Phone.Text);
                    cmd.Parameters.AddWithValue("@p8", CompanyAdd.Text);
                    cmd.Parameters.AddWithValue("@p9", CompanyName.Text);
                    cmd.Parameters.AddWithValue("@p10", Description.Text);
                    cmd.Parameters.AddWithValue("@p11", Role.Text);
                    var pass = BCrypt.Net.BCrypt.HashPassword(Password.Text);

                    cmd.Parameters.AddWithValue("@p6", pass);


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Display();
                    MessageBox.Show("Contractor Updated Successfully!");

                    Clear();

                }
            }
        }
    }
}
