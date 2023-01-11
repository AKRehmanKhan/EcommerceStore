using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class AdminCustomerDetails : System.Web.UI.Page
    {


                        string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Admin_customer_GridView1.DataBind();
        }

        protected void Admin_Cust_details_remove_btn_Click(object sender, EventArgs e)
        {
            if (check_valid_Email())
            {
                Response.Write("<script>alert('Customer Not Exits')</script>");
            }
            else
            {
                delete_Customer();
            }
        }

        bool check_valid_Email()
        {
            try
            {
                                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("Select count(*) from customer where login_id = '" + Admin_Cust_details_user_text.Text.Trim() + "'", con);

                int count = (int)cmd.ExecuteScalar();

                con.Close();

                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }


        void delete_Customer()
        {
            try
            {
                                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE from customer where login_id = '" + Admin_Cust_details_user_text.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Deletion Successfull !!')</script>");

                Admin_customer_GridView1.DataBind();

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


    }
}