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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Search text field interacted with.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ID text field interacted with.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Name text field interacted with.");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Inventory text field interacted with.");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Price text field interacted with.");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Max text field interacted with.");             
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Min text field interacted with.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add button clicked.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete button clicked.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save button clicked.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel button clicked.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("All candidate parts data grid interacted with.");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Parts associated with product data grid interacted with.");
        }
    }
}
