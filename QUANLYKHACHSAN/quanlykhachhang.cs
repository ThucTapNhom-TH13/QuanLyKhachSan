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

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMakh.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["MAKH"].Value);
            txtTenkh.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["TENKH"].Value);
            Gender = Convert.ToString(dataGridView1.CurrentRow.Cells["GIOITINH"].Value);
            if (Gender == "true")
            {
                rabNam.Checked = true;
            }
            else
            {

                rabNu.Checked = true;
            }



            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["SDT"].Value);
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["CMND"].Value);
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["QUOCTICH"].Value);
            
        }
    }
}
