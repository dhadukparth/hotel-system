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
    public partial class employeesdata : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataSet ds;

        public employeesdata()
        {
            InitializeComponent();
        }

        public static string passempemail = "";

        private void employeesdata_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
            getdata();
        }

        private void getdata()
        {
            con.Open();
            string query = "SELECT EmpFirstname as Firstname, EmpLastname as Lastname, EmpEmail as Email, EmpPhone as Phone, Gender, EmpCity as City FROM Employee";
            adp = new SqlDataAdapter(query, con);
            ds = new DataSet();
            adp.Fill(ds);
            displayEmployeeData.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        
        private void displayEmployeeData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gempemail = displayEmployeeData.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                passempemail = gempemail;
                EmpUpdate eu = new EmpUpdate();
                this.Hide();
                eu.Show();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult = MessageBox.Show("Are you sure this record is delete?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    con.Open();
                    string query = "DELETE FROM Employee WHERE EmpEmail = '" + gempemail + "'";
                    cmd = new SqlCommand(query, con);
                    int ans = cmd.ExecuteNonQuery();
                    if (ans == 1)
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
