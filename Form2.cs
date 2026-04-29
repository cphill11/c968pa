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
                errorProvider1.SetError(textBox2, "Name cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }



        private void textBox3_TextChanged(object sender, EventArgs e)      // Inventory text box validation
        {
            if (!int.TryParse(textBox3.Text, out _))
            {
                errorProvider1.SetError(textBox3, "Please enter a number.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)     // Price or cost text box validation
        {
            if (!decimal.TryParse(textBox4.Text, out _))
            {
                errorProvider1.SetError(textBox4, "Please enter a number.");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)    // Max text box validation
        {
            if (!int.TryParse(textBox5.Text, out _))
            {
                errorProvider1.SetError(textBox5, "Please enter a number.");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }

            ValidateMinMax();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)     // Min text box validation
        {
            if (!int.TryParse(textBox6.Text, out _))
            {
                errorProvider1.SetError(textBox6, "Please enter a number.");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }

            ValidateMinMax();
        }

        private void ValidateMinMax()     // Min vs max validation to ensure data entered are within range
        {
            // wait for fields to contain data
            if (string.IsNullOrWhiteSpace(textBox5.Text) || // Max
                string.IsNullOrWhiteSpace(textBox6.Text) || // Min
                string.IsNullOrWhiteSpace(textBox3.Text))   // Inventory
            {
                // Clear errors and exit
                errorProvider1.SetError(textBox5, "");
                errorProvider1.SetError(textBox6, "");
                errorProvider1.SetError(textBox3, "");
                return;
            }

            // 🔹 Clear existing errors first
            errorProvider1.SetError(textBox5, "");
            errorProvider1.SetError(textBox6, "");
            errorProvider1.SetError(textBox3, "");

            // 🔹 Now validate
            if (int.TryParse(textBox5.Text, out int max) &&
                int.TryParse(textBox6.Text, out int min) &&
                int.TryParse(textBox3.Text, out int stock))
            {
                if (min > max)
                {
                    errorProvider1.SetError(textBox6, "Min cannot be greater than Max.");
                    errorProvider1.SetError(textBox5, "Max must be greater than or equal to Min.");
                }

                if (stock < min || stock > max)
                {
                    errorProvider1.SetError(textBox3, "Inventory not within Min/Max");
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)        // Machine ID Or Company Name text box validations
        {

            if (radioButton1.Checked) // InHouse
            {
                if (!int.TryParse(textBox7.Text, out _))    // Machine ID text box validation
                {
                    errorProvider1.SetError(textBox7, "Machine ID must be a number.");
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
                    errorProvider1.SetError(textBox7, "Company Name required.");
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)           //Save part button
        {
            try
            {
                string name = textBox2.Text;
                decimal price = decimal.Parse(textBox4.Text);
                int stock = int.Parse(textBox3.Text);
                int min = int.Parse(textBox6.Text);
                int max = int.Parse(textBox5.Text);

                //Validation
                if (string.IsNullOrWhiteSpace(name))        // Name text box validation
                {
                    MessageBox.Show("Name cannot be empty.");
                    return;
                }

                if (min > max)           // Evaluate Min & Max entry values
                {
                    MessageBox.Show("Minimum value cannot be greater than Maximum value.");
                    return;
                }

                if (stock < min || stock > max)
                {
                    MessageBox.Show("Inventory stock level must be between minimum value and maximum value.");
                    return;
                }

                Part newPart;

                int newID = Program.Inventory.AllParts.Count + 1;

                if (radioButton1.Checked) // InHouse
                {
                    int machineID;

                    if (!int.TryParse(textBox7.Text, out machineID))
                    {
                        MessageBox.Show("Machine ID must be a number.");
                        return;
                    }

                    newPart = new InHouse
                    {
                        PartID = newID,    // auto generated ID
                        Name = name,
                        Price = price,
                        InStock = stock,
                        Min = min,
                        Max = max,
                        MachineID = machineID 
                    };
                }
                else // Outsourced
                {
                    string company = textBox7.Text;

                    if (string.IsNullOrWhiteSpace(company))          // Company Name validation
                    {
                        MessageBox.Show("Company Name cannot be empty.");
                        return;
                    }

                    newPart = new Outsourced
                    {
                        PartID = newID,       // auto generated ID
                        Name = name,
                        Price = price,
                        InStock = stock,
                        Min = min,
                        Max = max,
                        CompanyName = textBox7.Text
                    };
                }

                Program.Inventory.AllParts.Add(newPart);

                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid data input.  Please review fields.");
            }
        }

        private void button2_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
    }
}
