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
            discountPicker.SelectedIndex = 0;

        }

        private void CalculateClick (object sender, EventArgs e)
        {
            try
            {
                double PricePerItem = double.Parse(pricePerItemEntry.Text);
                int NumberOfItems = int.Parse(numberItemsEntry.Text);
                double Discount = double.Parse(discountPicker.SelectedItem.ToString());
            }
        }
    }
}