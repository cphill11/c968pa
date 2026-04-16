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
        public BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public BindingList<Part> AllParts { get; set; } = new BindingList<Part>();
    }
}
