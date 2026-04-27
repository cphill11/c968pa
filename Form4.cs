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
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public Form4()
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.Inventory.AllParts;
            dataGridView2.DataSource = associatedParts;

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

        private void textBox1_TextChanged(object sender, EventArgs e)    // search text field
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


        private void button1_Click(object sender, EventArgs e)   // Add button
        {
            if (dataGridView1.CurrentRow != null)
            {
                Part selected = (Part)dataGridView1.CurrentRow.DataBoundItem;
                associatedParts.Add(selected);
            }
        }

        private void button2_Click(object sender, EventArgs e)    // Save button
        {
            try
            {
                Product newProduct = new Product
                {
                    ProductID = int.Parse(textBox2.Text),
                    Name = textBox3.Text,
                    InStock = int.Parse(textBox4.Text),
                    Price = decimal.Parse(textBox5.Text),
                    Max = int.Parse(textBox6.Text),
                    Min = int.Parse(textBox7.Text)
                };

                // Add associated parts
                foreach (Part p in associatedParts)
                {
                    newProduct.AddAssociatedPart(p);
                }

                Program.Inventory.Products.Add(newProduct);

                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid input. Please check all fields.");
            }
        }
        private void button3_Click(object sender, EventArgs e)    // Delete button
        {
            if (dataGridView2.CurrentRow != null)
            {
                Part selected = (Part)dataGridView2.CurrentRow.DataBoundItem;
                associatedParts.Remove(selected);
            }
        }

        private void button4_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)    // Search button
        {
            string search = textBox1.Text;

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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)       // All parts data grid
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)      // Parts associated data grid
        {
           
        }
    }
}
