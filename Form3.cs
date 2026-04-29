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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)     // In-house radito button
        {
            label8.Text = "Machine ID";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)      // Outsource radio button
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

        private void button1_Click(object sender, EventArgs e)    // Save button
        {
            try
            {
                currentPart.Name = textBox2.Text;
                currentPart.InStock = int.Parse(textBox3.Text);
                currentPart.Price = decimal.Parse(textBox4.Text);
                currentPart.Min = int.Parse(textBox6.Text);
                currentPart.Max = int.Parse(textBox5.Text);

                if (radioButton1.Checked && currentPart is InHouse inHouse)
                {
                    inHouse.MachineID = int.Parse(textBox7.Text);
                }
                else if (radioButton2.Checked && currentPart is Outsourced outsourced)
                {
                    outsourced.CompanyName = textBox7.Text;
                }

                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid input.");
            }
        }

        private void button2_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
    }
}
