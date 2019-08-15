using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_1;

namespace Library_2
{
    public class KI3_Class_2
    {
        public static double F2(double x, double y)
        {
            KI3_Class_1 vyraz = new KI3_Class_1();
            return 3 * vyraz.F1(x, y) + 2;
        }
    }
}
 