using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> coins;
        public Card card;

        public Wallet()
        {
            coins = new List<Coin>();
            for (int index = 0; index < 16; index++)
            {
                Quarter quarter = new Quarter();
                coins.Add(quarter);
            }
            for (int index = 0; index < 10; index++) 
            {
                Dime dime = new Dime();
                coins.Add(dime);
            }
            for (int index = 0; index < 10; index++)
            {
                Nickle nickle = new Nickle();
                coins.Add(nickle);
            }
            for (int index = 0; index < 50; indexx++)
            {
                Penny penny = new Penny();
                coins.Add(penny);
            }

            card = new Card();
        }   
    }
}