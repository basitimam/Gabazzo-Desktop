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
    public partial class Services : Form
    {
        private string tempId;
        SqlConnection conn;
        public Services()
        {
            InitializeComponent();
            conn = new SqlConnection("Server=tcp:gabazzo-ipt-server.database.windows.net,1433;Initial Catalog=gabazzo-db;Persist Security Info=False;User ID=mugheera;Password=Gabazzo+-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen main = new MainScreen();
            main.Show();
        }

        private void ShowService_Click(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {


            SqlDataAdapter sda = new SqlDataAdapter("select * from ContractorServices", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void AddService_Click(object sender, EventArgs e)
        {

            string ContId;
            if (Email.Text.Length == 0 || Title.Text.Length == 0 || Category.Text.Length == 0 || Service.Text.Length == 0 || PriceFrom.Text.Length == 0 || PriceTo.Text.Length == 0 || EstimatedTime.Text.Length==0 || Description.Text.Length == 0) { 
         
                MessageBox.Show("Input All Fields! ");
            }
            else
            {
                SqlCommand cmd;
                conn.Open();

                string QueryCont = "select ContractorId from RegisteredContractors where Email='"+ Email.Text +"'";

                SqlCommand cmnd = conn.CreateCommand();
                cmnd.CommandText = QueryCont;

                ContId = (string)cmnd.ExecuteScalar();

                if (ContId.Length != 0)
                {
                    MessageBox.Show("Contractor Exists");
                    
                }
                else
                {
                    MessageBox.Show("Contractor doesnot Exists");
                    goto Jump;
                }


                string Query = "INSERT INTO  ContractorServices(ServicesId,ContractorId,Title,Category,Service,PriceFrom,PriceTo,EstimatedTime,Description) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
                cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@p2", ContId);
                cmd.Parameters.AddWithValue("@p3", Title.Text);
                cmd.Parameters.AddWithValue("@p4", Category.Text);
                cmd.Parameters.AddWithValue("@p5", Service.Text);
                cmd.Parameters.AddWithValue("@p6", PriceFrom.Text);
                cmd.Parameters.AddWithValue("@p7", PriceTo.Text);
                cmd.Parameters.AddWithValue("@p8", EstimatedTime.Text);
                cmd.Parameters.AddWithValue("@p9", Description.Text);
                Guid id = Guid.NewGuid();
              

                cmd.Parameters.AddWithValue("@p1", id);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();



                Display();
                MessageBox.Show("Service Inserted Successfully!");
                Jump:
                Clear();

            }
        }
        public void Clear()
        {
            Email.Clear();
            Service.Clear();
            Category.Clear();
            Title.Clear();
            Description.Clear();
            PriceFrom.Clear();
            PriceTo.Clear();
            EstimatedTime.Clear();


        }

        private void Services_Load(object sender, EventArgs e)
        {

        }

        private void DeleteService_Click(object sender, EventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string Query = "DELETE from ContractorServices where ServicesId='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Service Deleted Successfully");
                }
            }
            conn.Close();
        }

        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                tempId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Title.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Category.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Service.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                PriceFrom.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                PriceTo.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                EstimatedTime.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                Description.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();



            }
        }

        private void UpdateService_Click(object sender, EventArgs e)
        {
            if (Title.Text.Length == 0 || Category.Text.Length == 0 || Service.Text.Length == 0 || PriceFrom.Text.Length == 0 || PriceTo.Text.Length == 0 || EstimatedTime.Text.Length == 0 ||Description.Text.Length==0)
            {
                MessageBox.Show("Input All Fields! ");
            }
            else
            {

                if (Email.Text.Length == 0)
                {
                    SqlCommand cmd;
                    conn.Open();
                    string Query = "UPDATE ContractorServices set Title=@p2,Category=@p3,Service=@p4,PriceFrom=@p5,PriceTo=@p7,EstimatedTime=@p8,Description=@p9 where ServicesId='" + tempId + "'";
                    cmd = new SqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@p2", Title.Text);
                    cmd.Parameters.AddWithValue("@p3", Category.Text);
                    cmd.Parameters.AddWithValue("@p4", Service.Text);
                    cmd.Parameters.AddWithValue("@p5", PriceFrom.Text);
                    cmd.Parameters.AddWithValue("@p7", PriceTo.Text);
                    cmd.Parameters.AddWithValue("@p8", EstimatedTime.Text); 
                    cmd.Parameters.AddWithValue("@p9", Description.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Display();
                    MessageBox.Show("Service Updated Successfully!");

                    Clear();
                }
                else
                {
                    SqlCommand cmd;
                    conn.Open();
                    string ContId;
                    string QueryCont = "select ContractorId from RegisteredContractors where Email='" + Email.Text + "'";

                    SqlCommand cmnd = conn.CreateCommand();
                    cmnd.CommandText = QueryCont;

                    ContId = (string)cmnd.ExecuteScalar();

                    if (ContId.Length != 0)
                    {
                        MessageBox.Show("Contractor Exists");

                    }
                    else
                    {
                        MessageBox.Show("Contractor doesnot Exists");
                        goto Jump;
                    }


                    
                    string Query = "UPDATE ContractorServices set ContractorId=@p1,Title=@p2,Category=@p3,Service=@p4,PriceFrom=@p5,PriceTo=@p7,EstimatedTime=@p8,Description=@p9 where ServicesId='" + tempId + "'";
                    cmd = new SqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@p2", Title.Text);
                    cmd.Parameters.AddWithValue("@p3", Category.Text);
                    cmd.Parameters.AddWithValue("@p4", Service.Text);
                    cmd.Parameters.AddWithValue("@p5", PriceFrom.Text);
                    cmd.Parameters.AddWithValue("@p7", PriceTo.Text);
                    cmd.Parameters.AddWithValue("@p8", EstimatedTime.Text);
                    cmd.Parameters.AddWithValue("@p9", Description.Text);

                    cmd.Parameters.AddWithValue("@p1", ContId);






                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Display();
                    MessageBox.Show("Service Updated Successfully!");
                    Jump:

                    Clear();

                }
            }
        }
    }
}
