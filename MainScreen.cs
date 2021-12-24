using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gabazzoo
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
            this.Hide();

        }

        private void ContractorButton_Click(object sender, EventArgs e)
        {
            Contractor contractor = new Contractor();
            contractor.Show();
            this.Hide();
        }

        private void ViewServices_Click(object sender, EventArgs e)
        {
            Services service = new Services();
            service.Show();
            this.Hide();
        }
    }
}
