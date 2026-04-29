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
    public partial class Form5 : Form        // Modify Product form
    {
        private Product currentProduct;
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public Form5(Product product)
        {
            InitializeComponent();

            currentProduct = product;

            // Copy associated parts
            associatedParts = new BindingList<Part>(product.AssociatedParts.ToList());

            // Bind grids
            dataGridView1.DataSource = Program.Inventory.AllParts;
            dataGridView2.DataSource = associatedParts;

            // Populate fields
            textBox2.Text = product.ProductID.ToString();
            textBox3.Text = product.Name;
            textBox4.Text = product.InStock.ToString();
            textBox5.Text = product.Price.ToString();
            textBox6.Text = product.Max.ToString();
            textBox7.Text = product.Min.ToString();

            // Disable ID editing
            textBox2.Enabled = false;

            this.Text = "Modify Product";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)   // Search text field
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)   // ID text field
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)     // Name text field
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)   // Inventory text field
        {
         
        }

        private void textBox5_TextChanged(object sender, EventArgs e)   // Price text field
        {
          
        }

        private void textBox6_TextChanged(object sender, EventArgs e)    // Max text field
        {
                        
        }

        private void textBox7_TextChanged(object sender, EventArgs e)   // Min text field
        {
           
        }

        private void button5_Click(object sender, EventArgs e)    // Search button
        {
             string search = textBox1.Text.Trim();

             if (string.IsNullOrEmpty(search))
                {
                    dataGridView1.DataSource = Program.Inventory.AllParts;
                    return;
                }

             var results = Program.Inventory.AllParts
                .Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
                    p.PartID.ToString() == search)
                .ToList();

                if (results.Any())
                    {
                        dataGridView1.DataSource = new BindingList<Part>(results);
                    }
                else
                    {
                        MessageBox.Show("No matching parts found.");
                    }
        }

        private void button1_Click(object sender, EventArgs e)       // Add button
        {
            if (dataGridView1.CurrentRow != null)
            {
                Part selected = (Part)dataGridView1.CurrentRow.DataBoundItem;
                associatedParts.Add(selected);
            }
        }

        private void button2_Click(object sender, EventArgs e)     // Delete button
        {
            if (dataGridView2.CurrentRow != null)
            {
                Part selected = (Part)dataGridView2.CurrentRow.DataBoundItem;

                if (MessageBox.Show("Remove this part?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    associatedParts.Remove(selected);
                }
            }
        }

        // Save  button functionality
        private void button3_Click(object sender, EventArgs e)
        {
            if (currentProduct == null)
            {
                MessageBox.Show("No product loaded.");
                return;
            }

            if (associatedParts.Count == 0)
            {
                MessageBox.Show("Product must have at least one associated part.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            if (!ValidationHelper.TryGetProductValues(
                textBox4, // Inventory
                textBox5, // Price
                textBox7, // Min
                textBox6, // Max
                errorProvider1,
                out int stock,
                out decimal price,
                out int min,
                out int max))
            {
                return;
            }

            // Update product
            currentProduct.Name = textBox3.Text;
            currentProduct.InStock = stock;
            currentProduct.Price = price;
            currentProduct.Min = min;
            currentProduct.Max = max;

            // Replace associated parts
            currentProduct.AssociatedParts.Clear();
            foreach (Part p in associatedParts)
            {
                currentProduct.AddAssociatedPart(p);
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)    // Cancel button
        {
            this.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)     // All candidate parts data grid
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)   // Parts associated with product data grid
        {

        }

    }
}
