using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;

namespace BUS
{
    public class tblNhan_vien_BUS
    {
        public static DataTable loadNhan_vien()
        {
            return tblNhan_vien_DAL.getNhanVien();
        }
        public static void addNhan_vien(tblNhanVien nv)
        {
            tblNhan_vien_DAL.ThemNhanVien(nv);
        }
        public static void updateNhan_vien(tblNhanVien nv)
        {
            tblNhan_vien_DAL.SuaNhanVien(nv);
        }
        public static void deleteNhan_vien(int manv)
        {
            tblNhan_vien_DAL.XoaNhanVien(manv);
        }
    }
}
