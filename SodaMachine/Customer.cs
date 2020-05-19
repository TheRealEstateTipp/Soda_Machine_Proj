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

        public Customer (Wallet wallet, BackPack backPack)
        {
            this wallet = wallet;
            backpack = backPack;

        }
    }
}
