using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetPayment()
        {
            //loop this stuff

         
            Console.WriteLine("Please Enter Your Payment");
            string coin = Console.ReadLine();

            switch (coin)
            {
                case "Quarter":
                    Console.WriteLine("You have selected a Quarter");
                    RemoveCoin("Quarter");
                    break;
                case "Dime":
                    Console.WriteLine("You have selected a Dime");
                    RemoveCoin("Dime");
                    break;
                case "Nickle":
                    Console.WriteLine("You have selected a Nickle");
                    RemoveCoin("Nickle");
                    break;
                case "Penny":
                    Console.WriteLine("You have selected a Penny");
                    RemoveCoin("Penny");
                    break;
                default:
                    Console.WriteLine("This Coin is not available");
                    break;

            }
        }
        public void RemoveCoin(string coinType)
        {
            for (int i = 0; i < wallet.coins.Count; i++)
            {
                if (wallet.coins[i].name == coinType)
                {
                    payment.Add(wallet.coins[i]);
                    wallet.coins.RemoveAt(i);
                    break;
                }
            }
        }

        public void SelectSoda()
        {
            Console.WriteLine("Please Select Your Desired Soda");
            string soda = Console.ReadLine();

            switch (soda)
            {
                case "Cola":
                    Console.WriteLine("You have selected a Cola");
                    RemoveCoin("Cola");
                    break;
                case "Orange Soda":
                    Console.WriteLine("You have selected a Orange Soda");
                    RemoveCoin("Orange Soda");
                    break;
                case "Root Beer":
                    Console.WriteLine("You have selected a Root Beer");
                    RemoveCoin("Root Beer");
                    break;
                default:
                    Console.WriteLine("This selection is not available");
                    break;
            }
        }
        public void RemoveSoda(string sodaType)
        {
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if (sodaMachine.inventory[i].name == sodaType)
                {
                    sodaMachine.inventory.RemoveAt(i);
                    break;
                }
            }

        }
    }
}
