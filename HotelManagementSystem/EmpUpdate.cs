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
    public partial class EmpUpdate : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string oldemail = employeesdata.passempemail;

        public EmpUpdate()
        {
            InitializeComponent();
        }

        private void EmpUpdate_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);

            con.Open();
            string query = "select EmpFirstname, EmpLastname, EmpEmail, Gender, EmpPhone from Employee where EmpEmail = '" + oldemail + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtupfirstname.Text = dr[0].ToString();
                txtuplastname.Text = dr[1].ToString();
                txtupemail.Text = dr[2].ToString();
                txtupphone.Text = dr[4].ToString();
                String ggender = dr[3].ToString();
                if (ggender == "Male")
                {
                    txtupgender.SelectedItem = "Male";
                }
                else if (ggender == "Female")
                {
                    txtupgender.SelectedItem = "Female";
                }
                else
                {
                    txtupgender.SelectedItem = "Other";
                }
            }
            con.Close();
        }

        private void btnupsave_Click(object sender, EventArgs e)
        {
            if (txtupfirstname.Text == "" || txtuplastname.Text == "" || txtupemail.Text == "" || txtupgender.SelectedItem == "" || txtupphone.Text == "")
            {
                MessageBox.Show("Please, Enter the values into the fileds.", "Blank Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { 
                con.Open();
                string query = "update Employee set EmpFirstname='" + txtupfirstname.Text + "', EmpLastname='" + txtuplastname.Text + "', EmpEmail='" + txtupemail.Text + "', Gender='" + txtupgender.SelectedItem + "', EmpPhone='" + txtupphone.Text + "' where EmpEmail='" + oldemail + "'";
                cmd = new SqlCommand(query, con);
                int ans = cmd.ExecuteNonQuery();
                if(ans == 1)
                {
                    MessageBox.Show("Employee Records Update SuccessFully!!!", "Update Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    employeesdata ed = new employeesdata();
                    ed.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sorry! Employee Is Not Update Successfully.", "Update Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            employeesdata ed = new employeesdata();
            ed.Show();
            this.Hide();
        }

       
    }
}
