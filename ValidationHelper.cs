using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c968pa
{
    public static class ValidationHelper
    {
        public static bool TryGetProductValues(
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
                errorProvider.SetError(txtStock, "Inventory must be a whole number.");
                valid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                errorProvider.SetError(txtPrice, "Price must be a valid number.");
                valid = false;
            }

            if (!int.TryParse(txtMin.Text, out min))
            {
                errorProvider.SetError(txtMin, "Min must be a whole number.");
                valid = false;
            }

            if (!int.TryParse(txtMax.Text, out max))
            {
                errorProvider.SetError(txtMax, "Max must be a whole number.");
                valid = false;
            }

            if (!valid) return false;

            if (min > max)
            {
                errorProvider.SetError(txtMin, "Min cannot be greater than Max.");
                errorProvider.SetError(txtMax, "Max must be ≥ Min.");
                return false;
            }

            if (stock < min || stock > max)
            {
                errorProvider.SetError(txtStock, "Inventory must be within Min/Max.");
                return false;
            }

            return true;
        }
    }
}