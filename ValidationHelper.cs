using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c968pa
{
    public static class ValidationHelper      // all numeric validation
    {
        public static bool TryGetProductValues(     // make form controls reusable across all product forms
            TextBox txtStock,
            TextBox txtPrice,
            TextBox txtMin,
            TextBox txtMax,
            ErrorProvider errorProvider,
            out int stock,
            out decimal price,
            out int min,
            out int max)
        {
            stock = 0;
            price = 0;
            min = 0;
            max = 0;

            errorProvider.Clear();
            bool valid = true;

            if (!int.TryParse(txtStock.Text, out stock))       // Inventory validation
            {
                errorProvider.SetError(txtStock, "Inventory must be a whole number.");
                valid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))     // Price validation
            {
                errorProvider.SetError(txtPrice, "Price must be a valid number.");
                valid = false;
            }

            if (!int.TryParse(txtMin.Text, out min))      // Minimum value validation
            {
                errorProvider.SetError(txtMin, "Min must be a whole number.");
                valid = false;
            }

            if (!int.TryParse(txtMax.Text, out max))      // Maximum value validation
            {
                errorProvider.SetError(txtMax, "Max must be a whole number.");
                valid = false;
            }

            if (!valid) return false;       // if not valid data, stop process

            if (min > max)     // Min and max comparison validation
            {
                errorProvider.SetError(txtMin, "Min cannot be greater than Max.");
                errorProvider.SetError(txtMax, "Max must be greater than or equal to Min.");
                return false;
            }

            if (stock < min || stock > max)   // Validate inventory falls within range provided by Min and Max values
            {
                errorProvider.SetError(txtStock, "Inventory must be within range between Min and Max values.");
                return false;
            }

            return true;
        }

        public static bool TryGetPartValues(      // make form controls reusable across all part forms
           TextBox txtStock,
           TextBox txtPrice,
           TextBox txtMin,
           TextBox txtMax,
           ErrorProvider errorProvider,
           out int stock,
           out decimal price,
           out int min,
           out int max)
          
        {
            stock = 0;
            price = 0;
            min = 0;
            max = 0;

            errorProvider.Clear();
            bool valid = true;

            if (!int.TryParse(txtStock.Text, out stock))
            {
                errorProvider.SetError(txtStock, "Inventory must be a whole number.");    // Inventory validation
                valid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))     // Price validation
            {
                errorProvider.SetError(txtPrice, "Price must be a valid number.");
                valid = false;
            }

            if (!int.TryParse(txtMin.Text, out min))      // Min value validation
            {
                errorProvider.SetError(txtMin, "Min must be a whole number.");
                valid = false;
            }

            if (!int.TryParse(txtMax.Text, out max))    // Max value validation
            {
                errorProvider.SetError(txtMax, "Max must be a whole number.");
                valid = false;
            }

            if (!valid) return false;        // if not valid data, stop process

            if (min > max)      // Min and max comparison validation
            {
                errorProvider.SetError(txtMin, "Min cannot be greater than Max.");
                errorProvider.SetError(txtMax, "Max must be greater or equal to Min.");
                return false;
            }

            if (stock < min || stock > max)    // Validate inventory falls within range provided by Min and Max values
            {
                errorProvider.SetError(txtStock, "Inventory must be within Min/Max.");
                return false;
            }

            return true;
        }
    }
}