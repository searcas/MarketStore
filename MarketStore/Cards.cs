using System;
using System.Collections.Generic;
using System.Text;

namespace MarketStore
{
    abstract class Cards 
    {
        public string DateOfMembership { get; set; }
        public float DiscountRateBronze { get { return _discountRateBronze; } }
        public float DiscountRateSilverGold { get { return _discountRateSilverGold; } }
        public float PurchasedValue { get; set; }
        public float StoragePerMonth { get; set; }

        protected float _discountRateBronze = 0.0f;
        protected float _discountRateSilverGold = 2.0f;
        bool _isRestarted = true;
        static private int CardID { get; set; } = 1;
        public Cards(string DateOfMemberShip) 
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dear Client your Card ID Is : {0} ",CardID);
            Console.WriteLine("Memebership started {0}",DateOfMemberShip);
            CardID++;
            
        }
        public abstract void CalculateDiscount();
        public virtual void CalculatePurchaseDiscount()
        {
            FillTheStorage();
            CalculateDiscount();
            float discountOnPurchasedItem = PurchasedValue * (_discountRateBronze + 100)/100;
            float total = discountOnPurchasedItem - PurchasedValue;
            Console.WriteLine("Your total amount of discount for this purchase is: ${0} ", total);
            Console.WriteLine("Your Total price after discount is: ${0}",PurchasedValue-total);
        }
        protected virtual void FillTheStorage()
        {
            if (DateTime.Now.Day == 1)
            {
                if (_isRestarted)
                {
                    StoragePerMonth = 0;
                    _discountRateBronze = 0.0f;
                    _discountRateSilverGold = 2.0f;
                    _isRestarted = false;
                }
                StoragePerMonth += PurchasedValue;
                Console.WriteLine();
                Console.WriteLine("First Day of the Month your total amount is: ${0}",StoragePerMonth);
                Console.WriteLine();
            }
            else
            {
                StoragePerMonth += PurchasedValue;
                Console.WriteLine();
                Console.WriteLine("Your Total Amount for this month is : ${0}",StoragePerMonth);
                Console.WriteLine();
                _isRestarted = true;
            }
        }
    }
    class Bronze : Cards
    {
        public Bronze(string DateOfMemberShip) : base(DateOfMemberShip)
        {
            Console.WriteLine("This client have Bronze Membership");
        }

        public override void CalculateDiscount() 
        {
            if (StoragePerMonth < 100)
            {
                _discountRateBronze = 0.0f;
            }
            else if(StoragePerMonth >= 100 && StoragePerMonth <=300)
            {
                _discountRateBronze = 2.5f;
            }
            else
            {
                _discountRateBronze = 2.5f;
            }
            Console.WriteLine("Total Amount of discount rate is {0} %", DiscountRateBronze);
        }
    }
    class Silver : Cards
    {

        public Silver(string DateOfMemberShip) : base( DateOfMemberShip)
        {
            Console.WriteLine("This client have Silver Membership");

        }
        public override void CalculatePurchaseDiscount()
        {
            FillTheStorage();
            CalculateDiscount();
            float discountOnPurchasedItem = PurchasedValue * (_discountRateSilverGold + 100) / 100;
            float total = discountOnPurchasedItem - PurchasedValue;
            Console.WriteLine("Your total amount of discount for this purchase is: ${0} ", total);
            Console.WriteLine("Your Total price after discount is: ${0}", PurchasedValue - total);
        }
        public override void CalculateDiscount()
        {
            if (StoragePerMonth  > 300)
            {
                _discountRateSilverGold = 3.5f;
            }
            else
            {
                _discountRateSilverGold = 2.5f;
            }
            Console.WriteLine("Total Amount of discount rate is {0}%", DiscountRateSilverGold);
        }
    }
    class Gold : Cards
    {
        float cap = 100.0f;

        public Gold(string DateOfMemberShip) : base(DateOfMemberShip)
        {
            Console.WriteLine("This client have Gold Membership");
        }
        public override void CalculatePurchaseDiscount()
        {
            FillTheStorage();
            CalculateDiscount();
            float discountOnPurchasedItem = PurchasedValue * (_discountRateSilverGold + 100) / 100;
            float total = discountOnPurchasedItem - PurchasedValue;
            Console.WriteLine("Your total amount of discount for this purchase is: ${0} ", total);
            Console.WriteLine("Your Total price after discount is: ${0}", PurchasedValue - total);
        }
        public override void CalculateDiscount()
        {

            while (StoragePerMonth >= cap && _discountRateSilverGold < 10)
            {
                    cap += 100.0f;
                _discountRateSilverGold = (DiscountRateSilverGold >= 10) ? 10.0f : _discountRateSilverGold += 1;
            }
            Console.WriteLine("Total Amount of discount rate is {0}%", DiscountRateSilverGold);
        }
    }
}
