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
        public EDocContext Create()
        {
            return new EDocContext(ConfigurationSettings.AppSettings["DbConnectionName"]);
        }
    }
}
