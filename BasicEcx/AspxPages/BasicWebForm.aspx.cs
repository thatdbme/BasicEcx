using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicEcx.AspxPages
{
    public partial class BasicWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label1.Text = "The text in the box will show below.";
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
        }
    }
}