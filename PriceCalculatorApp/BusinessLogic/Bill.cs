﻿namespace PriceCalculatorApp.BusinessLogic
{
    public class Bill
    {
        private const double DefaultTax = 0.13;
        public double PricePerItem { get; set; }
        public double Discount { get; set; }
        public int NumberOfItems { get; set; }
        public bool PlusDiscount { get; set; } 


        public double TotalCalculation()
        {
            
                double total = PricePerItem * NumberOfItems;
                total += total * DefaultTax;
                
                if (PlusDiscount)
                {
                    total -= total * (Discount / 100.0);

                }
                return total;
            
        }
        
        public Bill(double priceItem, double discount, int numberofitems, bool plusDiscount)
        {
            PricePerItem = priceItem >= 0 ? priceItem :  throw new ArgumentOutOfRangeException(nameof(priceItem));
            Discount = discount;
            NumberOfItems = numberofitems >= 0 ? numberofitems : throw new ArgumentOutOfRangeException(nameof(numberofitems));
            PlusDiscount = plusDiscount; 

        }
    
    
    }

}