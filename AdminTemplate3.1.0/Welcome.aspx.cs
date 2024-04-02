using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class Welcome : System.Web.UI.Page
    {
        String text1 = "";
        String text2 = "";
        String text3= "";
        String text4 = "";
        String text5 = "";
        String text6 = "";
        String text7 = "";
        String text8 = "";
        String text9 = "";
        String text10 = "";
        String text11 = "";
        String text12 = "";
        String text13 = "";
        String text14 = "";
        String text15 = "";
        String text16 = "";
        String text17 = "";
        String text18 = "";
        String text19= "";
        String text20 = "";
        String text21 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                text1 = "First";
            }
            else
            {
                text1 = "";
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void View_Precautions_Button1_Click(object sender, EventArgs e)
        {
            Response.Write(text1);
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}