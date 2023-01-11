using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Admin_user_name.Text = Session["Admin_Name"].ToString();
            //Admin_email_name.Text = Session["Admin_Email"].ToString();
        }

        protected void SideBarBtnSeven_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            Response.Redirect("adminlogin.aspx");
        }
    }
}