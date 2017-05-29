using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using System.Data;

namespace DAL
{
    public class tblNhan_vien_DAL
    {
        public static DataTable getNhanVien()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_NHAN_VIEN", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemNhanVien(tblNhanVien nv)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_NHAN_VIEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TEN_NV", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GIOI_TINH", SqlDbType.Bit);
            cmd.Parameters.Add("@SDT", SqlDbType.Int);
            cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MK", SqlDbType.Int);
            cmd.Parameters["@TEN_NV"].Value = nv.Tennv;
            cmd.Parameters["@GIOI_TINH"].Value = nv.Gioitinh;
            cmd.Parameters["@SDT"].Value = nv.Sdt;
            cmd.Parameters["@DIA_CHI"].Value = nv.Diachi;
            cmd.Parameters["@MK"].Value = nv.Mk;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void SuaNhanVien(tblNhanVien nv)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_NHAN_VIEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_NV", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GIOI_TINH", SqlDbType.Bit);
            cmd.Parameters.Add("@SDT", SqlDbType.Int);
            cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MK", SqlDbType.Int);
            cmd.Parameters["@MA_NV"].Value = nv.Manv;
            cmd.Parameters["@TEN_NV"].Value = nv.Tennv;
            cmd.Parameters["@GIOI_TINH"].Value = nv.Gioitinh;
            cmd.Parameters["@SDT"].Value = nv.Sdt;
            cmd.Parameters["@DIA_CHI"].Value = nv.Diachi;
            cmd.Parameters["@MK"].Value = nv.Mk;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaNhanVien(int manv)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_NHAN_VIEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters["@MA_NV"].Value = manv;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
