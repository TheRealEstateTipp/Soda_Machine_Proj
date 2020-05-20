using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public BackPack backpack;
        public List<Coin> payment;
        public SodaMachine sodaMachine;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new BackPack();
            payment = new List<Coin>();
            sodaMachine = new SodaMachine();

        }
        public void BuySoda()
        {
            double TotalCost;
            TotalCost = SelectSoda();
            SelectSoda();
            GetPayment(TotalCost);
        }
        
        public void GetPayment(double TotalCost)
        {
            double totalCoinValue = 0;
         while(TotalCost > totalCoinValue)
         {
                Console.WriteLine("Please Choose Your Coin");
                string coin = Console.ReadLine();

                switch (coin)
                {
                    case "Quarter":
                        Console.WriteLine("You have selected a Quarter");
                        Quarter quarter = new Quarter();
                        payment.Add(quarter);
                        totalCoinValue += RemoveCoin("Quarter");
                        break;
                    case "Dime":
                        Console.WriteLine("You have selected a Dime");
                        Dime dime = new Dime();
                        payment.Add(dime);
                        totalCoinValue += RemoveCoin("Dime");
                        break;
                    case "Nickle":
                        Console.WriteLine("You have selected a Nickle");
                        Nickle nickle = new Nickle();
                        payment.Add(nickle);
                        totalCoinValue += RemoveCoin("Nickle");
                        break;
                    case "Penny":
                        Console.WriteLine("You have selected a Penny");
                        Penny penny = new Penny();
                        payment.Add(penny);
                        totalCoinValue += RemoveCoin("Penny");
                        break;
                    default:
                        Console.WriteLine("This Coin is not available");
                        break;

                }                                                                                                     
         }
           
        }
        public double RemoveCoin(string coinType)
        {
            double returnValue = 0;
            for (int i = 0; i < wallet.coins.Count; i++)
            {
                if (wallet.coins[i].name == coinType)
                {
                    payment.Add(wallet.coins[i]);
                    returnValue = wallet.coins[i].Value;
                    wallet.coins.RemoveAt(i);
                    
                }
            }
            return returnValue;
        }

        public double SelectSoda()

        {
            while (true)
            {
                Console.WriteLine("Please Select Your Desired Soda");
                string soda = Console.ReadLine();

                switch (soda)
                {
                    case "Cola":
                        Console.WriteLine("You have selected a Cola");
                        return RemoveSoda("Cola");
                    case "Orange Soda":
                        Console.WriteLine("You have selected a Orange Soda");
                        return RemoveSoda("Orange Soda");
                    case "Root Beer":
                        Console.WriteLine("You have selected a Root Beer");
                        return RemoveSoda("Root Beer");
                    default:
                        Console.WriteLine("This selection is not available. Please try again.");
                        break;
                }

            }
        }
        public double RemoveSoda(string sodaType)
        {
            double returnCost = 0;
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if (sodaMachine.inventory[i].name == sodaType)
                {
                    returnCost = sodaMachine.inventory[i].Cost;
                    sodaMachine.inventory.RemoveAt(i);
                    break;
                }
            }
            return returnCost;
        }
    }
}
