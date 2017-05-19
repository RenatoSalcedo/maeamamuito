using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using maeamamuito.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace maeamamuito.Core.Repo
{
    public class SqlRepository<T> : ISqlRepository<T>
        where T : new()
    {
        private readonly SqlConnectionStringBuilder _sqlConnection;
        string _entity;
        public SqlRepository(IOptions<SqlConnectionStringBuilder> sqlConnection) 
        {
            _sqlConnection = sqlConnection.Value;
            _entity = typeof(T).Name.ToUpper();
        }

        T ISqlRepository<T>.Create(T item)
        {
            throw new NotImplementedException();
        }

        bool ISqlRepository<T>.Exists(string objectId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> ISqlRepository<T>.FindAll()
        {
            IEnumerable<T> results = null;

            using (SqlConnection conn = new SqlConnection(_sqlConnection.ToString()))
            { 
                conn.Open();
                results = conn.Query<T>(string.Format("EXEC DBO.PR_FINDALL_{0} ", _entity));
                conn.Close();
            }

            return results;
        }

        IEnumerable<T> ISqlRepository<T>.FindAll(int id)
        {
            IEnumerable<T> results = null;

            using (SqlConnection conn = new SqlConnection(_sqlConnection.ToString()))
            { 
                conn.Open();
                string proc = string.Format("EXEC DBO.PR_FINDALL_{0} @id = N'{1}'"
                                            ,_entity, id);
                results = conn.Query<T>(proc);
                conn.Close();
            }
            
            return results;
        }

        T ISqlRepository<T>.FindEntity(int id)
        {
            T result = default(T);

            using (SqlConnection conn = new SqlConnection(_sqlConnection.ToString()))
            { 
                conn.Open();
                string proc = string.Format("EXEC DBO.PR_FINDONE_{0} @id = N'{1}'"
                                            ,_entity, id);
                List<T> results = conn.Query<T>(proc).AsList();
                if (results.Count > 0)
                    result = results[0];
                conn.Close();
            }

            return result;
        }

        T ISqlRepository<T>.FindEntity(string login)
        {
            throw new NotImplementedException();
        }

        void ISqlRepository<T>.Remove(string objectId)
        {
            throw new NotImplementedException();
        }

        void ISqlRepository<T>.Update(string objectId, T entity)
        {
            throw new NotImplementedException();
        }
    }
}