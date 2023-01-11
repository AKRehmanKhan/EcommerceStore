using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class feedback : System.Web.UI.Page
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

                    SqlCommand cmd = new SqlCommand("select * from product_info where productID ='" + TextBox1.Text.Trim() + "' ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                      SqlCommand cm = new SqlCommand("feedbackP", con);
                       cm.CommandType = CommandType.StoredProcedure;

                        cm.Parameters.AddWithValue("@pid",TextBox1.Text.Trim());
                        cm.Parameters.AddWithValue("cid", Session["login_id"].ToString());
                        cm.Parameters.AddWithValue("@decr", TextBox5.Text.Trim());
                        cm.Parameters.AddWithValue("@rating", DropDownList1.SelectedItem.Value);
                       
                         cm.ExecuteNonQuery();
                         Response.Write("<script>alert('Feed BAck Added);</script>");

                          con.Close();

                }
                    else
                    {
                        Response.Write("<script>alert('Invalid Product');</script>");
                    }

                }
                catch (Exception ex)
                {

                }

            }
        }

    }
