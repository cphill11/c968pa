using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c968pa
{
    public abstract class Part
    {
        public int PartID {  get; set; }
        public string Name { get; set; }
        public decimal Price{ get; set; }
        public int InStock { get; set; }
        public int Max { get; set; }
        public int Min {  get; set; }
      
    }
}
