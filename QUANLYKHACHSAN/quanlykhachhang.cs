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
        public string strConnection = @"Data Source=BUMBLEBEE\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
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

        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_phong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TENKH", txtTenkh.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@SDT", textBox3.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@CMND", textBox4.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@QUOCTICH", textBox5.Text);
                cmd.Parameters.Add(p);
               
                if (rabNam.Checked == true)
                {
                    p = new SqlParameter("@GIOITINH", rabNam.Checked);
                    cmd.Parameters.Add(p);
                }
                else
                {
                    p = new SqlParameter("@TINHTRANG", rabNu.Checked);
                    cmd.Parameters.Add(p);
                }



                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    loadData();
                }

                else MessageBox.Show("Không thể thêm mới");
            }
            catch
            {

            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Suakh", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@MAKH", txtMakh.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@TENKH", txtTenkh.Text);
            cmd.Parameters.Add(p);


            p = new SqlParameter("@SDT", textBox3.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@CMND", textBox4.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@QUOCTICH", textBox5.Text);
            cmd.Parameters.Add(p);
            if (rabNam.Checked == true)
            {
                p = new SqlParameter("@GIOITINH", rabNam.Checked);
                cmd.Parameters.Add(p);
            }
            else
            {
                p = new SqlParameter("@GIOITINH", rabNu.Checked);
                cmd.Parameters.Add(p);
            }

            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Sửa thành công!");
                loadData();
            }
            else MessageBox.Show("Không sửa được!");
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa bản ghi đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("sp_Xoakh", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@Ma", txtMakh.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    loadData();
                    txtMakh.Text = "";
                   txtTenkh .Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    rabNam.Checked = false;
                    rabNu.Checked = false;

                }
                else MessageBox.Show("Không thể xóa bản ghi hiện thời!");
            }
        }
    }
}
