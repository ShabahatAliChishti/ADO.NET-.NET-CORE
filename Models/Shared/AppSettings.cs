using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO.NET_.NET_CORE.Models.Shared
{
    public class AppSettings
    {
        //globally declare connection string
        public static string ConnectionString ()
        {
            return @"Data Source=DESKTOP-JH5DU96;Initial Catalog=TestDb;Integrated Security=True";
        }
    }
}
