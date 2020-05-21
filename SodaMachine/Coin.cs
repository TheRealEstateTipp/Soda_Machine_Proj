using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Coin
    {
        protected double value;
        public double Value
        {
            get
            {
                return value;
            }
           
        }
        public string name;

       
       
        
    }
}
