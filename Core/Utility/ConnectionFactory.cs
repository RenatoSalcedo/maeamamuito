using System.Data.SqlClient;

namespace MaeAmaMuito.Core.Utility
{
    public class ConnectionFactory
    {
        public SqlConnectionStringBuilder ConnectionString
        {
            get  {

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                
                builder.DataSource = "srv-mam.database.windows.net";   
                builder.UserID = "adm-mam";              
                builder.Password = "Rojorele9999";      
                builder.InitialCatalog = "BD_MAM";

                return builder;
            }
        }
    }
}