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
            double totalRegisterValue;
            totalRegisterValue = 0;
            double totalPayment = GetPayment(TotalCost);
            double changeAmount = 0;
            

            foreach (Coin changeInMachine in sodaMachine.register)
            {
                totalRegisterValue += changeInMachine.Value;
            }
            
            if (totalPayment > TotalCost)
            {
                if(totalPayment - TotalCost > totalRegisterValue)
                {
                    Console.WriteLine("There is insufficient amount of change to return");
                    RefundChange(totalPayment);
                }
                else
                {
                    Console.WriteLine("Please accept your change");
                    RefundChange(changeAmount);
                }
            } 
            else if (totalPayment < TotalCost)
            {
                Console.WriteLine("You have insufficient funds for this purchase. Please accept your change");
                RefundChange(totalPayment);
            }
        }
        
        public void RefundChange(double changeAmount)
        {
            bool hasQuartersLeft = true;
            bool hasDimesLeft = true;
            bool hasNicklesLeft = true;
            bool hasPenniesLeft = true;
            while (changeAmount > 0)
            {
                if (changeAmount > 0.25 && hasQuartersLeft)
                {
                    Coin CoinFromRegister  = GetCoinFromRegister("Quarter");
                    if(CoinFromRegister  == null)
                    {
                        hasQuartersLeft = false;
                    }
                    else
                    {
                        wallet.coins.Add(CoinFromRegister);
                    }
                }
                else if (changeAmount > 0.10 && hasDimesLeft) 
                {
                    Coin CoinFromRegister = GetCoinFromRegister("Dime");
                    if(CoinFromRegister == null)
                    {
                        hasDimesLeft = false;
                    }
                    else
                    {
                        wallet.coins.Add(CoinFromRegister);
                    }
                }
                else if (changeAmount > 0.05 && hasNicklesLeft)
                {
                    Coin CoinFromRegister = GetCoinFromRegister("Nickle");
                    if(CoinFromRegister == null)
                    {
                        hasNicklesLeft = false;
                    }
                    else
                    {
                        wallet.coins.Add(CoinFromRegister);
                    }
                }
                else if(changeAmount > 0.01 && hasPenniesLeft)
                {
                    Coin CoinFromRegister = GetCoinFromRegister("Penny");
                    if(CoinFromRegister == null)
                    {
                        hasPenniesLeft = false;
                    }
                    else
                    {
                        wallet.coins.Add(CoinFromRegister);
                    }
                }
            }
        }

        public Coin GetCoinFromRegister(string coinToGet)
        {
            Coin coin = null; 
            foreach(Coin coinInRegister in sodaMachine.register)
            {
                if(coinInRegister.name == coinToGet)
                {
                    coin = coinInRegister;
                    break;
                }
            }
            sodaMachine.register.Remove(coin);
            return coin;
        }
        public double GetPayment(double TotalCost)
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
                        totalCoinValue += RemoveCoin("Quarter");
                        break;
                    case "Dime":
                        Console.WriteLine("You have selected a Dime");
                        totalCoinValue += RemoveCoin("Dime");
                        break;
                    case "Nickle":
                        Console.WriteLine("You have selected a Nickle");
                        totalCoinValue += RemoveCoin("Nickle");
                        break;
                    case "Penny":
                        Console.WriteLine("You have selected a Penny");
                        totalCoinValue += RemoveCoin("Penny");
                        break;
                    default:
                        Console.WriteLine("This Coin is not available");
                        break;

                }                                                                                                     
         }
            return totalCoinValue;   
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
