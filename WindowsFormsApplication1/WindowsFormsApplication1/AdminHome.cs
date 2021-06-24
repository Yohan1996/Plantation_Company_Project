using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Divisions f1 = new Manage_Divisions();
            this.Hide();
            f1.ShowDialog();
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manage_Field f1 = new Manage_Field();
            this.Hide();
            f1.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home f1 = new Home();
            this.Hide();
            f1.ShowDialog();
        }

        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Employee f1 = new Manage_Employee();
            this.Hide();
            f1.ShowDialog();
        }

        private void calculateSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculate_Salary f1 = new Calculate_Salary();
            this.Hide();
            f1.ShowDialog();
        }
    }
}
