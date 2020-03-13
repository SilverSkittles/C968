using System;
using System.Collections.Generic;
using System.Text;

namespace SystemInventory.PartsFiles
{

    public abstract class Part : Inhouse
    {        
        public int PartId { get; set; }
        public string PartName { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }      
        public bool Outsourced { get; set; }
        public bool Inhouse { get; set; }

    }
}
