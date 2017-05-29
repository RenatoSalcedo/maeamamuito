using System;
using System.Data.SqlClient;
using System.Text;
using MaeAmaMuito.Core.Utility;
using MaeAmaMuito.Core.Model;
using MaeAmaMuito.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace MaeAmaMuito.Core.Repo
{
    public class AccountRepo : IAccountRepository<User>
    {
        private readonly SqlConnectionStringBuilder _sqlConnection;
        string _entity;
        public AccountRepo(IOptions<SqlConnectionStringBuilder> sqlConnection) 
        {
            _sqlConnection = sqlConnection.Value;
            _entity = typeof(User).Name.ToUpper();
        }

        User IAccountRepository<User>.LogIn(User user)
        {
            return logInVerify(user);
        }

        private User logInVerify(User user)
        {
            User logued = new User();

            try
            {
                using (SqlConnection conn = new SqlConnection(_sqlConnection.ToString()))
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
        }

        void IAccountRepository<User>.LogOut(User user)
        {
            logOutVerify(user);
        }

        private void logOutVerify(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_sqlConnection.ToString()))
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