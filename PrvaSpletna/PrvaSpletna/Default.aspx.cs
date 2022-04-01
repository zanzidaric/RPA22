using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrvaSpletna
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
                TextBox1.Text = "";
            Page.Response.Write("Stevilo uporabnikov " + Application.Get("Up").ToString());
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            TextBox2.Text = TextBox1.Text;
        }
    }
}