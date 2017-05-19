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
    public partial class Quanlydichvu : Form
    {
        public string strConnection = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
        public SqlConnection conn = null;
        public Quanlydichvu()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM DICHVU", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Quanlydichvu_Load(object sender, EventArgs e)
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
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["GIATIEN"].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["MADV"].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["TENDV"].Value);

            comboBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["SOLUONG"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_dv", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TEN", textBox3.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@GIA", textBox1.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@SOLUONG", comboBox1.Text);
                cmd.Parameters.Add(p);

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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Suadv", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@MA", textBox2.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@TEN", textBox3.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@Gia", textBox1.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@SOLUONG", comboBox1.Text);
            cmd.Parameters.Add(p);
            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Sửa thành công!");
                loadData();
            }
            else MessageBox.Show("Không sửa được!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa bản ghi đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("sp_Xoadv", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@Ma", textBox2.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    loadData();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                }
                else MessageBox.Show("Không thể xóa bản ghi hiện thời!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
