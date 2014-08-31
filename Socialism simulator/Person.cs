using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialism_simulator
{
    class Person
    {
        public double price;
        public int bought = 0;

        public int perClick;
        public int perSecond;

        

        public Person(double price)
        {
            this.price = price;
        }

        public Person(double price, int perClick, int perSecond)
        {
            this.price = price;
            this.perClick = perClick;
            this.perSecond = perSecond;
        }

        public void buyPerson()
        {
            if (GlobalItems.yourCash >= price)
            {

                GlobalItems.plnPerClick += perClick;
                GlobalItems.plnPerSecond += perSecond;
                GlobalItems.yourCash -= price;
                bought += 1;
                price = price + (price * 0.10);

            }
        }

        public bool tmp = false;

        public bool enterSocialism()
        {
            if (GlobalItems.yourCash >= price)
            {
                GlobalItems.yourCash -= price;
                return tmp = true;
            }
            return tmp = false;
        }

        public void fiscalControl()
        {
            if (GlobalItems.yourCash >= price)
            {
                GlobalItems.yourCash -= price;
                GlobalItems.totalEarned += 1000000;
                GlobalItems.plnPerClick *= 2;
                GlobalItems.plnPerSecond *= 2;
            }
        }
    }
}
