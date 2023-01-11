using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DB_Prpject
{
    public partial class adminMainPage : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            //string value = "Hello '" + Session["Admin_Name"].ToString() + "' ! ";

            //AdminMainPage_Name.Text = value;

            try
            {
                //SqlConnection conn = new SqlConnection(strcon);
                //if (conn.State == System.Data.ConnectionState.Closed)
                //{
                //    conn.Open();
                //}

                 string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

              //  Response.Write("<script>alert('Good');</script>");

                //for sale
                SqlCommand cmd1 = new SqlCommand("SELECT count(*) from transactions ", con);

                int sales_count = (int)cmd1.ExecuteScalar();

                SqlCommand cmd2 = new SqlCommand("SELECT count(*) from customer ", con);

                int customer_count = (int)cmd2.ExecuteScalar();

                SqlCommand cmd3 = new SqlCommand("SELECT count(*) from sellers ", con);

                int seller_count = (int)cmd3.ExecuteScalar();

                SqlCommand cmd4 = new SqlCommand("SELECT count(*) from inventory ", con);

                int item_count = (int)cmd4.ExecuteScalar();

                SqlCommand cmd5 = new SqlCommand("SELECT count(*) from feedback ", con);

                int feedback_count = (int)cmd5.ExecuteScalar();

                SqlCommand cmd6 = new SqlCommand("SELECT count(*) from [admin_]", con);

                int total_users = (int)cmd6.ExecuteScalar();
                total_users = total_users + seller_count + customer_count;


                Sales_Count.Text = sales_count.ToString();
                if (sales_count == 0)
                    cardvalue_sales.Style["background-color"] = "red";
                else
                    cardvalue_sales.Style["background-color"] = "green";




                Customer_count.Text = customer_count.ToString();
                if (customer_count == 0)
                    cardvalue_customer.Style["background-color"] = "red";
                else
                    cardvalue_customer.Style["background-color"] = "green";


                Seller_count.Text = seller_count.ToString();
                if (seller_count == 0)
                    cardvalue_seller.Style["background-color"] = "red";
                else
                    cardvalue_seller.Style["background-color"] = "green";


                Product_count.Text = item_count.ToString();
                if (item_count == 0)
                    cardvalue_item.Style["background-color"] = "red";
                else
                    cardvalue_item.Style["background-color"] = "green";


                Feedback_count.Text = feedback_count.ToString();
                if (feedback_count == 0)
                    cardvalue_feedback.Style["background-color"] = "red";
                else
                    cardvalue_feedback.Style["background-color"] = "green";


                TUser_Count.Text = total_users.ToString();
                if (total_users == 0)
                    cardvalue_total.Style["background-color"] = "red";
                else
                    cardvalue_total.Style["background-color"] = "green";


                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}