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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           lblDynamic.Text = "Machine ID";
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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
                errorProvider1.SetError(textBox2, "Name cannot be empty");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }



        private void textBox3_TextChanged(object sender, EventArgs e)      // Inventory text box
        {
            if (!int.TryParse(textBox3.Text, out _))
            {
                errorProvider1.SetError(textBox3, "Invalid inventory value");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)     // Price or cost text box
        {
            if (!decimal.TryParse(textBox4.Text, out _))
            {
                errorProvider1.SetError(textBox4, "Invalid price");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)    // Max text box
        {
            if (!int.TryParse(textBox5.Text, out _))
            {
                errorProvider1.SetError(textBox5, "Max must be a number");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }

            ValidateMinMax();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)     // Min text box
        {
            if (!int.TryParse(textBox6.Text, out _))
            {
                errorProvider1.SetError(textBox6, "Min must be a number");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }

            ValidateMinMax();
        }

        private void ValidateMinMax()
        {
            // 🔹 If required fields are empty, don't validate yet
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
                    errorProvider1.SetError(textBox6, "Min cannot be greater than Max");
                    errorProvider1.SetError(textBox5, "Max must be ≥ Min");
                }

                if (stock < min || stock > max)
                {
                    errorProvider1.SetError(textBox3, "Inventory not within Min/Max");
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)        // Machine ID Or Company Name text box
        {

            if (radioButton1.Checked) // InHouse
            {
                if (!int.TryParse(textBox7.Text, out _))
                {
                    errorProvider1.SetError(textBox7, "Machine ID must be a number");
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                }
            }
            else // Outsourced
            {
                if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    errorProvider1.SetError(textBox7, "Company Name required");
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)           //Save button
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                decimal price = decimal.Parse(textBox4.Text);
                int stock = int.Parse(textBox3.Text);
                int min = int.Parse(textBox6.Text);
                int max = int.Parse(textBox5.Text);

                //Validation logic
                if (min > max)
                {
                    MessageBox.Show("Minimum value cannot be greater than Maximum value.");
                    return;
                }

                if (stock < min || stock > max)
                {
                    MessageBox.Show("Inventory stock level must be between minimum value and maximum value.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(name))
                    {
                    MessageBox.Show("Name cannot be empty.");
                    return;
                }

                Part newPart;

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
                        PartID = id,
                        Name = name,
                        Price = price,
                        InStock = stock,
                        Min = min,
                        Max = max,
                        MachineID = int.Parse(textBox7.Text)
                    };
                }
                else // Outsourced
                {
                    string company = textBox7.Text;

                    if (string.IsNullOrWhiteSpace(company))
                    {
                        MessageBox.Show("Company Name cannot be empty.");
                        return;
                    }

                    newPart = new Outsourced
                    {
                        PartID = id,
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
            //MessageBox.Show("Data saved.");
        }







        private void button2_Click(object sender, EventArgs e)     // Cancel button
        {
            this.Close();
        }
    }
}
