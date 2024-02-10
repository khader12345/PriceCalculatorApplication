using PriceCalculatorApp.BusinessLogic;
using System;
using Microsoft.Maui.Controls;

namespace PriceCalculatorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            discountPicker.SelectedIndex = 0; // Set a default value for the picker.
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                double pricePerItem = double.Parse(pricePerItemEntry.Text);
                int numberItems = int.Parse(numberItemsEntry.Text);
                double discount = double.Parse(discountPicker.SelectedItem.ToString());

                // Create a Bill object with the picked discount
                var bill = new Bill(pricePerItem, discount, numberItems, true);
                resultLabel.Text = bill.ToString();
            }
            catch (FormatException)
            {
                DisplayAlert("Input Error", "Please enter valid numerical values.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            userNameEntry.Text = string.Empty;
            pricePerItemEntry.Text = string.Empty;
            numberItemsEntry.Text = string.Empty;
            discountPicker.SelectedIndex = 0;
            resultLabel.Text = string.Empty;
        }
    }
}
