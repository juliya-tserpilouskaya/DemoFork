using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;

namespace BulbaCourses.PracticalMaterialsTests.Data.Config
{
    public class DbConfig_Test : DbConfiguration
    {
        private const string CONNECTION_NAME = "mssqllocaldb";

        public DbConfig_Test()
        {            
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);

            SetProviderFactory(SqlProviderServices.ProviderInvariantName, SqlClientFactory.Instance);

            SetDefaultConnectionFactory(new LocalDbConnectionFactory(CONNECTION_NAME));
        }
    }
}
