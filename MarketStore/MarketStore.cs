using System;
using System.Collections.Generic;
using System.Text;

namespace MarketStore
{
    class MarketStore
    {
        public Client Client { get; set; } 
        public int Count { get; set; }
        public MarketStore(Client client) 
        {
            Client = client;
            
            Console.WriteLine("{0} Entered in Market..", Client.Name);
            Purchaseitem();
            Console.WriteLine();
            Console.WriteLine("Good by");
            Console.WriteLine();
        }
        public void Purchaseitem()
        {
            Items purchase = new Items();
            Client.Card.PurchasedValue = purchase.Fee;
            Client.Card.CalculatePurchaseDiscount();
        }
    }

    class Items
    {
        public enum ListItems
        {
            Shoes = 1,
            Jewels,
            Food,
            Drinks,
        }
        public int NumOfItems { get; set; } = 0;
        public int[] Price { set; get; }
        public int Fee { get; set; }
        public int CountinStock { get; set; } = 1000;
        public Items()
        {
            Console.WriteLine("Do You want something to buy?");
            Console.WriteLine();
            DisplayItems();
            Console.WriteLine();
            Price = new int[NumOfItems + 1];
            SetPrice();
        }
        void SetPrice()
        {

            foreach (ListItems item in Enum.GetValues(typeof(ListItems)))
            {
                switch (item)
                {
                    case ListItems.Shoes:
                        Price[(int)item] = 100;
                        break;
                    case ListItems.Jewels:
                        Price[(int)item] = 600;
                        break;
                    case ListItems.Food:
                        Price[(int)item] = 30;
                        break;
                    case ListItems.Drinks:
                        Price[(int)item] = 50;
                        break;
                }
            }
            Purchase();
        }
        public void DisplayItems()
        {
            foreach (ListItems item in Enum.GetValues(typeof(ListItems)))
            {
                switch (item)
                {
                    case ListItems.Shoes:
                        Console.WriteLine("The Price for Shoes is $100, if you want to buy press 1");
                        break;
                    case ListItems.Jewels:
                        Console.WriteLine("The Price for Jewels item is $600, if you want to buy press 2");
                        break;
                    case ListItems.Food:
                        Console.WriteLine("The Price for Food item is $30, if you want to buy press 3");
                        break;
                    case ListItems.Drinks:
                        Console.WriteLine("The Price for Drinks item is $50, if you want to buy press 4");
                        break;
                }
            NumOfItems++;
            }

        }
        void Purchase()
        {
                try
                {
                    int value;
                    Console.Write("Enter Value from 1-4: ");
                    value = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Value for this item is ${0}", Price[value]);
                    Console.WriteLine("How many items do you want to purchase?");
                    Console.WriteLine("Currently in stock {0}",CountinStock);
                    Console.Write("Count: ");
                    int totalAmountofItems = Convert.ToInt32(Console.ReadLine());
                    CountinStock = CountinStock - totalAmountofItems;
                    Fee = totalAmountofItems * Price[value];
                    Console.WriteLine("Total amount of this purchase is ${0}", Fee );
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bad Value");
                    Console.WriteLine("Try again");
                    throw ex;
                }
            
        }
    }
    
}
