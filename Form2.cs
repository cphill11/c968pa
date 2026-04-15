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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("In-house radio button used.");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Outsourced radio button used.");
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ID text box used.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Name text box used.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Inventory text box used.");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Price or Cost text box used.");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Max text box used.");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Min text box used.");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Machine ID or Company Name text box used.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save button clicked.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel button clicked.");
        }
    }
}
