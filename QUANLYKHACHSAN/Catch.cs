using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYKHACHSAN
{
    public class Catch
    {
        public static bool cNullTB(string textBox)
        {
            bool check = false;
            if (textBox == "")
            {

                check = true;
            }
            return check;
        }
    }
}
