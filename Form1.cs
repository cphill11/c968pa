using System;
using System.Windows.Forms;


namespace c968pa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Force datagrid views to auto generate
            dataGridViewProducts.AutoGenerateColumns = true;
            dataGridViewParts.AutoGenerateColumns = true;

            dataGridViewProducts.DataSource = Program.Inventory.Products;
            dataGridViewParts.DataSource = Program.Inventory.AllParts;
            //MessageBox.Show(Program.Inventory.Products.Count.ToString());       <--- used to test grid error
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Left Add Button was clicked.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Left Modify Button was clicked.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewParts.CurrentRow != null)
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this part?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    Part selected = (Part)dataGridViewParts.CurrentRow.DataBoundItem;
                    Program.Inventory.AllParts.Remove(selected);
                }
            }
            //MessageBox.Show("Left Delete Button was clicked.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Right Add Button was clicked.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Right Modify Button was clicked.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    Product selected = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;
                    Program.Inventory.Products.Remove(selected);
                }
            }
            //MessageBox.Show("Right Delete Button was clicked.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Left Search Button was clicked.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Right Search Button was clicked.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exit Button clicked.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Parts Search text field used.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Products Search text field used.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Parts data grid interacted with.");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Products data grid interacted with.");
        }
    }
}
