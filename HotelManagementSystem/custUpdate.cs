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
    public partial class custUpdate : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        string oldemail = Customerdata.passcustemail;

        public custUpdate()
        {
            InitializeComponent();
        }

        private void custUpdate_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);

            con.Open();
            string query = "select CFirstname, CLastname, CEmail, CPhone, Gender, CCity, Memeber, CRoomNumber from Customer where CEmail='" + oldemail + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtupcfirstname.Text = dr[0].ToString();
                txtupclastname.Text = dr[1].ToString();
                txtupcemail.Text = dr[2].ToString();
                txtupcphone.Text = dr[3].ToString();
                txtupccity.Text = dr[5].ToString();
                txtupcmember.Text = dr[6].ToString();
                txtupcroomno.Text = dr[7].ToString();

                string ggender = dr[4].ToString();
                if(ggender == "Male")
                {
                    txtupcgender.SelectedItem = "Male";
                }
                else if(ggender == "Female")
                {
                    txtupcgender.SelectedItem = "Female";
                }
                else
                {
                    txtupcgender.SelectedItem = "Other";
                }
            }
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Customerdata cd = new Customerdata();
            cd.Show();
            this.Hide();
        }

        private void btnupcsave_Click(object sender, EventArgs e)
        {
            if(txtupcfirstname.Text == "" || txtupclastname.Text == "" || txtupcemail.Text == "" || txtupcphone.Text == "" || txtupcgender.SelectedItem == null || txtupcmember.Text == "" || txtupcroomno.Text == "" || txtupccity.Text == "")
            {
                MessageBox.Show("Please, Enter the values into the fileds.", "Blank Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                string query = "update Customer set CFirstname='" + txtupcfirstname.Text + "', CLastname='" + txtupclastname.Text + "', CEmail='" + txtupcemail.Text + "', CPhone='" + txtupcphone.Text + "', Gender='" + txtupcgender.SelectedItem + "', CCity='" + txtupcphone.Text + "', CRoomNumber='" + txtupcroomno.Text + "', Memeber='" + txtupcmember.Text + "' where CEmail='" + oldemail + "'";
                cmd = new SqlCommand(query, con);
                int ans = cmd.ExecuteNonQuery();
                if (ans == 1)
                {
                    MessageBox.Show("Customer Records Update SuccessFully!!!", "Update Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Customerdata cd = new Customerdata();
                    cd.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sorry! Customer Is Not Update Successfully.", "Update Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
    }
}
