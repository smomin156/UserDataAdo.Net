using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DbLibrary
{
    public class DataStore
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public DataStore(string connectionstring)
        {

            connection = new SqlConnection(connectionstring);
        }

        public UserRoles GetUserRole(string username, string password)
         {
            try
            {
                string sql = "Select userrole from userdata where username=@username and password=@password";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string result = (string)command.ExecuteScalar();
                if (result != null)
                {
                    UserRoles role = (UserRoles)Enum.Parse(typeof(UserRoles), result);
                    return role;
                }
                else
                {
                    throw new IncorrectException("Username password incorrect");
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
         }

    }
    public enum UserRoles{
        ADMIN,
        USER
    }
}
