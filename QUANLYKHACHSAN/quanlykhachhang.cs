using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYKHACHSAN
{
    public partial class quanlykhachhang : Form
    {
        public string strConnection = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
        public SqlConnection conn = null;
        string Gender = "";
        public quanlykhachhang()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM KHACHHANG", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void quanlykhachhang_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConnection);
            conn.Open();
            loadData();
        }
    }
}
