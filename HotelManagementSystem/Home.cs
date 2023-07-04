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
    public partial class Home : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string useremail = "";
        string cemail = "";


        public Home()
        {
            InitializeComponent();
        }

        // Form Load
        private void Home_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
            getLoginUsername(Login.passdata);
            getDataHome();
            lblPageTitle.Text = "Home";
        }

        // Login Get Email Address
        private void getLoginUsername(string passdata)
        {
            con.Open();
            useremail = passdata;
            string query = "SELECT EmpFirstname, EmpLastname FROM Employee WHERE EmpEmail = '" + passdata + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblUsername.Text = dr["EmpFirstname"] + dr["EmpLastname"].ToString();
            }
            con.Close();
        }

        // All Text Box Clear
        private void cleardata()
        {
            txtEmpFirstname.Text = "";
            txtEmpLastname.Text = "";
            txtEmpEmail.Text = "";
            txtEmpPhone.Text = "";
            txtEmpCity.Text = "";
            txtEmpGender.SelectedItem = "";
            txtEmpPassword.Text = "";

            txtCustomerFirstname.Text = "";
            txtCustomerLastname.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerCity.Text = "";
            txtCustomerGender.SelectedItem = "";
            txtMembers.Text = "";
            txtChildren.Text = "";
            txtCustomerRoomType.Text = "";
            txtCustomerRoomNumber.Text = "";            
        }


        // ================================================= All Menu Buttons ==================================================
        // Button Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        // Button Home
        private void btnHome_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Home";
            AllPages.SelectTab(0);
            getDataHome();
        }

        // Button Rooms
        private void btnRooms_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Rooms";
            AllPages.SelectTab(1);
        }

        // Button Employee
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Employee";
            AllPages.SelectTab(2);
        }

        // Button Profile
        private void btnProfile_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Profile";
            con.Open();
            string query = "Select * from Employee where EmpEmail = '" + useremail + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtProfileFirstname.Text = dr["EmpFirstname"].ToString();
                txtProfileLastname.Text = dr["EmpLastname"].ToString();
                txtProfileEmail.Text = dr["EmpEmail"].ToString();
                txtProfilePhone.Text = dr["EmpPhone"].ToString();
                txtProfileGender.Text = dr["Gender"].ToString();
            }
            dr.Close();
            con.Close();
            AllPages.SelectTab(3);
        }

        // Button Customer
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Customer";
            AllPages.SelectTab(4);
        }

        // Button Checkout
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Checkout";
            AllPages.SelectTab(5);
        }

        // Button Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult mans = MessageBox.Show("Are your sure this session is logout??", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mans == DialogResult.Yes)
            {
                Login login = new Login();
                this.Hide();
                login.Show();
            }
        }


        // ================================================= Home Page All Process ==================================================
        private void getDataHome()
        {
            con.Open();
            string checkrooms = "select count(RNo) from Rooms";
            cmd = new SqlCommand(checkrooms, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblTotalRooms.Text = dr[0].ToString();
            }
            dr.Close();

            string checkEmployee = "select count(EmpId) from Employee";
            cmd = new SqlCommand(checkEmployee, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblTotalEmployees.Text = dr[0].ToString();
            }
            dr.Close();

            string avaliableroom = "select count(RBookId) from Rooms where RBookid = '0'";
            cmd = new SqlCommand(avaliableroom, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblAvalibleRooms.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }

        // ================================================= Customer All Process ==================================================

        // Customer Tab Get Room Numbers
        private void txtCustomerRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomerRoomNumber.Items.Clear();
            con.Open();
            string query = "Select * from Rooms where RType = '" + txtCustomerRoomType.SelectedItem + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtCustomerRoomNumber.Items.Add(dr["RNo"]);
            }
            con.Close();
        }


        // Customer Data Save Button
        private void btnSaveCustomerDetails_Click(object sender, EventArgs e)
        {
            
            con.Open();

            string query = "Insert into Customer (CFirstname, CLastname, CEmail, CPhone, Gender, CCity, Memeber, Children, CRoomType, CRoomNumber, RStatus, bookdate) " +
                "values(@firstname, @lastname, @email, @phone, @gender, @city, @member, @children, @rtype, @rno, @rstatus, @todaydate)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@firstname", txtCustomerFirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtCustomerLastname.Text);
            cmd.Parameters.AddWithValue("@email", txtCustomerEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtCustomerPhone.Text);
            cmd.Parameters.AddWithValue("@city", txtCustomerCity.Text);
            cmd.Parameters.AddWithValue("@gender", txtCustomerGender.SelectedItem);
            cmd.Parameters.AddWithValue("@member", txtMembers.Text);
            cmd.Parameters.AddWithValue("@children", txtChildren.Text);
            cmd.Parameters.AddWithValue("@rtype", txtCustomerRoomType.Text);
            cmd.Parameters.AddWithValue("@rno", txtCustomerRoomNumber.Text);
            cmd.Parameters.AddWithValue("@rstatus", '0');
            cmd.Parameters.AddWithValue("@todaydate", DateTime.Now.ToString("dd/MM/yyyy"));

            int empres = cmd.ExecuteNonQuery();
            if (empres == 1)
            {
                dr.Close();
                string updateroom = "update Rooms set RBookid = '1' where RNo = '" + txtCustomerRoomNumber.Text + "'";
                cmd = new SqlCommand(updateroom, con);
                int ans = cmd.ExecuteNonQuery();
                if(ans == 1)
                {
                    MessageBox.Show("This Customer Is Create SuccessFully.", "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sorry! This Customer is not create!!", "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sorry! This Customer is not create!!", "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dr.Close();
            con.Close();
            cleardata();
        }

        private void btnCustomerView_Click(object sender, EventArgs e)
        {
            Customerdata cd = new Customerdata();
            cd.Show();
            this.Hide();
        }

        // ================================================= Employee All Process ==================================================

        // Employee Button Save
        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            con.Open();

            string newEmp = "INSERT INTO Employee (EmpFirstname, EmpLastname, EmpEmail, EmpPhone, Gender, EmpCity, EmpPassword) Values (@firstname, @lastname, @email, @phone, @gender, @city, @password)";
            cmd = new SqlCommand(newEmp, con);
            cmd.Parameters.AddWithValue("@firstname", txtEmpFirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtEmpLastname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmpEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtEmpPhone.Text);
            cmd.Parameters.AddWithValue("@gender", txtEmpGender.SelectedItem);
            cmd.Parameters.AddWithValue("@city", txtEmpCity.Text);
            cmd.Parameters.AddWithValue("@password", txtEmpPassword.Text);

            int empres = cmd.ExecuteNonQuery();
            if (empres == 1)
            {
                MessageBox.Show("This Employee Is Create SuccessFully.", "New Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sorry! This Employee is not create!!", "New Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dr.Close();
            con.Close();
            cleardata();
        }



        // ================================================= Rooms All Process ==================================================

        // Room Tab In Get Room Number
        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            txtRoomNumber.Items.Clear();
            string getnumber = "SELECT * FROM Rooms WHERE RType = '" + txtRoomType.SelectedItem + "'";
            cmd = new SqlCommand(getnumber, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtRoomNumber.Items.Add(dr[1]);
            }
            dr.Close();
            con.Close();
        }

        // Search Button
        private void btnRoomSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from Rooms where RType = '"+txtRoomType.SelectedItem+"' and RNo = '"+txtRoomNumber.SelectedItem+"' and RBookid = '1'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Sorry! This Room is not avaliable.", "Check Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("This Room is avaliable.", "Check Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }


        // ================================================= Create New Room Form Open ==================================================
        // New Room Create Button
        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            NewRoom nroom = new NewRoom();
            nroom.ShowDialog();
        }


        // ================================================= Profile Page Process ==================================================
        private void btnProfileEdit_Click(object sender, EventArgs e)
        {
            txtProfileFirstname.Enabled = true;
            txtProfileLastname.Enabled = true;
            txtProfileEmail.Enabled = true;
            txtProfilePhone.Enabled = true;
            txtProfileGender.Enabled = true;
            btnProfileSave.Visible = true;
        }

        private void btnProfileSave_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "update Employee set EmpFirstname = '" + txtProfileFirstname.Text + "', EmpLastname = '" + txtProfileLastname.Text + "', EmpEmail = '" + txtProfileEmail.Text + "', EmpPhone = '" + txtProfilePhone.Text + "', Gender = '" + txtProfileGender.SelectedItem + "' where EmpEmail = '" + txtProfileEmail.Text + "'";
            cmd = new SqlCommand(query, con);
            int empres = cmd.ExecuteNonQuery();
            if (empres == 1)
            {
                MessageBox.Show("Your Profile Is SuccessFully.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sorry! This Profile is not update!!", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dr.Close();
            con.Close();

            txtProfileFirstname.Enabled = false;
            txtProfileLastname.Enabled = false;
            txtProfileEmail.Enabled = false;
            txtProfilePhone.Enabled = false;
            txtProfileGender.Enabled = false;
            btnProfileSave.Visible = false;
        }

        // ================================================= Customer All Process ==================================================
        
        private void txtCheckoutSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from Customer where CEmail = '" + txtCheckoutCheck.Text + "' AND RStatus = '0'";
            cemail = txtCheckoutCheck.Text;
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCheckoutCustomerName.Text = dr["CFirstname"] + dr["CLastname"].ToString();
                txtCheckoutRoomType.Text = dr["cRoomType"].ToString();
                txtCheckoutRoomNumber.Text = dr["CRoomNumber"].ToString();
                txtCheckoutBookingdate.Text = dr["bookdate"].ToString();                
                txtCheckoutCheck.Text = "";
            }
            else
            {
                MessageBox.Show("This Customer is allready checkout.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dr.Close();
            con.Close();
        }

        private void btnEmployeeData_Click(object sender, EventArgs e)
        {
            employeesdata ed = new employeesdata();
            this.Hide();
            ed.Show();
        }

        private void btnCheckoutSave_Click(object sender, EventArgs e)
        {
            con.Open();
            string cbooking = "select * from customer where CEmail = '" + cemail + "' and RStatus = '0' ";
            cmd = new SqlCommand(cbooking, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                string query = "Insert Into Checkout (custname, checkoutdate, price, roomnumber) values(@name, @checkdate, @price, @rno)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtCheckoutCustomerName.Text);
                cmd.Parameters.AddWithValue("@rno", txtCheckoutRoomNumber.Text);
                cmd.Parameters.AddWithValue("@price", txtcheckoutPrice.Text);
                cmd.Parameters.AddWithValue("@checkdate", DateTime.Now.ToString("dd/MM/yyyy"));
                int ans = cmd.ExecuteNonQuery();
                if (ans == 1)
                {
                    string uroom = "update Rooms set RBookid = '0' where RNo = '" + txtCheckoutRoomNumber.Text + "'";
                    cmd = new SqlCommand(uroom, con);
                    int uans = cmd.ExecuteNonQuery();
                    if (uans == 1)
                    {
                        string croom = "update Customer set RStatus = '1' where CEmail = '" + cemail + "'";
                        cmd = new SqlCommand(croom, con);
                        int cans = cmd.ExecuteNonQuery();
                        if (cans == 1)
                        {
                            MessageBox.Show("Customer Checkout SuccessFully.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer Not Checkout SuccessFully.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Customer Not Checkout SuccessFully.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                txtCheckoutRoomNumber.Text = "";
                txtCheckoutRoomType.Text = "";
                txtCheckoutCustomerName.Text = "";
                txtCheckoutBookingdate.Text = "";
                txtcheckoutPrice.Text = "";
            }
            else
            {
                MessageBox.Show("This Customer is allready checkout.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // Checkout All Customer
        private void btnViewCheckCustomer_Click(object sender, EventArgs e)
        {
            checkoutCustomer cc = new checkoutCustomer();
            cc.Show();
            this.Hide();
        }
    }
}
