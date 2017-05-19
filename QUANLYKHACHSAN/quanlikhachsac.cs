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
    public partial class quanlikhachsac : Form
    {
        string strConn = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
        SqlConnection conn;
        public string ten;
        public string matkhau;
        //string picAnh = @"C:\Users\Phuong Linh\Desktop\a.jpg";

        public quanlikhachsac()
        {
            InitializeComponent();
        }
        string Gender = "";
        public quanlikhachsac(string _ten, string _matkhau) : this()
        {
            ten = _ten;
            matkhau = _matkhau;

            textBox6.Text = ten;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void quanlikhachsac_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_nhanvienhienthi", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@Ma", ten);
            cmd.Parameters.Add(p);
            SqlDataAdapter dg = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dg.Fill(dt);
            if (ten != null)
            {
                textBox7.Text = Convert.ToString(dt.Rows[0]["TENNV"]);
                textBox9.Text = Convert.ToString(dt.Rows[0]["DIACHI"]);
                textBox8.Text = Convert.ToString(dt.Rows[0]["SDT"]);
                Gender = Convert.ToString(dt.Rows[0]["GIOITINH"]);
                if (Gender == "Nam")
                {
                    radioButton3.Checked = true;
                }
                else
                {
                    radioButton4.Checked = true;
                }
                string picAnh = Convert.ToString(dt.Rows[0]["PICTURE"]);
                if (!string.IsNullOrEmpty(picAnh))
                    pictureBox9.Image = Image.FromFile(picAnh);
                else
                    pictureBox9.Image = Image.FromFile(@"C:\Users\Phuong Linh\Desktop\icon\a.jpg");

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            quanlykhachhang kh = new quanlykhachhang();
            kh.Show();
            quanlikhachsac fr2 = new quanlikhachsac();
            fr2.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            quanlythuetra kh = new quanlythuetra();
            kh.Show();
            quanlikhachsac fr2 = new quanlikhachsac();
            fr2.Hide();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            quanlyphong kh = new quanlyphong();
            kh.Show();
            quanlikhachsac fr2 = new quanlikhachsac();
            fr2.Hide();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Quanlydichvu kh = new Quanlydichvu();
            kh.Show();
            quanlikhachsac fr2 = new quanlikhachsac();
            fr2.Hide();

        }

        private void btsuattnv_Click(object sender, EventArgs e)
        {
            quanlynv kh = new quanlynv();
            kh.Show();
            quanlikhachsac fr2 = new quanlikhachsac();
            fr2.Hide();

        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
