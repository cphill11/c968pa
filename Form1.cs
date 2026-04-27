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
        }



        private void Form1_Load(object sender, EventArgs e)
        {}
        
        private void button1_Click(object sender, EventArgs e)       // Add part button
        {
            Form2 addPartForm = new Form2();
            addPartForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)    // Modify part button
        {
            if (dataGridViewParts.CurrentRow != null)
            {
                Part selected = (Part)dataGridViewParts.CurrentRow.DataBoundItem;

                Form3 form = new Form3(selected);
                form.ShowDialog();

                dataGridViewParts.Refresh(); // ensures UI updates
            }

        }

        private void button3_Click(object sender, EventArgs e)      // Delete part button
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
        }

        private void button4_Click(object sender, EventArgs e)     // Add product button
        {
            Form4 form = new Form4();  // Add mode (no parameter)
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)   // Modify product button
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                Product selected = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;

                Form4 form = new Form4(selected);
                form.ShowDialog();

                dataGridViewProducts.Refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)   // Delete product button
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
           
        }

        private void button8_Click(object sender, EventArgs e)   // Part search button
        {
           
        }

        private void button9_Click(object sender, EventArgs e)     // Product search button
        {
           
        }

        private void button10_Click(object sender, EventArgs e)   // Exit page button
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)     // Part search text field
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)    // Product search text field
        {
            MessageBox.Show("Products Search text field used.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)     // Part data grid
        {
          
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)    // Product data grid
        {
            
        }
    }
}
