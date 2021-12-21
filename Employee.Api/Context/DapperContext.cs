using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeApi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration config;
        private readonly string connString;

        public DapperContext(IConfiguration configuration)
        {
            config = configuration;
            connString = config.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(connString);

    }
}
