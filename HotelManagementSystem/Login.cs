using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public Login()
        {
            InitializeComponent();
        }

        // Button Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        public static string passdata = "";

        // Login Load
        private void Login_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }

        // Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginEmail.Text == "" || txtLoginPassword.Text == "")
            {
                MessageBox.Show("Please the Value into filed", "Blank Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                string query = "SELECT * FROM Employee WHERE EmpEmail = '" + txtLoginEmail.Text + "' AND EmpPassword = '" + txtLoginPassword.Text +"'";
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    passdata = txtLoginEmail.Text;
                    MessageBox.Show("Login successFully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Home home = new Home();
                    this.Hide();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Please! Check the email and password!", "Not Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
                con.Close();
            }
        }
    }
}
