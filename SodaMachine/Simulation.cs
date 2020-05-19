using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;

        public Simulation( SodaMachine machine, Customer customer)
        {
            sodaMachine = machine;
            this.customer = customer;
        }
    }
}
