using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
           int id = Convert.ToInt16((Request.QueryString["id"].ToString()));
            getByID(id);
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

    void getByID(int id)
        {
           // try
            {
                //                  string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";   
                SqlConnection con = new SqlConnection(strconnect);


                SqlCommand cmd = new SqlCommand("productdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pid",id);
                SqlParameter retval =cmd.Parameters.Add("@cid",SqlDbType.Int,16);
                cmd.Parameters["@cid"].Direction = ParameterDirection.Output;


                con.Open();
                cmd.ExecuteNonQuery();
                int retunvalue = Convert.ToInt16(cmd.Parameters["@cid"].Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                


                if (retunvalue == 1)
                {
                    laptop.Attributes["style"] = "display:block";
                    ssd.Attributes["style"] = "display:none";
                    ram.Attributes["style"] = "display:none";
                   GridView2.DataSource = dt;
                    GridView2.DataBind();
                }

                else if (retunvalue == 2)
                {
                    ram.Attributes["style"] = "display:block";
                    laptop.Attributes["style"] = "display:none";
                    ssd.Attributes["style"] = "display:none";

                    GridView3.DataSource = dt;
                    GridView3.DataBind();

                }

                else if (retunvalue == 3)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    ssd.Attributes["style"] = "display:block";
                    laptop.Attributes["style"] = "display:none";
                    ram.Attributes["style"] = "display:none";

                }
                con.Close();
                

            }
            //catch (Exception ex)
            {

            }
        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}