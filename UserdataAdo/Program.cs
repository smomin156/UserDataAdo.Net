using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLibrary;
using System.Configuration;

namespace UserdataAdo
{
    class Program
    {
        DataStore dataStore = new DbLibrary.DataStore(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);
        DisconnectedStore disconnectedStore = new DbLibrary.DisconnectedStore(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            //program.TestUser(username,password);
            program.TestDisconnected(username, password);
            Console.ReadLine();
        }

        public void TestUser(string username,string password)
        {
            try
            {
                string res = (dataStore.GetUserRole(username, password)).ToString();
                Console.WriteLine("User Role is :" + res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void TestDisconnected(string username,string password)
        {
           string result=(disconnectedStore.CheckUser(username, password)).ToString();
           Console.WriteLine("User Role is :" + result);
        }
    }
}
