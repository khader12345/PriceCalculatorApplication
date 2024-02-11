//www.github.com/khader12345/Assignment1
using PriceCalculatorApp.BusinessLogic;
using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics;

namespace PriceCalculatorApp
{
        // MainPage of the Price Calculator App.
        // This page allows users to calculate the total price of items, including optional discounts.
    public partial class MainPage : ContentPage
    {
        // Initializes a new instance of the MainPage class.
        // Sets the initial state of the UI components.
        public MainPage()
        {
            InitializeComponent();

        // Ensure that the discount picker has a default selected value on startup.


            discountPicker.SelectedIndex = 0;
        }

        // Handles the click event of the calculate button.
        // Parses user inputs and calculates the total price.

        private void CalculateClick(object sender, EventArgs e)
        {
            try
            {

                // Parse the price per item and number of items from user input.

                double pricePerItem = double.Parse(pricePerItemEntry.Text);
                int numberOfItems = int.Parse(numberItemsEntry.Text);

                // Remove the '%' character and parse the discount percentage.

                string discountString = discountPicker.SelectedItem.ToString().Replace("%", "");
                if (double.TryParse(discountString, out double discountPercent))
                {
                    double discount = discountPercent / 100.0; // Converts percentage to decimal for calculation.
                    bool plusDiscount = addDiscountCheckBox.IsChecked; // Determines if the discount should be applied.

                // Create a new Bill object with the parsed values.

                    var bill = new Bill(pricePerItem, discountPercent, (int)numberOfItems, plusDiscount);

                // Calculate the total price based on the Bill object's logic.

                    double total = bill.TotalCalculation();

                // Display the calculated total price to the user.

                    resultLabel.Text = $"Total: {total:C2}";
                }
                else
                {

                // Handle cases where parsing of numbers failed.

                    resultLabel.Text = "Please select a valid discount.";
                }
            }
            catch (FormatException)
            {
                resultLabel.Text = "Please enter valid numbers for price and items.";
            }
            catch (ArgumentOutOfRangeException ex)
            {

                 // Handle cases where input values are out of the expected range (e.g., negative numbers).

                resultLabel.Text = $"Invalid input: {ex.ParamName}";
            }
        }

        //Handles the click event of the clear button.
        //Resets the form inputs to their default states.

        private void ClearClick(object sender, EventArgs e)
        {

        // Clear the text inputs and reset the UI components to their default states.

            userNameEntry.Text = string.Empty;
            pricePerItemEntry.Text = string.Empty;
            numberItemsEntry.Text = string.Empty;
            discountPicker.SelectedIndex = 0;
            addDiscountCheckBox.IsChecked = false; 
            resultLabel.Text = "Total: ";
        }
    }
}