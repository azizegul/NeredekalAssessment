using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Infrastructure.Persistence.Settings
{
    public class MongoDbSettings
    {
        public string Connection { get; set; }

        public string DatabaseName { get; set; }
    }
}
