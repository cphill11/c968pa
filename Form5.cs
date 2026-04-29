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

        private void button3_Click(object sender, EventArgs e)     // Save button
        {
            
            if (associatedParts.Count == 0)       // look for 1+ associated part
            {
                MessageBox.Show("Product must have at least one associated part.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))     // Name text box validation
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int stock))    // Inventory text box validation
            {
                MessageBox.Show("Inventory must be a whole number.");
                return;
            }

            if (!decimal.TryParse(textBox5.Text, out decimal price))   // Price text box validation
            {
                MessageBox.Show("Price must be a valid number (e.g., 9.99).");
                return;
            }

            if (!int.TryParse(textBox6.Text, out int max))      // Max text box validation
            {
                MessageBox.Show("Max must be a whole number.");
                return;
            }

            if (!int.TryParse(textBox7.Text, out int min))    // Min text box validation
            {
                MessageBox.Show("Min must be a whole number.");
                return;
            }
            
            if (min > max)        // Min vs Max validation
            {
                MessageBox.Show("Min cannot be greater than Max.");
                return;
            }

            if (stock < min || stock > max)      // Inventory within min and max range validation
            {
                MessageBox.Show("Inventory must be between Min and Max.");
                return;
            }

            // if validation passes, update
            currentProduct.Name = textBox3.Text;
            currentProduct.InStock = stock;
            currentProduct.Price = price;
            currentProduct.Max = max;
            currentProduct.Min = min;

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
