using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SystemInventory.PartsFiles;
using SystemInventory.ProductsFiles;

namespace SystemInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Part> partsList = new List<Part>();
        public List<Product> productsList = new List<Product>();
        public List<AssociatedParts> associatedParts = new List<AssociatedParts>();
        private int currentProduct;
        private int currentPart;
        private int partUniqueId;
        private int prodUniqueId;

        public MainWindow()
        {
            InitializeComponent();

            //auto generated sample items to facilitate testing
            for (int x = 1; x < 5; x++)
            {
                Inventory p = new Inventory();
                p.PartName = "Part" + x.ToString();
                p.PartId = GenerateId("part");
                p.Min = x;
                p.Max = x + 50;
                p.InStock = (x + 25);
                p.Price = Convert.ToDecimal(x) * 10;                
                if(x % 2 == 0)
                {
                    p.companyName = "Company" + x.ToString();
                    p.Outsourced = true;
                    p.Inhouse = false;

                }
                else
                {
                    p.machineID = x;
                    p.Outsourced = false;
                    p.Inhouse = true;
                }
                partsList.Add(p);
            }
            DgParts.ItemsSource = partsList;

            for (int x = 1; x < 5; x++)
            {
                Product p = new Product();
                p.ProductName = "Part" + x.ToString();
                p.ProductId = GenerateId(null);
                p.Min = x;
                p.Max = x + 50;
                p.InStock = (x + 25);
                p.Price = Convert.ToDecimal(x) * 10;
                productsList.Add(p);
            }
            DgProducts.ItemsSource = productsList;
            
        }
         
        //Generates unique part or product IDs
        private int GenerateId(string type)
        {
            int id;
            if (type == "part")
            {
                id = ++partUniqueId;
                return id;
            }
            else
            {
                id = ++prodUniqueId;
                return id;
            }
        }

        private void BtnAddPart_Click(object sender, RoutedEventArgs e)
        {
            int id = GenerateId("part");
            AddPart ap = new AddPart(id);
            ap.ShowDialog();
            DgParts.ItemsSource = null;
            DgParts.ItemsSource = partsList;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            int id = GenerateId("product");
            AddProduct ap = new AddProduct(id, partsList);
            ap.ShowDialog();
            DgProducts.ItemsSource = null;
            DgProducts.ItemsSource = productsList;
        }

        private void BtnModifyPart_Click(object sender, RoutedEventArgs e)
        {
            if (partsList.Count > 0)
            {
                if (currentPart != 0)
                {
                    var part = partsList.Find(e => e.PartId == currentPart);
                    EditPart ep = new EditPart(part);
                    ep.ShowDialog();
                    DgParts.ItemsSource = null;
                    DgParts.ItemsSource = partsList;
                }
                else
                {
                    MessageBox.Show("Please select a part to modify", "Error", MessageBoxButton.OKCancel);
                }
            }
            else
            {
                MessageBox.Show("There are no parts to modify", "Error", MessageBoxButton.OKCancel);
            }
        }

        private void BtnModifyProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productsList.Count > 0)
            {
                if (currentProduct != 0)
                {
                    var product = productsList.Find(e => e.ProductId == currentProduct);
                    var fproduct = associatedParts.FindAll(e => e.productId == product.ProductId);
                    EditProduct ep = new EditProduct(product, partsList, fproduct);
                    ep.ShowDialog();
                    DgProducts.ItemsSource = null;
                    DgProducts.ItemsSource = productsList;
                }
                else
                {
                    MessageBox.Show("Please select a product to modify", "Error", MessageBoxButton.OKCancel);
                }
            }
            else
            {
                MessageBox.Show("There are no products to modify", "Error", MessageBoxButton.OKCancel);
            }
        }

        private void BtnDeletePart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this part?", "Delete Part", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var part = partsList.Find(e => e.PartId == currentPart);
                partsList.Remove(part);
                DgParts.ItemsSource = null;
                DgParts.ItemsSource = partsList;
            }
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (currentProduct != 0)
            {                
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var product = productsList.Find(e => e.ProductId == currentProduct);
                    var partProduct = associatedParts.Find(e => e.productId == product.ProductId);
                    if (partProduct != null)
                    {
                        MessageBox.Show("Unable to delete this product. Please remove all associated parts before removing this item.", "Alert", MessageBoxButton.OK);
                    }
                    else
                    {
                        productsList.Remove(product);
                        DgProducts.ItemsSource = null;
                        DgProducts.ItemsSource = productsList;
                    }
                }
            }
        }

        private void BtnExitProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {       

            if (DgProducts.SelectedItem != null)
            {
                if (DgProducts.SelectedItem.ToString() == "{NewItemPlaceholder}")
                {
                    
                    MessageBox.Show("Please select a valid row.");
                }
                else
                {
                    Product curProdRow = (Product)DgProducts.SelectedItem;
                    currentProduct = curProdRow.ProductId;
                }
            }
        }

        //Returns selected row in the parts grid
        private void DgParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            

            if (DgParts.SelectedItem != null)
            {
                if (DgParts.SelectedItem.ToString() == "{NewItemPlaceholder}")
                {
                   
                    MessageBox.Show("Please select a valid row.");
                }
                else
                {
                    Part curProdRow = (Part)DgParts.SelectedItem;
                    currentPart = curProdRow.PartId;
                }
            }
        }


        public void updateProductList(Product product)
        {
            foreach (var r in productsList)
            {
                if (product.ProductId == r.ProductId)
                {
                    r.ProductName = product.ProductName;
                    r.ProductId = product.ProductId;
                    r.InStock = product.InStock;
                    r.Price = product.Price;
                    r.Max = product.Max;
                    r.Min = product.Min;
                }
            }
                DgProducts.ItemsSource = null;
                DgProducts.ItemsSource = productsList;            
        }

        public void updatePartList(Part part)
        {
            foreach (var r in partsList)
            {
                if(part.PartId == r.PartId)
                {
                    r.PartId = part.PartId;
                    r.PartName = part.PartName;
                    r.InStock = part.InStock;
                    r.Price = part.Price;
                    r.Max = part.Max;
                    r.Min = part.Min;
                    r.machineID = part.machineID;
                    r.companyName = part.companyName;
                    r.Outsourced = part.Outsourced;
                    r.Inhouse = part.Inhouse;
                }
            }

            DgParts.ItemsSource = null;
            DgParts.ItemsSource = partsList;
        }

        public void updateFilteredList(AssociatedParts part)
        {
            foreach (var r in associatedParts)
            {
                if (part.partId == r.partId && part.productId == r.productId)
                {
                    associatedParts.Remove(part);
                }
            }
        }

        public void saveFilteredList(List<AssociatedParts> parts)
        {
            foreach(var row in parts)
            {
                associatedParts.Add(row);
            }
        }


        private void BtnSearchPart1_Click(object sender, RoutedEventArgs e)
        {            
            var text = SearchPartBox.Text.Trim();
            var pName = partsList.Find(e => e.PartName.ToUpper() == text.ToUpper());
            if (pName == null)
            {
                int number;
                bool valid = false;

                if (int.TryParse(text, out number))
                    valid = true;

                if (valid == true)
                {
                    var pId = partsList.Find(e => e.PartId == Convert.ToInt32(text));

                    if (pId != null)
                    {
                        DgParts.SelectedItem = pId;
                        
                    }
                    else
                    {
                        MessageBox.Show("No parts items matched your search", "Alert", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("No parts items matched your search", "Alert", MessageBoxButton.OK);
                }
            }

            if (pName != null)
            {
                DgParts.SelectedItem = pName;                               
            }
        }

        private void BtnSearchProduct_Click(object sender, RoutedEventArgs e)
        {

            var text = SearchProductBox.Text.Trim();
            var pName = productsList.Find(e => e.ProductName.ToUpper() == text.ToUpper());
            if (pName == null)
            {
                int number;
                bool valid = false;

                if (int.TryParse(text, out number))
                    valid = true;

                if (valid == true)
                {
                    var pId = productsList.Find(e => e.ProductId == Convert.ToInt32(text));

                    if (pId != null)
                    {
                        DgProducts.SelectedItem = pId;
                    }
                    else
                    {
                        MessageBox.Show("No parts items matched your search", "Alert", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("No parts items matched your search", "Alert", MessageBoxButton.OK);
                }
            }

            if (pName != null)
            {
                DgProducts.SelectedItem = pName;               
            }
        }



    }
}
