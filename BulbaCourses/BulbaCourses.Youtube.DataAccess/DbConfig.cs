using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.DataAccess
{
    public class DbConfig : DbConfiguration
    {
        private const string CONNECTION_NAME = "YoutubeDbConnection";
        public DbConfig()
        {
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
            SetProviderFactory(SqlProviderServices.ProviderInvariantName, SqlClientFactory.Instance);
            SetDefaultConnectionFactory(new LocalDbConnectionFactory(CONNECTION_NAME));
        }

    }
}
