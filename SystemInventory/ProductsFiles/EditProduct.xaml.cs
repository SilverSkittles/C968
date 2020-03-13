using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SystemInventory.PartsFiles;

namespace SystemInventory.ProductsFiles
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private int currentPart;
        //private int currentFilteredParts;
        public List<Part> partsList = new List<Part>();
        public List<Part> FPartList = new List<Part>();
        private List<AssociatedParts> productParts = new List<AssociatedParts>();
        public EditProduct()
        {
            InitializeComponent();
        }

        public EditProduct(Product product, List<Part> parts, List<AssociatedParts> productFilteredParts)
        {
            InitializeComponent();

            Product_ID.Text = product.ProductId.ToString();
            Product_Name.Text = product.ProductName;
            Inventory.Text = product.InStock.ToString();
            Price.Text = product.Price.ToString();
            Max.Text = product.Max.ToString();
            Min.Text = product.Min.ToString();
            partsList = parts;
            DgProdParts.ItemsSource = partsList;
            productParts = productFilteredParts; 
            foreach (var prod in productFilteredParts)
            {
                var partId = prod.partId;
                foreach (var row in partsList)
                {
                    if (row.PartId == partId)
                        FPartList.Add(row);
                }
            }
            DgFilteredParts.ItemsSource = FPartList;

        }

        private bool validateForm()
        {
            int number;
            decimal cost;
            bool valid = true;

            if (Product_Name.Text.Length < 1)
                valid = false;
            if (Inventory.Text.Length < 1 && int.TryParse(Inventory.Text, out number))
                valid = false;
            if (Price.Text.Length < 1 && decimal.TryParse(Price.Text, out cost))
                valid = false;
            if (Max.Text.Length < 1 && int.TryParse(Max.Text, out number))
                valid = false;
            if (Min.Text.Length < 1 && int.TryParse(Min.Text, out number))
                valid = false;


            if (valid == true)
            {
                int min = Convert.ToInt32(Min.Text);
                int max = Convert.ToInt32(Max.Text);
                int inventory = Convert.ToInt32(Inventory.Text);

                if (min > max)
                {
                    valid = false;
                    MessageBox.Show("Minimum is greater than Maximum", "Error", MessageBoxButton.OK);
                }
                if (inventory < min || inventory > max)
                {
                    valid = false;
                    MessageBox.Show("Inventory needs to be between minimum and maximum levels", "Error", MessageBoxButton.OK);
                }
            }

            return valid;
        }
           

        private void DgProdParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (DgProdParts.SelectedItem != null)
            //{
            //    PartsItems part = (PartsItems)DgProdParts.SelectedItem;
            //    currentPart = part.partId;
            //}


            if (DgProdParts.SelectedItem != null)
            {
                if (DgProdParts.SelectedItem.ToString() == "{NewItemPlaceholder}")
                {
                    //currentPart = 0;
                    MessageBox.Show("Please select a valid row.");
                }
                else
                {
                    Part curProdRow = (Part)DgProdParts.SelectedItem;
                    currentPart = curProdRow.PartId;
                }
            }
        }

       
        private void DgFilteredParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (DgFilteredParts.SelectedItem != null)
            //{
            //    PartsItems part = (PartsItems)DgFilteredParts.SelectedItem;
            //    currentPart = part.partId;
            //}

            if (DgFilteredParts.SelectedItem != null)
            {
                if (DgFilteredParts.SelectedItem.ToString() == "{NewItemPlaceholder}")
                {                  
                    MessageBox.Show("Please select a valid row.");
                }
                else
                {
                    Part curProdRow = (Part)DgFilteredParts.SelectedItem;
                    currentPart = curProdRow.PartId;
                }
            }
        }

        private void BtnSearchParts_Click(object sender, RoutedEventArgs e)
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
                        DgProdParts.SelectedItem = pId;
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
                DgProdParts.SelectedItem = pName;
            }
        }

        private void BtnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var valid = validateForm();
                if (valid == true)
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(Product_ID.Text);
                    product.ProductName = Product_Name.Text.ToString();
                    product.InStock = Convert.ToInt32(Inventory.Text);
                    product.Price = Convert.ToDecimal(Price.Text);
                    product.Max = Convert.ToInt32(Max.Text);
                    product.Min = Convert.ToInt32(Min.Text);

                    ((MainWindow)Application.Current.MainWindow).updateProductList(product);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("All forms fields are required", "Alert", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please use the correct the correct input format for all fields.", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void BtnAddPartToProduct_Click(object sender, RoutedEventArgs e)
        {
            if (partsList.Count > 0)
            {
                if (currentPart != 0)
                {
                    var part = partsList.Find(e => e.PartId == currentPart);
                    var fPart = FPartList.Find(e => e.PartId == part.PartId);
                    if (fPart == null)
                    {
                        AssociatedParts filteredPart = new AssociatedParts();
                        filteredPart.partId = part.PartId;
                        filteredPart.productId = Convert.ToInt32(Product_ID.Text);
                        FPartList.Add(part);

                        DgFilteredParts.ItemsSource = null;
                        DgFilteredParts.ItemsSource = FPartList;

                        ((MainWindow)Application.Current.MainWindow).associatedParts.Add(filteredPart);
                    }
                    else
                    {
                        MessageBox.Show("This part is already associated with the current product", "Alert", MessageBoxButton.OK);
                    }
                }
            }
        }

        private void BtnDeletePartFromProduct_Click(object sender, RoutedEventArgs e)
        {
            var part = FPartList.Find(e => e.PartId == currentPart);
            FPartList.Remove(part);
            var fp = productParts.Find(e => e.partId == part.PartId);
            //FilteredParts filteredPart = new FilteredParts();
            //filteredPart.partId = part.partId;
            //filteredPart.productId = Convert.ToInt32(Product_ID.Text);

            ((MainWindow)Application.Current.MainWindow).associatedParts.Remove(fp);

            DgFilteredParts.ItemsSource = null;
            DgFilteredParts.ItemsSource = FPartList;
        }

        private void CancelSaveButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
