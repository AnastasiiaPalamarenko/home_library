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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-QFGQFAA\\SQLEXPRESS01; database= Library; integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for ( int i=0; i < Sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            if (txtEnrollement.Text != "")
            {
                String edi = txtEnrollement.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-QFGQFAA\\SQLEXPRESS01; database= Library; integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewUser where enroll = '"+edi+"'  ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                

                if (DS.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    txtName.Clear();
                    txtContact.Clear();
                    MessageBox.Show("Invalid Enrollement NO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                string enroll = txtEnrollement.Text;
                string uname = txtName.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                string bookname = comboBoxBooks.Text;
                string bookIssueDate = dateTimePicker.Text;



                String edi = txtEnrollement.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-QFGQFAA\\SQLEXPRESS01; database= Library; integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into IRBook (us_enroll,us_name,us_contact,book_name,book_issue_date) values ('"+enroll+ "','" + uname + "','" + contact + "','" + bookname + "','" + bookIssueDate + "')     ";
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        private void txrContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEnrollement_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollement.Text == "")
            {
                txtName.Clear();
                txtContact.Clear();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollement.Clear();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
