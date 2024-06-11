using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }
       private void LoadEmployees()
        {
            string query = "SELECT * FROM GHX_EMPLOYEESINFO";
            DataTable dataTable = new DataTable() ;
            dataGridViewEmployees.DataSource = dataTable;
        }
 

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10.9.176.202;Initial Catalog=NORTHWND;User ID=NORTHWND;Password=133tcru@NOS");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO GHX_EMPLOYEESINFO VALUES (@EmployeeID, @EmpName, @Department, @Designation)", conn);
            cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(txtEmployeeID.Text));
            cmd.Parameters.AddWithValue("@EmpName", txtName.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully Added");
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=10.9.176.202;Initial Catalog=NORTHWND;User ID=NORTHWND;Password=133tcru@NOS");
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE GHX_EMPLOYEESINFO SET EmpName = @EmpName, Department = @Department, Designation = @Designation WHERE EmployeeID = @EmployeeID", conn);
            cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(txtEmployeeID.Text));
            cmd.Parameters.AddWithValue("@EmpName", txtName.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Updated Successfully");
         
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=10.9.176.202;Initial Catalog=NORTHWND;User ID=NORTHWND;Password=133tcru@NOS");
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE GHX_EMPLOYEESINFO WHERE EmployeeID = @EmployeeID", conn);
            cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(txtEmployeeID.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Deleted Successfully");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=10.9.176.202;Initial Catalog=NORTHWND;User ID=NORTHWND;Password=133tcru@NOS");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM GHX_EMPLOYEESINFO", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewEmployees.DataSource = dt;
        }

        private void ClearFields()
        {
            txtEmployeeID.Clear();
            txtName.Clear();
            txtDepartment.Clear();
            txtDesignation.Clear();
        }

        private void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewEmployees.Rows[e.RowIndex];
                txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtName.Text = row.Cells["EmpName"].Value.ToString();
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                txtDesignation.Text = row.Cells["Designation"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
