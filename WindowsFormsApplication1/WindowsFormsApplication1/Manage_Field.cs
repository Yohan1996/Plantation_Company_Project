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
    public partial class Manage_Field : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TIJ9VMV\\SQLEXPRESS;Initial Catalog=PC;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public Manage_Field()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from ManageFields", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into ManageFields(FieldID ,Field_Name ,Field_Type,Extend)values(@FieldID,@Field_Name,@Field_Type,@Extend)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@FieldID", FieldID.Text);
            cmd.Parameters.AddWithValue("@Field_Name", Field_Name.Text);
            cmd.Parameters.AddWithValue("@Field_Type", Field_Type.Text);
            cmd.Parameters.AddWithValue("@Extend", Extend.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void ClearData()
        {
            FieldID.Text = "";
            Field_Name.Text = "";
            Field_Type.Text = "";
            Extend.Text = "";

            ID = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void FieldID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Field_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update ManageFields set FieldID=@FieldID,Field_Name=@Field_Name, Field_Type=@Field_Type, Extend=@Extend where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@FieldID", FieldID.Text);
            cmd.Parameters.AddWithValue("@Field_Name", Field_Name.Text);
            cmd.Parameters.AddWithValue("@Field_Type", Field_Type.Text);
            cmd.Parameters.AddWithValue("@Extend", Extend.Text);
            

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            DisplayData();
            ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminHome f1 = new AdminHome();
            this.Hide();
            f1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete ManageFields where ID=@ID", con);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            FieldID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Field_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Field_Type.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Extend.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }
    }
}
