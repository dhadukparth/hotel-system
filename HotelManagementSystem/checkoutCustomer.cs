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
    public partial class checkoutCustomer : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataSet ds;
        public checkoutCustomer()
        {
            InitializeComponent();
        }

        private void checkoutCustomer_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
            getdata();
        }

        private void getdata()
        {
            con.Open();
            string query = "select cust.CFirstname as 'Firstname', cust.CLastname as 'Lastname', cust.CEmail as 'Email', cust.CPhone as 'Phone', cust.CCity as 'City', che.price as 'Price', cust.bookdate as 'Booking Date', che.checkoutdate as 'Checkout Date'  from Customer as cust inner join Checkout che on cust.CustID = che.cheid where cust.RStatus=1";
            adp = new SqlDataAdapter(query, con);
            ds = new DataSet();
            adp.Fill(ds);
            displayCheckoutCustomerData.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

    }
}
