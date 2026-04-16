using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c968pa
{
    public class Product
    {

        //Define Data (Properties)
        public BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();

        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }


        //Methods
        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool RemoveAssociatedPart(int partID)
        {
            var part = LookupAssociatedPart(partID);
            if (part != null)
            {
                return AssociatedParts.Remove(part);
            }
            return false;
        }

        public Part LookupAssociatedPart(int partID)
        {
            return AssociatedParts.FirstOrDefault(p => p.PartID == partID);
        }

    }
}
