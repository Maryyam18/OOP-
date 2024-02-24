using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.BIL
{
    internal class Ship
    {
        public int shipLatitude;
        public int shipLongitude;

        public Ship(int shipLatitude, int shipLongitude)
        {
            this.shipLatitude = shipLatitude;
            this.shipLongitude = shipLongitude;
        }
    }
}
