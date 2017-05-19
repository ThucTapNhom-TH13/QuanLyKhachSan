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
    public partial class quanlythuetra : Form
    {
        public string strConnection = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
        public SqlConnection conn= null;
        public string ten;
        public string matkhau;
        public quanlythuetra()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_datadv", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@Ma",comboBox8.Text);
                cmd.Parameters.Add(p);
                SqlDataAdapter dg = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dg.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch
            { }
           
            
            
        }



        private void loadDatadv()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TENDV FROM DICHVU", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox8.DataSource = dt;
            comboBox8.ValueMember = "TENDV";
            comboBox8.DisplayMember = "TENDV";
        }
       

        private void loadDatamakh()
        {
            SqlDataAdapter dgvi = new SqlDataAdapter("SELECT MAKH from KHACHHANG", conn);
            DataTable dtnv = new DataTable();
            dgvi.Fill(dtnv);
            comboBox4.DataSource = dtnv;
            comboBox5.DataSource = dtnv;
            comboBox5.ValueMember = "MAKH";
            comboBox5.DisplayMember = "MAKH";
            comboBox4.ValueMember = "MAKH";
            comboBox4.DisplayMember = "MAKH";
        }
        private void loadDataLoaiPhong()
        {
            SqlDataAdapter dgvi = new SqlDataAdapter("SELECT MALOAIPHONG,LOAIPHONG from LOAIPHONG", conn);
            DataTable dtnv = new DataTable();
            dgvi.Fill(dtnv);
            comboBox1.DataSource = dtnv;
            comboBox1.ValueMember = "MALOAIPHONG";
            comboBox1.DisplayMember = "LOAIPHONG";
        }
        private void loadDatatenkh()
        {
            SqlDataAdapter dgvtnv = new SqlDataAdapter("SELECT MAKH,TENKH from KHACHHANG", conn);
            DataTable dttennv = new DataTable();
            dgvtnv.Fill(dttennv);
            comboBox7.DataSource = dttennv;
            comboBox11.DataSource = dttennv;
            comboBox11.ValueMember = "TENKH";
            comboBox11.DisplayMember = "TENKH";
            comboBox7.ValueMember = "TENKH";
            comboBox7.DisplayMember = "TENKH";
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form1 tc2 = new Form1();
            tc2.Show();
            //trangchu2 fr1 = new trangchu2();
            //fr1.Show();
            quanlythuetra fr2 = new quanlythuetra();
            fr2.Hide();


        }

        private void quanlythuetra_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConnection);
            conn.Open();
            loadDatadv();
            
            loadDataLoaiPhong();
            loadDatamakh();


        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_magvtengv", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@Ma", Convert.ToInt32(comboBox4.Text));
                cmd.Parameters.Add(p);
                SqlDataAdapter dg = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dg.Fill(dt);
                comboBox7.DataSource = dt;

                comboBox7.DisplayMember = "TENKH";
                comboBox7.ValueMember = "TENKH";
              
            }
            catch
            {  }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox8.Visible = true;
            comboBox9.Visible = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_loaiphongtien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@ten", comboBox1.Text);
                cmd.Parameters.Add(p);
                SqlDataAdapter dg = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dg.Fill(dt);
                comboBox10.DataSource = dt;
                comboBox12.DataSource = dt;
                comboBox12.DisplayMember = "MALOAIPHONG";
                comboBox12.ValueMember = "MALOAIPHONG";
                
                comboBox10.DisplayMember = "GIATIEN";
                comboBox10.ValueMember = "GIATIEN";

                SqlCommand cmd1 = new SqlCommand("sp_phongmalp", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@Ma", Convert.ToInt32(comboBox12.SelectedValue.ToString()));
                cmd.Parameters.Add(p1);
                SqlDataAdapter dg1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                dg1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "TENPHONG";
                comboBox2.ValueMember = "TENPHONG";

            }
            catch
            {
                
            }

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_magvtengv", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@Ma", Convert.ToInt32(comboBox5.Text));
                cmd.Parameters.Add(p);
                SqlDataAdapter dg = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dg.Fill(dt);
                comboBox11.DataSource = dt;
                
                comboBox11.DisplayMember = "TENKH";
                comboBox11.ValueMember = "TENKH";

                SqlCommand cmd1 = new SqlCommand("sp_tra1", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@Ma", Convert.ToInt32(comboBox5.Text));
                cmd1.Parameters.Add(p1);
                SqlDataAdapter dg1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                dg1.Fill(dt1);
                comboBox6.DataSource = dt1;

                comboBox6.DisplayMember = "MATP";
                comboBox6.ValueMember = "MATP";
                
                    
                    

                    //SqlCommand cmd2 = new SqlCommand("sp_tra3", conn);
                    //cmd2.CommandType = CommandType.StoredProcedure;
                    //SqlParameter p2 = new SqlParameter("@Ma", Convert.ToInt32(comboBox6.Text));
                    //cmd2.Parameters.Add(p2);
                    //SqlDataAdapter dg2 = new SqlDataAdapter(cmd2);
                    //DataTable dt2 = new DataTable();
                    //dg2.Fill(dt2);

                    //dateTimePicker2.Text = dt2.Rows[]




                }
            catch
            { }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("sp_phongmalp", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@Ma", Convert.ToInt32(comboBox12.SelectedValue.ToString()));
                cmd1.Parameters.Add(p1);
                SqlDataAdapter dg1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                dg1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "TENPHONG";
                comboBox2.ValueMember = "TENPHONG";
            }
            catch { }

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_dvtendv", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@ten", comboBox8.Text);
                cmd.Parameters.Add(p);
                SqlDataAdapter dg = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dg.Fill(dt);
                comboBox9.DataSource = dt;
                comboBox9.DisplayMember = "MADV";
                comboBox9.ValueMember = "MADV";
               


            }
            catch
            { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_luudk", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@makh", comboBox4.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@maphong", comboBox12.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@ngaydk", dateTimePicker1.Text);

            cmd.Parameters.Add(p);
            p = new SqlParameter("@madv", comboBox9.Text);

            cmd.Parameters.Add(p);
            p = new SqlParameter("@soluong", comboBox3.Text);

            cmd.Parameters.Add(p);

            // Thực thi thủ tục

            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thêm mới thành công");

                try
                {
                    conn = new SqlConnection(strConnection);
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("sp_datadv", conn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@ten", comboBox8.Text);
                    cmd1.Parameters.Add(p1);
                    SqlDataAdapter dg = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    dg.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch
                { }


            }

            else MessageBox.Show("Không thể thêm mới");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa bản ghi đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("SP_Xoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@Ma", Convert.ToInt32(comboBox9.Text));
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    
                   

                }
                else MessageBox.Show("Không thể xóa bản ghi hiện thời!");
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("execute sp_tra3 @Ma", conn);
                cmd.CommandType = CommandType.Text;
                SqlParameter p = new SqlParameter("@Ma", Convert.ToInt32(comboBox6.SelectedValue.ToString()));
                cmd.Parameters.Add(p);
                SqlDataAdapter dg = new SqlDataAdapter(cmd);
                
                DataTable dt = new DataTable();
                dg.Fill(dt);

                //dataGridView2.DataSource = dt;

                List<DateTime> ls = new List<DateTime>();
                foreach(DataRow row in dt.Rows)
                {
                    DateTime date = new DateTime();
                    date = DateTime.Parse(row["NGAYTHUE"].ToString());
                    ls.Add(date);
                }

                dateTimePicker2.Value = ls[0];


                SqlCommand cmd2 = new SqlCommand("sp_tongtien", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlParameter p2 = new SqlParameter("@Ma", Convert.ToInt32(comboBox6.Text));
                cmd2.Parameters.Add(p2);
                SqlDataAdapter dg2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                dg2.Fill(dt2);
                comboBox13.DataSource = dt2;
                dataGridView2.DataSource = dt2;

                comboBox13.DisplayMember = "THANHTOAN";
                comboBox13.ValueMember = "THANHTOAN";

                SqlCommand cmd3 = new SqlCommand("sp_tongtien1", conn);
                cmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter p3 = new SqlParameter("@Ma", Convert.ToInt32(comboBox6.Text));
                cmd3.Parameters.Add(p3);
                SqlDataAdapter dg3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                dg3.Fill(dt3);
               
                dataGridView3.DataSource = dt3;

               


            }
            catch
            { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    conn = new SqlConnection(strConnection);
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("sp_traphong", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    SqlParameter p = new SqlParameter("@matp", Convert.ToInt32(comboBox6.SelectedValue.ToString()));
            //    cmd.Parameters.Add(p);
            //    SqlDataAdapter dg = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    dg.Fill(dt);
            //    comboBox13.DataSource = dt;
            //    comboBox13.DisplayMember = "THANHTOAN";
            //    comboBox13.ValueMember = "THANHTOAN";



            //}
            //catch
            //{ }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                SqlCommand cmd = new SqlCommand("sp_luudk2", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@matp", comboBox6.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@ngaytra", dateTimePicker3.Text);
                cmd.Parameters.Add(p);

                

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                   
                    MessageBox.Show("Thành Công!");
                  

                   

                }
                else MessageBox.Show("Không hợp lệ!");


               
            }

       

        private void button6_Click(object sender, EventArgs e)
        {

            

           


            SqlCommand cmd = new SqlCommand("sp_traphong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@matp",comboBox6.Text);
                cmd.Parameters.Add(p);
                int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {

                MessageBox.Show("Thành Công!");




            }
            else MessageBox.Show("Không hợp lệ!");




        }
    }

    

        }
    
    

