using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using SystemInventory.PartsFiles;
using SystemInventory.ProductsFiles;

namespace SystemInventory
{
    public class Inventory : Part
    {

        public new List<Part> partsList = new List<Part>();
        public new List<Product> productsList = new List<Product>();

       

        public List<Product> AddProduct()
        {
            for (int x = 1; x < 5; x++)
            {
                Product p = new Product();
                p.ProductName = "Part" + x.ToString();
                p.ProductId = x;
                p.Min = x;
                p.Max = x + 50;
                p.InStock = (x + 25);
                p.Price = Convert.ToDecimal(x) * 10;                
                productsList.Add(p);
            }
            //DgProducts.ItemsSource = productsList;
            return productsList;

        }



        public bool RemoveProduct(int productID)
        {
            bool success = false;
            foreach (Product prod in productsList)
            {
                if (productID == prod.ProductId)
                {
                    productsList.Remove(prod);
                    return success = true;
                }
                else
                {
                    MessageBox.Show("Unable to remove this product.");
                    return false;
                }
            }
            return success;
        }

  
        public Product LookupProduct(int productID)
        {
            foreach (Product prod in productsList)
            {
                if (prod.ProductId == productID)
                {
                    return prod;
                }
            }
            Product emptyProd = new Product();
            return emptyProd;
        }

        public void UpdateProduct(int productID, Product updatedProd)
        {
            foreach (Product currentProd in productsList)
            {
                if (currentProd.ProductId == productID)
                {
                    currentProd.ProductName = updatedProd.ProductName;
                    currentProd.InStock = updatedProd.InStock;
                    currentProd.Price = updatedProd.Price;
                    currentProd.Max = updatedProd.Max;
                    currentProd.Min = updatedProd.Min;
                    currentProd.associatedParts = updatedProd.associatedParts;
                    return;
                }
            }

        }

        public List<Part> AddAPart() 
        {
            for (int x = 1; x < 5; x++)
            {
                Inventory p = new Inventory();
                p.PartName = "Part" + x.ToString();
                p.PartId = x;
                p.Min = x;
                p.Max = x + 50;
                p.InStock = (x + 25);
                p.Price = Convert.ToDecimal(x) * 10;
                p.machineID = x;
                partsList.Add(p);
            }
            //DgParts.ItemsSource = partsList;
            return partsList;
        }

        public bool DeletePart(Part part)
        {
            try
            {
                partsList.Remove(part);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Part LookupPart(int partID)
        {
            foreach (Part part in partsList)
            {
                if (part.PartId == partID)
                {
                    return part;
                }
            }
            Part emptyPart = null;
            return emptyPart;
        }

        public void UpdateInHousePart(int partID, Inventory inPart)
        {
            for (int i = 0; i < partsList.Count; i++)
            {
                if (partsList[i].GetType() == typeof(Inventory))
                {
                    Inventory newPart = (Inventory)partsList[i];

                    if (newPart.PartId == partID)
                    {
                        newPart.PartName = inPart.PartName;
                        newPart.InStock = inPart.InStock;
                        newPart.Price = inPart.Price;
                        newPart.Max = inPart.Max;
                        newPart.Min = inPart.Min;
                        newPart.machineID = inPart.machineID;
                    }
                }
            }
        }
        public void UpdateOutsourcedPart(int partID, Inventory outPart)
        {
            for (int i = 0; i < partsList.Count; i++)
            {
                if (partsList[i].GetType() == typeof(Inventory))
                {
                    Inventory newPart = (Inventory)partsList[i];

                    if (newPart.PartId == partID)
                    {
                        newPart.PartName = outPart.PartName;
                        newPart.InStock = outPart.InStock;
                        newPart.Price = outPart.Price;
                        newPart.Max = outPart.Max;
                        newPart.Min = outPart.Min;
                        newPart.companyName = outPart.companyName;
                    }
                }
            }
        }
    }
}
