using PriceCalculatorApp.BusinessLogic;
using Microsoft.Maui.Controls;
using System;

namespace PriceCalculatorApp
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            discountPicker.SelectedIndex = 0;
        }

        private void CalculateClick(object sender, EventArgs e)
        {
            try
            {
                double PricePerItem = double.Parse(pricePerItemEntry.Text);
                int NumberOfItems = int.Parse(numberItemsEntry.Text);
                double Discount = double.Parse(discountPicker.SelectedItem.ToString());
                bool TotalProperty = plusDiscountCheckbox.IsChecked;

                var bill = new Bill(PricePerItem, NumberOfItems, Discount, TotalProperty);
                double total = bill.TotalCalculation();

                resultLabel.Text = $"Total: {total:C2}";
            }
            catch (FormatException)
            {
                resultLabel.Text = "Please enter valid numbers for price and items.";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                resultLabel.Text = $"Invalid input: {ex.ParamName}";
            }

        }
                
                
        }



    }
}