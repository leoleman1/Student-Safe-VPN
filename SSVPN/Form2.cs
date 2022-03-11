using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSVPN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isValid()
        {
            if (Username.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Please enter a valid Username", "Error");
                return false;
            } else if (Password.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Please enter a valid Password", "Error");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLOCALDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Login WHERE Username = '" + Username.Text.Trim() +
                        "' AND Password = '" + Password.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();
                    }


                }
            }
        }
    }
}
