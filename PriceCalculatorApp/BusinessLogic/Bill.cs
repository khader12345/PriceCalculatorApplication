namespace PriceCalculatorApp.BusinessLogic
{
    public class Bill
    {
        public double PricePerItem { get; set; }
        public double Discount { get; set; }
        public int NumberOfItems { get; set; }
        public bool TotalProperty { get; set; } 


        public double Total
        {
            get
            {
                double total = PricePerItem * NumberOfItems;
                if (TotalProperty)
                {
                    total -= Total * (Discount / 100);

                }
                return total;
            }
        }
    
    
    
    }

}