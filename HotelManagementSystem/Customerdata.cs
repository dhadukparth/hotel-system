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
    public partial class Customerdata : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataSet ds;

        public Customerdata()
        {
            InitializeComponent();
        }

        public static string passcustemail = "";

        private void Customerdata_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
            getdata();
        }

        private void getdata()
        {
            con.Open();
            string query = "SELECT CFirstname as Firstname, CLastname as Lastname, CEmail as Email, CPhone as Phone, bookdate as 'Book Date', Gender, CCity as City, Memeber, Children, CRoomNumber as 'Room Number' FROM Customer WHERE RStatus = '0'";
            adp = new SqlDataAdapter(query, con);
            ds = new DataSet();
            adp.Fill(ds);
            displayCustomerData.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        

        private void displayCustomerData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gcemail = displayCustomerData.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                passcustemail = gcemail;
                custUpdate cu = new custUpdate();
                cu.Show();
                this.Hide();
            }
            else if(e.ColumnIndex == 1)
            {
                DialogResult = MessageBox.Show("Are you sure this record is delete?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(DialogResult == DialogResult.Yes)
                {
                    con.Open();
                    string query = "DELETE FROM Customer WHERE CEmail = '" + gcemail +"'";
                    cmd = new SqlCommand(query, con);
                    int ans = cmd.ExecuteNonQuery();
                    if(ans == 1)
                    {
                        MessageBox.Show("This Record is delete successFully", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sorry! This record is not delete?", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    getdata();
                }
            }
        }
    }
}
