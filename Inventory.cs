using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c968pa
{
    public class Inventory
    {
        //Define Data (Properties)
        public BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public BindingList<Part> AllParts { get; set; } = new BindingList<Part>();


        // Product Methods    
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public bool RemoveProduct(int productID)
        {
            var product = LookupProduct(productID);
            if (product != null)
            {
                return Products.Remove(product);
            }
            return false;
        }

        public Product LookupProduct(int productID)
        {
            return Products.FirstOrDefault(p => p.ProductID == productID);
        }

        public void UpdateProduct(int productID, Product updatedProduct)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductID == productID)
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
            return AllParts.FirstOrDefault(p => p.PartID == partID);
        }

        public void UpdatePart(int partID, Part updatedPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].PartID == partID)
                {
                    AllParts[i] = updatedPart;
                    return;
                }
            }
        }


    }
}
