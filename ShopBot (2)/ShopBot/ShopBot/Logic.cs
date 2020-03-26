using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace ShopBot
{
    [Serializable]
    class Path
    {
        public string path;
        public string file;

        public Path()
        {

        }
    }

    class Logic
    {
        public static List<Profile> person = new List<Profile>();
        public static List<string> retailers = new List<string> { "KITH", "Bodega", "YeezySupply","Deadstock", "DoverStreetMarket" };
        public static Path pathFile = new Path();

        public static void ChangeProfile(int ind, string a, string b, string c, string d, string e, string f, string j, string i, string k)
        {
            person[ind].name = a;
            person[ind].surname = b;
            person[ind].email = c;
            person[ind].phone = d;
            person[ind].zip_code = e;
            person[ind].country = f;
            person[ind].state = j;
            person[ind].city = i;
            person[ind].adress = k;
        }

        public static void AddProfile(string a, string b, string c, string d, string e, string f, string j, string i, string k)
        {
            person.Add(new Profile(a,b,c,d,e,f,j,i,k));
        }

        public static void python(int ind, int car, int i, string a, string b, string c, string time)
        {
            Thread at = new Thread(() => AddTask(ind, car, i, a, b,  c, time));
            at.Start();
        }

        public static string splitNUm(string s)
        {
            //олдскул версия
            string rez = "";
            for(int i=0; i < s.Length;i++)
            {
                if(s[i]>='0' && s[i] <= '9')
                {
                    rez += s[i];
                }
            }
            
            return rez;
        }

        // здеся, колян, для тебя, эта функция у нас делает заказ как оно вызывается тебя не особо волнует
        public static void AddTask(int ind, int car, int i, string a, string b, string c, string time)
        {
            person[ind].AddTask(i, car, a, b, c, time);
            int tas = person[ind].tasks.Count()-1;
            SaveProfiles();
            GetListProfiles();

            try
            {
                var psi = new ProcessStartInfo();
                //psi.FileName = @"C:\Users\kingdoom\AppData\Local\Programs\Python\Python38-32\python.exe";
                psi.FileName = Logic.pathFile.path;

                //var script = @"D:\Учеба\Перлов\ShopBot\ShopBot\SneakerBot_A.py";
                var script = Logic.pathFile.file;

                // недостающие поля с картой
                //единственное, придется наверное просплитить по пробелам карту и дату, как то распарсить, по скольку 
                //карта хранится в виде "0000 0000 0000 0000"
                // дата хранится в виде "00/00"
                //функция для сплита splitNUm
                //person[ind].card[car].cardNumber
                //person[ind].card[car].date
                //person[ind].card[car].holder
                //person[ind].card[car].cvv

                psi.Arguments = $"\"{script}\" \"{b}\" \"{person[ind].name}\" \"{person[ind].surname}\" " +
                   $"\"{person[ind].email}\" \"{person[ind].phone}\" \"{person[ind].zip_code}\" \"{person[ind].country}\" " +
                   $"\"{person[ind].state}\" \"{person[ind].city}\" \"{person[ind].adress}\" \"{person[ind].card[car].cardNumber}\" \"{person[ind].card[car].holder}\" \"{person[ind].card[car].date}\" \"{person[ind].card[car].cvv}\"";

                psi.UseShellExecute = false;
                psi.CreateNoWindow = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                var err = "";
                var rez = "";

                using (var proc = Process.Start(psi))
                {
                    err = proc.StandardError.ReadToEnd();
                    rez = proc.StandardOutput.ReadToEnd();
                }
                //эта хуета кидает нам ошибку, если что-то не так, но тоже тебя особо не ебет
                MainWindow.errorPy(err);
                if (rez == "Item found")
                {
                    person[ind].tasks[tas].status = "buying process";
                }
                else
                {
                    person[ind].tasks[tas].status = "error";
                }

            }catch (Exception e)
            {
                MainWindow.errorPy(e.Message);
                person[ind].tasks[tas].status = "error";
            }
            SaveProfiles();
            GetListProfiles();
        }

        public static void ChangePhoto(int ind, string sour)
        {
            person[ind].photo = sour;
        }

        public static void DeleteCard(int ind, int prof)
        {
            person[prof].card.RemoveAt(ind);
            SaveProfiles();
            GetListProfiles();
        }

        public static void DeleteProfile(int ind)
        {
            person.RemoveAt(ind);
            SaveProfiles();
            GetListProfiles();
        }

        public static void SaveProfiles()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("profile.dat", FileMode.Create))
            {
                formatter.Serialize(fs, person);
            }
        }

        public static bool GetListProfiles()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("profile.dat", FileMode.Open))
                {
                    person = (List<Profile>)formatter.Deserialize(fs);
                }
            } catch (Exception e)
            {
                return false;
            }
            
            if(person.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void SavePath()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("pathFile.dat", FileMode.Create))
            {
                formatter.Serialize(fs, pathFile);
            }
        }

        public static bool GetPath()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("pathFile.dat", FileMode.Open))
                {
                    pathFile = (Path)formatter.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            if (pathFile == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
