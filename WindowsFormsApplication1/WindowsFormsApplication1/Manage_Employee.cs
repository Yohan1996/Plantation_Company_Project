using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Manage_Employee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TIJ9VMV\\SQLEXPRESS;Initial Catalog=PC;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public Manage_Employee()
        {
            InitializeComponent();
            DisplayData();
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Employee", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminHome f1 = new AdminHome();
            this.Hide();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Employee(EmployeeID ,NIC ,EName,Job,Gender,WorkedType,BSal)values(@EmployeeID,@NIC,@EName,@Job,@Gender,@WorkedType,@BSal)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID.Text);
            cmd.Parameters.AddWithValue("@NIC", NIC.Text);
            cmd.Parameters.AddWithValue("@EName", EName.Text);
            cmd.Parameters.AddWithValue("@Job", Job.Text);
            cmd.Parameters.AddWithValue("@Gender", Gender.Text);
            cmd.Parameters.AddWithValue("@WorkedType", WorkedType.Text);
            cmd.Parameters.AddWithValue("@BSal", BSal.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");
        }
        private void ClearData()
        {
            EmployeeID.Text = "";
            NIC.Text = "";
            EName.Text = "";
            Job.Text = "";
            Gender.Text = "";
            WorkedType.Text = "";
            BSal.Text = "";

            ID = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update Employee set EmployeeID=@EmployeeID,NIC=@NIC, EName=@EName, Job=@Job, Gender=@Gender, WorkedType=@WorkedType, BSal=@BSal where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID.Text);
            cmd.Parameters.AddWithValue("@NIC", NIC.Text);
            cmd.Parameters.AddWithValue("@EName", EName.Text);
            cmd.Parameters.AddWithValue("@Job", Job.Text);
            cmd.Parameters.AddWithValue("@Gender", Gender.Text);
            cmd.Parameters.AddWithValue("@WorkedType", WorkedType.Text);
            cmd.Parameters.AddWithValue("@BSal", BSal.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            DisplayData();
            ClearData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            EmployeeID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            NIC.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            EName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Job.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Gender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            WorkedType.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            BSal.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete Employee where ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
