using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;

        public int NumberOfOrangeSoda
        {
            get
            {
                int numberOf = 0;
                foreach(Can soda in inventory)
                {
                    if(soda.name == "Orange Soda")
                    {
                        numberOf++;
                    }
                }
                return numberOf;
            }
        }

        public int NumberofCola
        {
            get
            {
                int numberof = 0;
                foreach (Can soda in inventory)
                {
                    if(soda.name == "Cola")
                    {
                        numberof++;
                    }
                }
                return numberof;
            }
        }
        public int NumberofRootBeer
        {
            get
            {
                int numberof = 0;
                foreach (Can soda in inventory)
                {
                    if(soda.name == "Root Beer")
                    {
                        numberof++;
                    }
                }
                return numberof;
            }
        }
        public SodaMachine()
        {
            register = new List<Coin>();
            for (int index = 0; index < 20; index++)
            {
                Quarter quarter = new Quarter();
                register.Add(quarter);
            }
            for (int index = 0; index < 10; index++)
            {
                Dime dime = new Dime();
                register.Add(dime);
            }
            for (int index = 0; index < 20; index++)
            {
                Nickle nickle = new Nickle();
                register.Add(nickle);
            }
            for (int index = 0; index < 50; index++)
            {
                Penny penny = new Penny();
                register.Add(penny);
            }

            inventory = new List<Can>();
            for (int index = 0; index < 20; index++)
            {
                Cola cola = new Cola();
                OrangeSoda orangeSoda = new OrangeSoda();
                RootBeer rootBeer = new RootBeer();

                inventory.Add(cola);
                inventory.Add(orangeSoda);
                inventory.Add(rootBeer);
            }
        }
    }
}
