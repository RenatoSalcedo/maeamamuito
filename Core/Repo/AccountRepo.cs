using System;
using System.Data.SqlClient;
using System.Text;
using MaeAmaMuito.Core.Utility;
using MaeAmaMuito.Core.Model;

namespace MaeAmaMuito.Core.Repo
{
    public class AccountRepo
    {
        public SqlConnection Connection
        {
            get  {

                ConnectionFactory connFact = new ConnectionFactory();
                return new SqlConnection(connFact.ConnectionString.ToString());
            }
        }

        public User logIn(User user)
        {
            return logInVerify(user);
        }

        public void logOut(User user)
        {
            logOutVerify(user);
        }

        private User logInVerify(User user)
        {
            User logued = new User();

            try
            {
                using (SqlConnection conn = Connection)
                { 
                    StringBuilder SQL = new StringBuilder();

                    SQL.Append("EXEC DBO.PRC_LOGIN ");
                    SQL.AppendLine("@UserName = '" + user.UserName + "'");
                    SQL.AppendLine(",@Password = '" + user.Password + "'");

                    conn.Open();

                
                    using (SqlCommand command = new SqlCommand(SQL.ToString(), conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()){
                                logued.UserName = reader.GetString(0);
                                logued.Password = reader.GetString(1);
                                logued.Logued = reader.GetBoolean(2);
                            }
                        }
                    }
                }

                return logued;
            }
            catch (Exception excecao)
            {
                throw excecao;
            }
        }private void logOutVerify(User user)
        {
            try
            {
                using (SqlConnection conn = Connection)
                { 
                    StringBuilder SQL = new StringBuilder();

                    SQL.Append("EXEC DBO.PRC_LOGOUT ");
                    SQL.AppendLine("@UserName = '" + user.UserName + "'");
                    SQL.AppendLine(",@Password = '" + user.Password + "'");

                    conn.Open();

                
                    using (SqlCommand command = new SqlCommand(SQL.ToString(), conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception excecao)
            {
                throw excecao;
            }
        }
    }
}