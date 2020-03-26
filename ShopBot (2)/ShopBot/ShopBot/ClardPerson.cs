using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBot
{
    [Serializable]
    class ClardPerson
    {
        public string cardNumber;
        public string date;
        public string holder;
        public string cvv;

        public ClardPerson(string a, string b, string c, string d)
        {
            cardNumber = a;
            date = b;
            holder = c;
            cvv = d;
        }
    }
}
