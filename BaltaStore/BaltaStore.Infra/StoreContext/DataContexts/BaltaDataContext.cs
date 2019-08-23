using System;
using System.Data;
using Npgsql;

namespace BaltaStore.Infra.StoreContext.DataContext
{
    public class BaltaDataContext : IDisposable
    {
        private const string ConnectionString = @"User ID=root;Password=myPassword;
            Host=localhost;Port=5432;Database=myDataBase;
            Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";

        public IDbConnection Connection {get; set;}

        public BaltaDataContext()
        {
            Connection = new NpgsqlConnection(ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }

}