using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c968pa
{
    public class Inventory
    {
        public BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

        //Product Methods    
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public bool RemoveProduct(int productID)
        {
            //Find Product before able to remove product
            var product = LookupProduct(productID);
            if (product != null)
            {
                return Products.Remove(product);
            }
            return false;
        }

        public Product LookupProduct(int productID)
        {
            return Products.FirstOrDefault(p => p.ID == productID);
        }
        public void UpdateProduct(int productID, Product updatedProduct)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ID == productID)
                {
                    Products[i] = updatedProduct;
                    return;
                }
            }
        }


        //Part Methods

        public void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        public bool DeletePart(Part part)
        {
            return AllParts.Remove(part);
        }

        public Part LookupPart(int partID)
        {
            return AllParts.FirstOrDefault(p => p.ID == partID);
        }

        public void UpdatePart(int partID, Part updatedPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].ID == partID)
                {
                    AllParts[i] = updatedPart;
                    return;
                }
            }
        }


    }
}
