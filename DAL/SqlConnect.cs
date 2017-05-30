using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class SqlConnect
    {
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-6ABMGHP\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True");
            return conn;
        }
        
    }
}
