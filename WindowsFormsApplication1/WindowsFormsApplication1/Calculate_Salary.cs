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
    public partial class Calculate_Salary : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TIJ9VMV\\SQLEXPRESS;Initial Catalog=PC;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;
         
       
        public Calculate_Salary()
        {
            InitializeComponent();
            Displayvalue();
            DisplayData();
           
            
        }
        public void Displayvalue()
        {

            con.Open();
            adpt = new SqlDataAdapter("select * from Employee", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            AdminHome f1 = new AdminHome();
            this.Hide();
            f1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchData(EmployeeID.Text);
        }

        public void SearchData(string search)
        {

            con.Open();
            string query = "select * from Employee where EmployeeID like'%" + search + "%'";
            adpt = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Double BasicSal = Convert.ToDouble(BSal.Text);
            Double Allow = Convert.ToDouble(Allowance.Text);
            Double Day = Convert.ToInt32(Days.Text);

            Double Net = Allow * Day + BasicSal;
            NetSalary.Text = Net.ToString();
        }
        private void ClearData()
        {
            EmployeeID.Text = "";
            PaymentID.Text = "";
            BSal.Text = "";
            Allowance.Text = "";
            Days.Text = "";
            NetSalary.Text = "";
            

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter("select * from Salary", con);
            adpt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Salary(EmployeeID,PaymentID,BSal,Allowance,Days,NetSalary)values(@EmployeeID,@PaymentID,@BSal,@Allowance,@Days,@NetSalary)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID.Text);
            cmd.Parameters.AddWithValue("@PaymentID", PaymentID.Text);
            cmd.Parameters.AddWithValue("@BSal", BSal.Text);
            cmd.Parameters.AddWithValue("@Allowance", Allowance.Text);
            cmd.Parameters.AddWithValue("@Days", Days.Text);
            cmd.Parameters.AddWithValue("@NetSalary", NetSalary.Text);
            

            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            EmployeeID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            PaymentID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            BSal.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Allowance.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Days.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            NetSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }
    }
}
