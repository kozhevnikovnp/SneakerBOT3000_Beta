using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBot
{
    [Serializable]
    class Profile
    {
        public string name;
        public string surname;
        public string email;
        public string phone;
        public string zip_code;
        public string country;
        public string state;
        public string adress;
        public string city;
        public string photo;
        public List<ClardPerson> card = new List<ClardPerson>();
        public List<Task> tasks = new List<Task>();

        public Profile(string a, string b, string c, string d, string e, string f, string j, string i, string k)
        {
            name = a;
            surname = b;
            email = c;
            phone = d;
            zip_code = e;
            country = f;
            state = j;
            city = i;
            adress = k;
        }

        public void AddCard(string l, string m, string n, string o)
        {
            card.Add(new ClardPerson(l, m, n, o));
        }

        public void AddTask(int l, int car, string m, string n, string o, string time)
        {
            tasks.Add(new Task(l,car, m, n, o, time));
        }
    }
}
