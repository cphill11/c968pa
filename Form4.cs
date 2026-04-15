using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c968pa
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Search text field used.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ID text field used.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Name text field used.");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Inventory text field used.");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Price text field used.");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Max text field used.");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Min text field used.");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add button clicked.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save button clicked.");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete button clicked.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel button clicked.");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search button clicked.");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("All parts data grid interacted with.");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Parts associated data grid interacted with.");
        }
    }
}
