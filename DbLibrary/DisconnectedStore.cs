using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DbLibrary
{
    public class DisconnectedStore
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet;
        public DisconnectedStore(string conectionstring)
        {
            connection = new SqlConnection(conectionstring);
            string sql = "select * from userdata";
            adapter = new SqlDataAdapter(sql, conectionstring);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "userdata");

        }

        public UserRoles CheckUser(string username,string password)
        {
            DataRow[] dw=dataSet.Tables["userdata"].Select($"username='{username}' and password='{password}'");
            string res = dw[0][2].ToString();
            UserRoles role = (UserRoles)Enum.Parse(typeof(UserRoles), res);
            return role;

        }
    }
}
