using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial
{
    public class DapperTutorialConfiguration
    {
        public DatabaseConfiguration Database { get; set; }
    }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
