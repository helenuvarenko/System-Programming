using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library_3;
using Library_4;

namespace User_Form
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        double x, y;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(TextBox1.Text);
            y = Convert.ToDouble(TextBox2.Text);
            double res = KI3_Class_4.F4(x, y);
            Label1.Text = res.ToString();

        }
    }
}