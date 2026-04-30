using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace c968pa
{
    public partial class Form1 : Form      // Main screen form
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
            if (dataGridViewParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to delete.");                   // provide visual feedback to user
                return;
            }

            Part selected = (Part)dataGridViewParts.CurrentRow.DataBoundItem;

            // Check ALL products for this part prior to deletion
            foreach (Product product in Program.Inventory.Products)
            {
                foreach (Part p in product.AssociatedParts)
                {
                    if (p.PartID == selected.PartID)    // compare ID to verify
                    {
                        MessageBox.Show("Cannot delete this part. It is associated with a product.");        // provide visual feedback to user
                        return;
                    }
                }
            }

            if (MessageBox.Show("Are you sure you want to delete this part?",  // additional confirmation; visual feedback provided to user
                "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.Inventory.DeletePart(selected);
            }
        }

        private void button4_Click(object sender, EventArgs e)     // Add product button
        {
            Form4 form = new Form4();  
            form.ShowDialog();

            dataGridViewProducts.DataSource = null;
            dataGridViewProducts.DataSource = Program.Inventory.Products;
        }

        private void button5_Click(object sender, EventArgs e)   // Modify product button
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                Product selected = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;

                Form5 form = new Form5(selected);
                form.ShowDialog();

                dataGridViewProducts.Refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)   // Delete product button
        {
            if (dataGridViewProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.");          // provide visual feedback to user
                return;
            }

            Product selected = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Are you sure you want to delete this product?",      // confirm deletion, visual feedback provided to user
                "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.Inventory.RemoveProduct(selected.ProductID);
            }
        }

        private void button8_Click(object sender, EventArgs e)   // Part search button
        {
            string search = textBox1.Text.Trim();

            // Check to see if search is empty, will reset if search is empty
            if (string.IsNullOrEmpty(search))
            {
                dataGridViewParts.DataSource = Program.Inventory.AllParts;
                return;
            }

            // allow search
            var results = Program.Inventory.AllParts
                .Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
                            p.PartID.ToString() == search)
                .ToList();

            if (results.Any())
            {
                dataGridViewParts.DataSource = new BindingList<Part>(results);
            }
            else
            {
                MessageBox.Show("No matching parts found.");      // provide visual feedback to user
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)     // Part search text field
        {

        }

        private void button9_Click(object sender, EventArgs e)     // Product search button
        {
            string search = textBox2.Text.Trim();

            var results = Program.Inventory.Products
                .Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
                            p.ProductID.ToString() == search)
                .ToList();

            if (results.Any())
            {
                dataGridViewProducts.DataSource = new BindingList<Product>(results);
            }
            else
            {
                MessageBox.Show("No matching products found.");             // provide visual feedback to user
            }

            if (string.IsNullOrEmpty(search))
            {
                dataGridViewProducts.DataSource = Program.Inventory.Products;
                return;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)    // Product search text field
        {

        }
        private void button10_Click(object sender, EventArgs e)   // Exit application button
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)     // Part data grid
        {
          
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)    // Product data grid
        {
            
        }
    }
}
