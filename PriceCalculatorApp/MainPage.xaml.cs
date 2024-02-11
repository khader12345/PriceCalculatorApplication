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
                double pricePerItem = double.Parse(pricePerItemEntry.Text);
                int numberOfItems = int.Parse(numberItemsEntry.Text);
                string discountString = discountPicker.SelectedItem.ToString().Replace("%", "");
                if (double.TryParse(discountString, out double discountPercent))
                {
                    double discount = discountPercent / 100.0; 
                    bool plusDiscount = addDiscountCheckBox.IsChecked; 

                    var bill = new Bill(pricePerItem, discountPercent, (int)numberOfItems, plusDiscount);
                    double total = bill.TotalCalculation();

                    resultLabel.Text = $"Total: {total:C2}";
                }
                else
                {
                    resultLabel.Text = "Please select a valid discount.";
                }
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

        private void ClearClick(object sender, EventArgs e)
        {
            userNameEntry.Text = string.Empty;
            pricePerItemEntry.Text = string.Empty;
            numberItemsEntry.Text = string.Empty;
            discountPicker.SelectedIndex = 0;
            addDiscountCheckBox.IsChecked = false; 
            resultLabel.Text = "Total: ";
        }
    }
}