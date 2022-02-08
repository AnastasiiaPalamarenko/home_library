using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string enrolle = txtEnrollement.Text;
            Int64 mobile = Int64.Parse(txtContact.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-QFGQFAA\\SQLEXPRESS01; database= Library; integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into NewUser (uname,enroll,contact) values ('"+name+"', '"+enrolle+"',"+mobile+")";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
