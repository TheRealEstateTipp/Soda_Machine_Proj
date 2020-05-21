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
            Can selectedCan;
            selectedCan = SelectSoda();
            double totalRegisterValue;
            totalRegisterValue = 0;
            double totalPayment = GetPayment(selectedCan.Cost);
            double changeAmount = 0;
         
            foreach (Coin changeInMachine in sodaMachine.register)
            {
                totalRegisterValue += changeInMachine.Value;
            }
            
            if (totalPayment > selectedCan.Cost)
            {
                if(totalPayment - selectedCan.Cost > totalRegisterValue)
                {
                   UI.PrintString("There is insufficient amount of change to return");
                    RefundChange(totalPayment);
                }
                else
                {
                    UI.PrintString("Please accept your change");
                    AcceptPayment(totalPayment);
                    backpack.cans.Add(selectedCan);
                    RefundChange(changeAmount);
                }
            } 
            else if (totalPayment < selectedCan.Cost)
            {
                UI.PrintString("You have insufficient funds for this purchase. Please accept your change");
                RefundChange(totalPayment);
            }
            else if(totalPayment == selectedCan.Cost)
            {
               UI.PrintString("Please remove your soda");
                backpack.cans.Add(selectedCan);
                AcceptPayment(totalPayment);
            }
         
        }


        public void AcceptPayment(double paymentAmount)
        {
            bool hasQuartersLeft = true;
            bool hasDimesLeft = true;
            bool hasNicklesLeft = true;
            bool hasPenniesLeft = true;
            while (paymentAmount > 0)
            {
                if (paymentAmount > 0.25 && hasQuartersLeft)
                {
                    Coin CoinfromPayment = GetCoinFromRegister("Quarter");
                    if (CoinfromPayment == null)
                    {
                        hasQuartersLeft = false;
                    }
                    else
                    {
                        sodaMachine.register.Add(CoinfromPayment);
                    }
                }
                else if (paymentAmount > 0.10 && hasDimesLeft)
                {
                    Coin CoinfromPayment = GetCoinFromRegister("Dime");
                    if (CoinfromPayment == null)
                    {
                        hasDimesLeft = false;
                    }
                    else
                    {
                        sodaMachine.register.Add(CoinfromPayment);
                    }
                }
                else if (paymentAmount > 0.05 && hasNicklesLeft)
                {
                    Coin CoinfromPayment = GetCoinFromRegister("Nickle");
                    if (CoinfromPayment == null)
                    {
                        hasNicklesLeft = false;
                    }
                    else
                    {
                        sodaMachine.register.Add(CoinfromPayment);
                    }
                }
                else if (paymentAmount > 0.01 && hasPenniesLeft)
                {
                    Coin CoinfromPayment = GetCoinFromRegister("Penny");
                    if (CoinfromPayment == null)
                    {
                        hasPenniesLeft = false;
                    }
                    else
                    {
                        sodaMachine.register.Add(CoinfromPayment);
                    }
                }
            }
        }
        public Coin GetCoinFromPayment(string coinToGet)
        {
            Coin coin = null;
            foreach (Coin coinInPayment in payment)
            {
                if (coinInPayment.name == coinToGet)
                {
                    coin = coinInPayment;
                    break;
                }
            }
            payment.Remove(coin);
            return coin;
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
                string coin = UI.GetUsertInput("Pease enter the coin");
                //Console.WriteLine("Please Choose Your Coin");
                //string coin = Console.ReadLine();

                switch (coin)
                {
                    case "Quarter":
                        UI.PrintString("You have selected a Quarter");
                        totalCoinValue += RemoveCoin("Quarter");
                        break;
                    case "Dime":
                        UI.PrintString("You have selected a Dime");
                        totalCoinValue += RemoveCoin("Dime");
                        break;
                    case "Nickle":
                        UI.PrintString("You have selected a Nickle");
                        totalCoinValue += RemoveCoin("Nickle");
                        break;
                    case "Penny":
                        UI.PrintString("You have selected a Penny");
                        totalCoinValue += RemoveCoin("Penny");
                        break;
                    default:
                        UI.PrintString("This Coin is not available");
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

        public Can SelectSoda()

        {
            while (true)
            {
                //Console.WriteLine("Please Select Your Desired Soda");
                //Console.ReadLine();
                string soda = UI.GetUsertInput("Please enter Your Desired Soda"); 

                switch (soda)
                {
                    case "Cola":
                        if(sodaMachine.NumberofCola > 0)
                        {
                            UI.PrintString("You have selected a Cola");
                            return RemoveSoda("Cola");
                        }
                        else
                        {
                            UI.PrintString("We do not have sufficient amount of Cola");
                            break;
                        }
                       
                    case "Orange Soda":
                        if(sodaMachine.NumberOfOrangeSoda > 0)
                        {
                            UI.PrintString("You have selected a Orange Soda");
                            return RemoveSoda("Orange Soda");
                        }
                        else
                        {
                            UI.PrintString("We do not have a sufficient amount of Orange Soda");
                            break;
                        }
                    case "Root Beer":
                        if(sodaMachine.NumberofRootBeer > 0)
                        {
                            UI.PrintString("You have selected a Root Beer");
                            return RemoveSoda("Root Beer");
                        }
                        else
                        {
                            UI.PrintString("We do not have a sufficient amount of Orange Soda");
                            break;
                        }
                    default:
                        UI.PrintString("This selection is not available. Please try again.");
                        break;
                }

            }
        }
        public Can RemoveSoda(string sodaType)
        {
            Can returnCan = null;
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if (sodaMachine.inventory[i].name == sodaType)
                {
                    returnCan = sodaMachine.inventory[i];
                    sodaMachine.inventory.RemoveAt(i);
                    break;
                }
            }
            return returnCan;
        }
   
    }
}
