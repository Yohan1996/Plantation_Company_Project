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
    public partial class Manage_Divisions : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TIJ9VMV\\SQLEXPRESS;Initial Catalog=PC;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public Manage_Divisions()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Divisions", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Divisions(DivisionID ,Division_Name ,TP,TP2)values(@DivisionID,@Division_Name,@TP,@TP2)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@DivisionID", DivisionID.Text);
            cmd.Parameters.AddWithValue("@Division_Name", Division_Name.Text);
            cmd.Parameters.AddWithValue("@TP", TP.Text);
            cmd.Parameters.AddWithValue("@TP2", TP2.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void ClearData()
        {
            DivisionID.Text = "";
            Division_Name.Text = "";
            TP.Text = "";
            TP2.Text = "";
            
            ID = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update Divisions set DivisionID=@DivisionID,Division_Name=@Division_Name, TP=@TP, TP2=@TP2 where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@DivisionID", DivisionID.Text);
            cmd.Parameters.AddWithValue("@Division_Name", Division_Name.Text);
            cmd.Parameters.AddWithValue("@TP", TP.Text);
            cmd.Parameters.AddWithValue("@TP2", TP2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            DisplayData();
            ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            DivisionID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Division_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TP.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TP2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminHome f1 = new AdminHome();
            this.Hide();
            f1.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete Divisions where ID=@ID", con);
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
    }
}
