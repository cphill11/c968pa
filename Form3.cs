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
    public partial class Form3 : Form      // Modify Part form
    {
        private Part currentPart;

        public Form3(Part part)
        {
            InitializeComponent();

            currentPart = part;

            // Populate fields
            textBox1.Text = part.PartID.ToString();
            textBox2.Text = part.Name;
            textBox3.Text = part.InStock.ToString();   // Inventory
            textBox4.Text = part.Price.ToString();     // Price
            textBox6.Text = part.Min.ToString();       // Min
            textBox5.Text = part.Max.ToString();       // Max

            if (part is InHouse inHouse)
            {
                radioButton1.Checked = true;
                textBox7.Text = inHouse.MachineID.ToString();
            }
            else if (part is Outsourced outsourced)
            {
                radioButton2.Checked = true;
                textBox7.Text = outsourced.CompanyName;
            }

            // Prevent editing ID
            textBox1.Enabled = false;

        }

        private void label6_Click(object sender, EventArgs e)
        {
               
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)     // Selecting radio button for In-house changes label to "Machine ID"
        {
            label8.Text = "Machine ID";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)      // Selecing radio buttion for Outsourced changes label to "Company Name"
        {
            label8.Text = "Company Name";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)     // ID text box
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)  //Name text box
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)     // Inventory text box
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // Price or cost text box
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)     // Max text box
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)     // Min text box
        {
         
        }

        private void textBox7_TextChanged(object sender, EventArgs e)   // Machine ID / Company Name text box
        {
           
        }

        // Save Part Button functionality
        private void button1_Click(object sender, EventArgs e) 
        {
            if (currentPart == null)
            {
                MessageBox.Show("No part loaded.");
                return;
            }

            // Name validation
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Name cannot be empty.");      // Name text box validation
                return;
            }

            // Shared numeric validation
            if (!ValidationHelper.TryGetPartValues(
                textBox3, // Inventory
                textBox4, // Price
                textBox6, // Min
                textBox5, // Max
                errorProvider1,
                out int stock,
                out decimal price,
                out int min,
                out int max))
            {
                return;
            }

            // 🔧 Type-specific validation
            if (radioButton1.Checked && currentPart is InHouse inHouse)
            {
                if (!int.TryParse(textBox7.Text, out int machineID))
                {
                    errorProvider1.SetError(textBox7, "Machine ID must be a number.");
                    return;
                }

                inHouse.MachineID = machineID;
            }
            else if (radioButton2.Checked && currentPart is Outsourced outsourced)
            {
                if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    errorProvider1.SetError(textBox7, "Company Name cannot be empty.");
                    return;
                }

                outsourced.CompanyName = textBox7.Text;
            }

            // ✅ Update AFTER validation passes
            currentPart.Name = textBox2.Text;
            currentPart.InStock = stock;
            currentPart.Price = price;
            currentPart.Min = min;
            currentPart.Max = max;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
    }
}
