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

namespace SystemInventory.PartsFiles
{
    /// <summary>
    /// Interaction logic for EditPart.xaml
    /// </summary>
    public partial class EditPart : Window
    {
        public EditPart(Part part)
        {
            InitializeComponent();

            //previous data for part being edited
            Part_ID.Text = part.PartId.ToString();
            Part_Name.Text = part.PartName;
            Inventory.Text = part.InStock.ToString();
            Price.Text = part.Price.ToString();
            Max.Text = part.Max.ToString();
            Min.Text = part.Min.ToString();
            BtnInHouseRadio.IsChecked = part.Inhouse;
            BtnOutSourcedRadio.IsChecked = part.Outsourced;
            if (part.Inhouse == true)
            {
                machineIdLabel.Text = "Machine ID";
                Machine_ID.Text = part.machineID.ToString();           
            }
            if (part.Outsourced == true)
            {
                machineIdLabel.Text = "Company";
                Machine_ID.Text = part.companyName.ToString();               
            }
        }

        private void BtnCancelSavePart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validateForm()
        {
            int number;
            decimal cost;
            bool valid = true;

            if (Part_Name.Text.Length < 1)
                valid = false;
            if (Inventory.Text.Length < 1 && int.TryParse(Inventory.Text, out number))
                valid = false;
            if (Price.Text.Length < 1 && decimal.TryParse(Price.Text, out cost))
                valid = false;
            if (Max.Text.Length < 1 && int.TryParse(Max.Text, out number))
                valid = false;
            if (Min.Text.Length < 1 && int.TryParse(Min.Text, out number))
                valid = false;
            if (Machine_ID.Text.Length < 1)
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

        private void BtnSavePart_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var valid = validateForm();
                if (valid == true)
                {
                    Inventory part = new Inventory();
                    part.PartId = Convert.ToInt32(Part_ID.Text);
                    part.PartName = Part_Name.Text.ToString();
                    part.InStock = Convert.ToInt32(Inventory.Text);
                    part.Price = Convert.ToDecimal(Price.Text);
                    part.Max = Convert.ToInt32(Max.Text);
                    part.Min = Convert.ToInt32(Min.Text);
                    part.Inhouse = Convert.ToBoolean(BtnInHouseRadio.IsChecked);
                    part.Outsourced = Convert.ToBoolean(BtnOutSourcedRadio.IsChecked);
                    if(part.Inhouse == true)
                    {
                        part.machineID = Convert.ToInt32(Machine_ID.Text);
                        part.companyName = null;
                    }
                    if(part.Outsourced == true)
                    {
                        part.companyName = Machine_ID.Text;
                        part.machineID = 0;
                    }


                    ((MainWindow)Application.Current.MainWindow).updatePartList(part);

                    this.Close();
                }            
                else
                {
                    MessageBox.Show("All forms fields are required", "Alert", MessageBoxButton.OK);
                }
        
            }
            catch (Exception)
            {
                MessageBox.Show("Could not save this product", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
     

        private void BtnInHouseRadio_Click(object sender, RoutedEventArgs e)
        {
            if (BtnInHouseRadio.IsChecked == true)
            {
                machineIdLabel.Text = "Machine ID";
            }
            else
            {
                machineIdLabel.Text = "Company";
            }
        }

        private void BtnOutSourcedRadio_Click_1(object sender, RoutedEventArgs e)
        {
            if (BtnOutSourcedRadio.IsChecked == true)
            {
                machineIdLabel.Text = "Company";
            }
            else
            {
                machineIdLabel.Text = "Machine ID";
            }
        }
    }

}
