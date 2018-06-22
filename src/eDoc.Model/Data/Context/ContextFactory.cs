using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Context
{
    public class ContextFactory : IDbContextFactory<EDocContext>
    {
        private string _connectionStringName;
        public ContextFactory(string connString)
        {
            if (String.IsNullOrEmpty(connString))
                throw new ArgumentException();

            _connectionStringName = connString;
        }
        [Obsolete("Use for update-database PMC commands")]
        public ContextFactory()
        {
        }
        [Obsolete("Use for update-database PMC commands")]
        public EDocContext Create()
        {
            return new EDocContext(ConfigurationSettings.AppSettings["DbConnectionName"]);
        }
    }
}
