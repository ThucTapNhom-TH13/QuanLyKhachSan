﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlConnect
    {
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=BUMBLEBEE\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True");
            return conn;
        }
        
    }
}
