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
    public partial class quanlyphong : Form
    {
        public string strConnection = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
        public SqlConnection conn = null;
        string Gender = "";

        public quanlyphong()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM DATPHONG", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void quanlyphong_Load(object sender, EventArgs e)
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
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["MAPHONG"].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["TENPHONG"].Value);
            Gender = Convert.ToString(dataGridView1.CurrentRow.Cells["TINHTRANG"].Value);
            if (Gender == "true")
            {
                radioButton1.Checked = true;
            }
            else
            {

                radioButton1.Checked = false;
            }



            comboBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["LOAIPHONG"].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_phong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TENPHONG", textBox3.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@MALOAIPHONG", comboBox1.Text);
                cmd.Parameters.Add(p);
                if (radioButton1.Checked == true)
                {
                    p = new SqlParameter("@TINHTRANG", radioButton1.Checked);
                    cmd.Parameters.Add(p);
                }
                else
                {
                    p = new SqlParameter("@TINHTRANG", radioButton2.Checked);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_SuaPhong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@MAPHONG", textBox1.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@TENPHONG", textBox3.Text);
            cmd.Parameters.Add(p);


            p = new SqlParameter("@MALOAIPHONG", comboBox1.Text);
            cmd.Parameters.Add(p);
            if (radioButton1.Checked == true)
            {
                p = new SqlParameter("@TINHTRANG", radioButton1.Checked);
                cmd.Parameters.Add(p);
            }
            else
            {
                p = new SqlParameter("@TINHTRANG", radioButton2.Checked);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa bản ghi đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("sp_XoaPhong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@Ma", textBox1.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    loadData();
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;

                }
                else MessageBox.Show("Không thể xóa bản ghi hiện thời!");
            }
        }
    }
}
