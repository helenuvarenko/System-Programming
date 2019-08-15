using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_2;
using Library_3;

namespace Library_4
{
    public static class KI3_Class_4
    {
        public static double F4(double x, double y)
        {
            KI3_Class_3 vyr = new KI3_Class_3();
            double vyr1 = vyr.F3(x,y);
            return 6*KI3_Class_2.F2(x,y)+ 2*vyr.F3(x, y);
        }
    }
}
