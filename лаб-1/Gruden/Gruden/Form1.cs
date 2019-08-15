using System;
using System.Windows.Forms;

namespace Gruden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            DateTime day = DateTime.Now;

            DateTime max = new DateTime(year, 6, 22);
            DateTime min = new DateTime(year, 12, 22);
            DateTime first = new DateTime(year, 1, 1);
            DateTime last = new DateTime(year, 12, 31);

            double DaysInYear = (last - first).Days + 1;

            double diffDJ = (min - max).Days;
            double diffJD = DaysInYear - diffDJ;

            if ((day <= last) && (day >= max))
                label1.Text += ((((Math.Sin(Math.PI / 2.0 + ((day.DayOfYear - max.DayOfYear) / diffDJ) * (Math.PI)) + 1) / 2)) * 100).ToString() + "% from the longest day";
            else
                label1.Text += ((((Math.Sin(Math.PI * 3.0 / 2.0 + ((9 + day.DayOfYear) / diffJD) * (Math.PI)) + 1) / 2)) * 100).ToString() + "% from the longest day";

        }
    }
}
