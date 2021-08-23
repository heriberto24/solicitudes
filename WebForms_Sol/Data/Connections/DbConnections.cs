using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Connections
{
    public static class DbConnections
    {
        private static readonly string host = @"DESKTOP-2TONF1T\";
        private static readonly string database = "SolicitudesDB";
        private static readonly string username = "root";
        private static readonly string password = "admin123";

        public static string DbConnection = $"Data Source={host};Initial Catalog={database};User ID={username};Password={password}";
    }
}
