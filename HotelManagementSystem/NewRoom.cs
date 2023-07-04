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
    public partial class NewRoom : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public NewRoom()
        {
            InitializeComponent();
        }

        // Form Load
        private void NewRoom_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Project\Hotel Management\HotelManagementSystem\HotelManagementSystem\HotelManagementDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }

        // Save Button
        private void btnNewRoomSave_Click(object sender, EventArgs e)
        {
            if(txtNewRoomType.SelectedItem == "" || txtNewRoomNumber.Text == "")
            {
                MessageBox.Show("Please the Value into filed", "Blank Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                string query = "SELECT * FROM Rooms WHERE RNo = '" + txtNewRoomNumber.Text + "' AND RType = '" + txtNewRoomType.SelectedItem + "'";
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Sorry! This Room is allready create!", "Already Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dr.Close();
                    string newroom = "INSERT INTO Rooms(RNo, RType, RBookID, RRemoveID) Values(@rno, @rtype, 0, 0)";
                    cmd = new SqlCommand(newroom, con);
                    cmd.Parameters.AddWithValue("@rno", txtNewRoomNumber.Text);
                    cmd.Parameters.AddWithValue("@rtype", txtNewRoomType.SelectedItem);
                    int ans = cmd.ExecuteNonQuery();
                    if (ans == 1)
                    {
                        MessageBox.Show("Create A New Room", "New Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Not create a new room", "New Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txtNewRoomNumber.Text = "";
                txtNewRoomType.SelectedItem = "";
                con.Close();
            }
        }

        // Close Button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
