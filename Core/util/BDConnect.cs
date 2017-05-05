using System.Data;
using System.Data.SqlClient;

namespace oficial.Core.util
{
    class BDConnect
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand command = new SqlCommand();
        //SqlDataAdapter adapter = new SqlDataAdapter();

        void openConnection()
        {
            conn.ConnectionString = getConnectionString();
            conn.Open();
        }

        string getConnectionString()
        {
            return @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=mam;Data Source=WKSOSA0706";
        }

        /*public DataSet retornaDadosSQL(string comandoSQL)
        {
            openConnection();

            command.CommandText = comandoSQL;
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();

            adapter.SelectCommand = command;
            adapter.Fill(ds);

            closeConnection();

            return ds;
        }*/

        public void executaComandoSQL(string comandoSQL)
        {
            openConnection();

            command.CommandText = comandoSQL;
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            
            closeConnection();
        }

        void closeConnection()
        {
            conn.Close();
        }
    }
}