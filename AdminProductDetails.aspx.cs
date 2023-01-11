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
    public partial class AdminProductDetails : System.Web.UI.Page
    {
                        string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Admin_product_GridView1.DataBind();
        }

        protected void Admin_Prod_details_remove_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //string seller = Admin_Seller_name_text.Text.Trim();
                string productid = Admin_Prod_ID_text.Text.Trim();

               
                if (productid == "")
                    Response.Write("<script>alert('Product ID field is empty')</script>");
                else
                {
                                    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                    SqlConnection con = new SqlConnection(strconnect);

                    con.Open();

                    //SqlCommand cmd = new SqlCommand("declare @flag int; execute delete_item_by_admin '" + product + "', '" + seller + "', '" + productid + "', @flag output select @flag as flag", con);

                    SqlCommand cmd = new SqlCommand("select * from inventory where  productID=  ' " + Admin_Prod_ID_text.Text.Trim() + " ' ", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        //                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                        SqlConnection conn = new SqlConnection(strconnect);

                        conn.Open();
                        SqlCommand cmmd = new SqlCommand("Delete from inventory where productID=  ' " + Admin_Prod_ID_text.Text.Trim() + " ' ", conn);
                        //SqlCommand cmmd = new SqlCommand("Delete from inventory where productID=  ' " + Admin_Prod_ID_text.Text.Trim() + " ' ", conn);
                        cmmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Deleted Successfully')</script>");
                        conn.Close();
                    }
                    else
                    {
                        Response.Write("<script>alert('Not Delete')</script>");
                    }

                    

                    //int val = (int)cmd.ExecuteScalar();

                    //if (val == 0)
                    //{
                    //    Response.Write("<script>alert('Invalid Input')</script>");
                    //}
                    //else
                    //{
                        
                    //}

                    con.Close();
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}