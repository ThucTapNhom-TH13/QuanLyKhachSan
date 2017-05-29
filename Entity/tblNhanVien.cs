using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class tblNhanVien
    {
        private int manv;
        private string tennv;
        private int gioitinh;
        private string sdt;
        private string diachi;
        private int mk;

        public int Manv
        {
            get
            {
                return manv;
            }

            set
            {
                manv = value;
            }
        }

        public string Tennv
        {
            get
            {
                return tennv;
            }

            set
            {
                tennv = value;
            }
        }

        public int Gioitinh
        {
            get
            {
                return gioitinh;
            }

            set
            {
                gioitinh = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }



        public int Mk
        {
            get
            {
                return mk;
            }

            set
            {
                mk = value;
            }
        }
        public tblNhanVien(int manv, string tennv, int gioitinh, string sdt, string diachi, int mk)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.diachi = diachi;
            this.mk = mk;
        }
        public tblNhanVien(string tennv, int gioitinh, string sdt, string diachi, int mk)
        {
            this.tennv = tennv;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.diachi = diachi;
            this.mk = mk;
        }
    }
}
