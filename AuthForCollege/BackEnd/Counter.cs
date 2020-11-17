using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForCollege.BackEnd
{
    class Counter
    {

        public int numberSecond { get; private set; }
        public int counter { get; private set; } 
        
        public Counter()
        {
            counter = 0;
            numberSecond = 60; 
        }

        public bool IsAddCount()
        {
            if (counter == 3)
            {
                counter = 0;
                return false;
            }
            counter++;
            return true;
        }

        public bool IsMinusSeconds()
        {
            if(numberSecond == 0)
            {
                numberSecond = 60;
                return false;
            }           
            numberSecond--;
            return true;
        }
    }
}
