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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public int currentPart;  
        public List<Part> partsList = new List<Part>();
        public List<Part> FPartList = new List<Part>();
        private List<AssociatedParts> productParts = new List<AssociatedParts>();
        public AddProduct(int id, List<Part> parts)
        {
            InitializeComponent();
            Product_ID.Text = id.ToString();
            partsList = parts;
            DgProdParts.ItemsSource = partsList;
        }
        
        
        private void CancelSaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

                    ((MainWindow)Application.Current.MainWindow).productsList.Add(product);
                    ((MainWindow)Application.Current.MainWindow).saveFilteredList(productParts);

                    this.Close();
                }
                else
                {
                    MessageBox.Show( "All forms fields are required", "Alert", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please use the correct input format for all fields.", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void DgProdParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            if (DgProdParts.SelectedItem != null)
            {
                if (DgProdParts.SelectedItem.ToString() == "{NewItemPlaceholder}")
                {                    
                    MessageBox.Show("Please select a valid row.");
                }
                else
                {
                    Part curProdRow = (Part)DgProdParts.SelectedItem;
                    currentPart = curProdRow.PartId;
                }
            }
        }

        //List of associated parts for the selected product
        private void DgFilteredParts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            if (DgProdParts.SelectedItem != null)
            {
                if (DgProdParts.SelectedItem.ToString() == "{NewItemPlaceholder}")
                {               
                    MessageBox.Show("Please select a valid row.");
                }
                else
                {
                    Part curProdRow = (Part)DgProdParts.SelectedItem;
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
                        productParts.Add(filteredPart);

                        DgFilteredParts.ItemsSource = null;
                        DgFilteredParts.ItemsSource = FPartList;
                        
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
            var pPart = productParts.Find(e => e.partId == currentPart);
            FPartList.Remove(part);
            productParts.Remove(pPart);
            
            DgFilteredParts.ItemsSource = null;
            DgFilteredParts.ItemsSource = FPartList;
        }                
    }
}
