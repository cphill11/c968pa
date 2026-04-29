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
        private Product currentProduct = null;
        private BindingList<Part> associatedParts = new BindingList<Part>();


        public Form4()   // allows to add product
        {
            InitializeComponent();

            textBox2.Enabled = false; // prevent user from entering ID data manually
            textBox2.Text = (Program.Inventory.Products.Count + 1).ToString();

            associatedParts = new BindingList<Part>();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView2.AutoGenerateColumns = true;

            dataGridView1.DataSource = Program.Inventory.AllParts;       // All Candidate Parts
            dataGridView2.DataSource = associatedParts;        // Associated Parts

        }

        public Form4(Product product)     // allows to modify product
        {
            InitializeComponent();
            currentProduct = product;

            // Copy associated parts (important: new list, not reference)
            associatedParts = new BindingList<Part>(product.AssociatedParts.ToList());

            // Bind grids
            dataGridView1.DataSource = Program.Inventory.AllParts;
            dataGridView2.DataSource = associatedParts;

            // Fill fields
            textBox2.Text = product.ProductID.ToString();
            textBox3.Text = product.Name;
            textBox4.Text = product.InStock.ToString();
            textBox5.Text = product.Price.ToString();
            textBox6.Text = product.Max.ToString();
            textBox7.Text = product.Min.ToString();

            // Lock ID
            textBox2.Enabled = false;

        }

        private void label6_Click(object sender, EventArgs e)   // Name label
        {
        
        }

        private void label8_Click(object sender, EventArgs e)  // Price label
        {

        }

        private void label10_Click(object sender, EventArgs e) // Min label
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)    // Search text field
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)   // ID text field
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)   // Name text field
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)   // Inventory text field
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)    // Price text field
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)    // Max text field
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)  // Min text field
        {
         
        }


        private void button1_Click(object sender, EventArgs e)   // Add product button
        {
            if (dataGridView1.CurrentRow != null)
            {
                Part selected = (Part)dataGridView1.CurrentRow.DataBoundItem;

                if (!associatedParts.Contains(selected)) // optional: prevent duplicates
                {
                    associatedParts.Add(selected);
                }
                else
                {
                    MessageBox.Show("Part already associated.");
                }
            }
            else
            {
                MessageBox.Show("Please select a part to add.");
            }
        }

        private void button2_Click(object sender, EventArgs e)    // Save product button
        {
            if (associatedParts.Count == 0)         // requires 1+ selected part
            {
                MessageBox.Show("Product must have at least one associated part.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))     // Name text box validation
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

            // if validation passes, create product 
            Product newProduct = new Product
            {
                ProductID = Program.Inventory.Products.Count + 1,    
                Name = textBox3.Text,
                InStock = stock,
                Price = price,
                Max = max,
                Min = min
            };

            foreach (Part p in associatedParts)
            {
                newProduct.AddAssociatedPart(p);
            }

            Program.Inventory.Products.Add(newProduct);

            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)    // Delete  button
        {
            if (dataGridView2.CurrentRow != null)
            {
                Part selected = (Part)dataGridView2.CurrentRow.DataBoundItem;

                if (MessageBox.Show("Remove this associated part?",
                                    "Confirm",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    associatedParts.Remove(selected);
                }
            }
            else
            {
                MessageBox.Show("Please select a part to remove.");
            }
        }

        private void button4_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)    // Search button
        {
            string search = textBox1.Text.Trim();

            // Reset if empty
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

                // Optional: highlight first result
                dataGridView1.ClearSelection();
                dataGridView1.Rows[0].Selected = true;
            }
            else
            {
                MessageBox.Show("No matching parts found.");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)       // All parts data grid
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)      // Parts associated data grid
        {
           
        }
    }
}
