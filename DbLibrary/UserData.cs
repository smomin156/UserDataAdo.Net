using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary
{
    public class UserData
    {
        string Username { get; set; }
        string Password { get; set; }
        string Userrole { get; set; }

        public override string ToString()
        {
            return string.Format($"username : {Username} Password : {Password} Role:{Userrole}");
        }
    }
}
