using System;
using System.Collections;
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
    public partial class Form2 : Form      // Add Part form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Enabled = false;    // prevent user from entering ID data manually
            textBox1.Text = (Program.Inventory.AllParts.Count + 1).ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)    // Selecting radio button for In-house changes label to "Machine ID"
        {
           lblDynamic.Text = "Machine ID";
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)    // Selecing radio buttion for Outsourced changes label to "Company Name"
        {
            lblDynamic.Text = "Company Name";
           
        }


        private void textBox1_TextChanged(object sender, EventArgs e)        // ID text box
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)           // Name text box
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Name cannot be empty.");  // provide visual feedback to user
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }



        private void textBox3_TextChanged(object sender, EventArgs e)      // Inventory text box validation
        {
            ValidationHelper.TryGetPartValues(
                textBox3, // Inventory
                textBox4, // Price
                textBox6, // Min
                textBox5, // Max
                errorProvider1,                // provide visual feedback to user
                out _, out _, out _, out _);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)     // Price or cost text box validation
        {

            ValidationHelper.TryGetPartValues(
                textBox3,  // Inventory
                textBox4,  // Price
                textBox6,  // Min
                textBox5,  // Max
                errorProvider1,                    // provide visual feedback to user
                out _, out _, out _, out _);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)    // Max text box validation
        {

            ValidationHelper.TryGetPartValues(
                textBox3, // Inventory
                textBox4, // Price
                textBox6, // Min
                textBox5, // Max
                errorProvider1,                 // provide visual feedback to user
                out _, out _, out _, out _);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)     // Min text box validation
        {

            ValidationHelper.TryGetPartValues(
                textBox3,  // Inventory
                textBox4, // Price
                textBox6,  // Min
                textBox5,  // Max
                errorProvider1,                // provide visual feedback to user
                out _, out _, out _, out _);
        }
             

        private void textBox7_TextChanged(object sender, EventArgs e)        // Machine ID Or Company Name text box validations
        {

            if (radioButton1.Checked) // InHouse
            {
                if (!int.TryParse(textBox7.Text, out _))    // Machine ID text box validation; TryParse method used to validate input in code instead of allowing code to throw exceptions
                {
                    errorProvider1.SetError(textBox7, "Machine ID must be a number.");            // provide visual feedback to user
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                }
            }
            else // Outsourced
            {
                if (string.IsNullOrWhiteSpace(textBox7.Text))     // Company Name text box validation
                {
                    errorProvider1.SetError(textBox7, "Company Name required.");            // provide visual feedback to user
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)           //Save part button
        
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))     // Name validation
            {
                MessageBox.Show("Name cannot be empty.");           // provide visual feedback to user
                return;
            }

            // uses ValidationHelper.cs
            if (!ValidationHelper.TryGetPartValues(
                textBox3, // Inventory
                textBox4, // Price
                textBox6, // Min
                textBox5, // Max
                errorProvider1,               // provide visual feedback to user    
                out int stock,
                out decimal price,
                out int min,
                out int max))
            {
                return;
            }

            Part newPart;

            int newID = Program.Inventory.AllParts.Count + 1;

            if (radioButton1.Checked) // InHouse
            {
                if (!int.TryParse(textBox7.Text, out int machineID))    // Machine ID validation; TryParse method used to validate input in code instead of allowing code to throw exceptions
                {
                    errorProvider1.SetError(textBox7, "Machine ID must be a number.");          // provide visual feedback to user
                    return;
                }

                newPart = new InHouse
                {
                    PartID = newID,
                    Name = textBox2.Text,
                    Price = price,
                    InStock = stock,
                    Min = min,
                    Max = max,
                    MachineID = machineID
                };
            }
            else // Outsourced
            {
                if (string.IsNullOrWhiteSpace(textBox7.Text))     // Company Name validation
                {
                    errorProvider1.SetError(textBox7, "Company Name cannot be empty.");          // provide visual feedback to user
                    return;
                }

                newPart = new Outsourced
                {
                    PartID = newID,
                    Name = textBox2.Text,
                    Price = price,
                    InStock = stock,
                    Min = min,
                    Max = max,
                    CompanyName = textBox7.Text
                };
            }

            Program.Inventory.AddPart(newPart);

            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
    }
}
