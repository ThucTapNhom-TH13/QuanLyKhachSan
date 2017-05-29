using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QUANLYKHACHSAN
{
    public partial class Form1 : Form
    {
        string strConnection = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN1;Integrated Security=True";
        SqlConnection conn;
        SqlCommand coman;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                string sql = "select count(*) from NHANVIEN where MANV=@txttentruycap and MATKHAU=@txtmk ";
               
                coman = new SqlCommand(sql, conn);
                coman.Parameters.Add(new SqlParameter("@txttentruycap", textBox1.Text));
                coman.Parameters.Add(new SqlParameter("@txtmk", textBox2.Text));
               
                int x = (int)coman.ExecuteScalar();
               

                if (x == 1)
                {//Đăng nhập thành công nhân viên
                    label5.Visible = false;
                    MessageBox.Show("Đăng nhập thành công.");

                    //

                    quanlikhachsac tc2 = new quanlikhachsac(textBox1.Text, textBox2.Text);
                    tc2.Show();
                    //trangchu2 fr1 = new tran();
                    //fr1.Show();
                    Form1 fr2 = new Form1();
                    fr2.Hide();


                }

                
                else
                {//Đăng nhập thất bại
                    label5.Visible = true;
                    label5.Text = "Tên truy cập hoặc mật khẩu sai";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    groupBox1.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
