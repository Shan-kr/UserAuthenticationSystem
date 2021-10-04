using Mark2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mark2.Services.Data
{
    public class SecurityDAO
    {
        string connnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {
            bool success = false;

            string queryString = "SELECT * FROM dbo.Users WHERE username=@Username AND password=@Password";

            using (SqlConnection connection = new SqlConnection(connnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        success = true;
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        internal bool Signup(UserModel user)
        {

            bool success = false;
            if (FindByUser(user))
            {
                return success;
            }
            string queryString = "INSERT INTO dbo.Users (username,password) VALUES (@Username,@Password)";

            using (SqlConnection connection = new SqlConnection(connnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                        int rows = command.ExecuteNonQuery();
                     if (rows >= 1)
                      success = true;
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;

        }
    }
}