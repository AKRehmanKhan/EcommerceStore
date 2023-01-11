using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Good');</script>");

            try
            {

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from sellers where login_id='" + TextBox1.Text.Trim() + "' AND _password='" + TextBox2.Text.Trim() + "'", con);
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
                    Response.Redirect("homepage.aspx");
                   
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

        protected void Button2_Click1(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('Good');</script>");

            try
            {

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from customer where login_id='" + TextBox1.Text.Trim() + "' AND _password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('" + dr.GetValue(8).ToString() + "');</script>");
                        Response.Write("<script>alert('Customer Login Succesfful');</script>");


                        Session["login_id"] = dr.GetValue(0).ToString();
                        //Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "customer";
                        //Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
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
    }
}