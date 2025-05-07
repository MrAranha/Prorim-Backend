using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace FbSoft_Services.Services
{
    public sealed class DbSession : IDisposable
    {
        public MySqlConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; set; }
        private readonly IConfiguration _configuration;

        public DbSession(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = new MySqlConnection();
            Connection.ConnectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
