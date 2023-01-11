using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class AdminOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                            string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
            Admin_order_GridView1.DataBind();
        }
    }
}