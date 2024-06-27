using Microsoft.Data.SqlClient;

namespace UsandoDb.Db
{
    internal class Connection
    {
        private readonly string connectionString = "Data Source=GSANTOS\\SQLEXPRESS;Initial Catalog=TesteDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }

    }
}
