using System;
using System.Collections.Generic;
using System.Text;


namespace SystemInventory.ProductsFiles
{
    public class AssociatedParts
    {
        public int partId { get; set; }
        public int productId { get; set; }
        public string partName { get; set; }       
        public decimal price { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
