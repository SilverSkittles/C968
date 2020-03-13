using System;
using System.Collections.Generic;
using System.Text;
using SystemInventory.PartsFiles;

namespace SystemInventory.ProductsFiles
{
    public class Product
    {
        public List<AssociatedParts> associatedParts = new List<AssociatedParts>();     

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }

    }
}
