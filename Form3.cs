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
           
            if (string.IsNullOrWhiteSpace(textBox2.Text))     //  Name text box validation
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int stock))      // Inventory text box validation
            {
                MessageBox.Show("Inventory must be a whole number.");
                return;
            }

            if (!decimal.TryParse(textBox4.Text, out decimal price))    // Price text box validation
            {
                MessageBox.Show("Price must be a valid number (e.g., 9.99).");
                return;
            }

            if (!int.TryParse(textBox6.Text, out int min))      // Min text box validation
            {
                MessageBox.Show("Min must be a whole number.");
                return;
            }

            if (!int.TryParse(textBox5.Text, out int max))    // Max text box validation
            {
                MessageBox.Show("Max must be a whole number.");
                return;
            }

            if (min > max)              // Min vs Max validation
            {
                MessageBox.Show("Min cannot be greater than Max.");
                return;
            }

            if (stock < min || stock > max)       // Inventory within max and min range validation
            {
                MessageBox.Show("Inventory must be between Min and Max.");
                return;
            }

            if (radioButton1.Checked && currentPart is InHouse inHouse)    // Inhouse radio button
            {
                if (!int.TryParse(textBox7.Text, out int machineID))        // Machine ID text box validation
                {
                    MessageBox.Show("Machine ID must be a whole number.");
                    return;
                }

                inHouse.MachineID = machineID;
            }
            else if (radioButton2.Checked && currentPart is Outsourced outsourced)   // Outsourced radio button
            {
                if (string.IsNullOrWhiteSpace(textBox7.Text))       // Company Name text box validation
                {
                    MessageBox.Show("Company Name cannot be empty.");
                    return;
                }

                outsourced.CompanyName = textBox7.Text;
            }

            // update after successful validation
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
