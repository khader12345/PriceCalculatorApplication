//Bill.cs
namespace PriceCalculatorApp.BusinessLogic
{

        // Represents a bill for a purchase, including calculations for taxes and discounts.//

    public class Bill
    {

        // Default tax rate applied to the total price before discount.//

        private const double DefaultTax = 0.13;

        //The price of a single item.//
        //The discount rate applied to the total price, represented as a percentage.//
        //The number of items being purchased.//
        //Indicates whether the discount should be applied to the bill.//

        public double PricePerItem { get; set; }
        public double Discount { get; set; }
        public int NumberOfItems { get; set; }
        public bool PlusDiscount { get; set; }

        //Calculates the total price of the bill, including tax and optionally applying a discount.//
        //Returns the total price after tax and discount (if applicable).//
        public double TotalCalculation()
        {

        // Calculate base total before tax or discount

            double total = PricePerItem * NumberOfItems;

        // Apply tax to the total

                total += total * DefaultTax;

        // If discount is applicable, reduce the total by the discount percentage
                
                if (PlusDiscount)
                {
                    total -= total * (Discount / 100.0);

                }
                return total;
            
        }

        //Initializes a new instance of the class
        // Ensure that price per item and number of items are not negative; if so, throw an exception.

        public Bill(double priceItem, double discount, int numberofitems, bool plusDiscount)
        {
            PricePerItem = priceItem >= 0 ? priceItem :  throw new ArgumentOutOfRangeException(nameof(priceItem));
            Discount = discount;
            NumberOfItems = numberofitems >= 0 ? numberofitems : throw new ArgumentOutOfRangeException(nameof(numberofitems));
            PlusDiscount = plusDiscount; 

        }
    
    
    }

}