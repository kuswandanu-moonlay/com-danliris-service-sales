using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib
{
    public class LocalMerchandiserDbContext : ILocalMerchandiserDbContext
    {
        private readonly SqlConnection _connection;

        public LocalMerchandiserDbContext(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }

        private SqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            return new SqlConnection(connectionString);
        }

        public IDataReader ExecuteReader(string query, ICollection<SqlParameter> parameters)
        {
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                return reader;
            }
        }
    }

    public interface ILocalMerchandiserDbContext
    {
        IDataReader ExecuteReader(string query, ICollection<SqlParameter> parameters);
    }

}
