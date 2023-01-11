using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class adminlogin : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('Good');</script>");


            //string strconnect = "Data Source=DESKTOP-BTS0DDI\\HAFIZHAMZASHAHID;Initial Catalog=dbproject;Integrated Security=True";

            try
            {

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from admin_ where login_id='" + TextBox1.Text.Trim() + "' AND _password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('" + dr.GetValue(8).ToString() + "');</script>");
                        Response.Write("<script>alert('User Login Succesfful');</script>");

                        Session["login_id"] = dr.GetValue(0).ToString();
                        //Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "seller";
                        //Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("adminMainPage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {

            }

        }
        //catch (Exception ex)
        //{

        //}


        //  try
        //  {

        //string strconnect = "Data Source=DESKTOP-BTS0DDI\\HAFIZHAMZASHAHID;Initial Catalog=dbproject;Integrated Security=True";

        //SqlConnection con = new SqlConnection(strconnect);

        //con.Open();

        //SqlCommand cmd = new SqlCommand("select * from  where login_id='" + TextBox1.Text.Trim() + "' AND _password='" + TextBox2.Text.Trim() + "'", con);
        //SqlDataReader dr = cmd.ExecuteReader();
        //if (dr.HasRows)
        //{
        //    Response.Write("<script>alert('LoginSuccesfful');</script>");
        //    while (dr.Read())
        //    {
        //        //Response.Write("<script>alert('" + dr.GetValue(8).ToString() + "');</script>");

        //        Response.Redirect("adminmaster.Master");
        //    }
        //}
        //else
        //{
        //    Response.Write("<script>alert('Invalid credentials');</script>");
        //}

        //  }
        //  catch (Exception ex)
        //  {

        //  }


    }
}