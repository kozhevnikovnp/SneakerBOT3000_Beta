using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBot
{
    [Serializable]
    class Task
    {
        int Retailers;
        public string Task_Name;
        public string Keywords;
        public string Link;
        int card;
        public string time;
        public string status;
        public Task(int a, int car, string b, string c, string d, string t)
        {
            Retailers = a;
            Task_Name = b;
            Keywords = c;
            Link = d;
            card = car;
            time = t;
            status = "waiting for a resource";
        }

    }
}
