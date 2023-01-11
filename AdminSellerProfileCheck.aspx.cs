using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class AdminSellerProfileCheck : System.Web.UI.Page
    {

                        string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Admin_seller_profile_search_btn_Click(object sender, EventArgs e)
        {
            try
            {

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                SqlCommand cmd1 = new SqlCommand("SELECT * from sellers where login_id = '" + Admin_seller_Profile_user_text.Text.Trim() + "';", con);
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        A_Seller_full_name.Text = reader.GetValue(2).ToString();
                        A_Seller_phone_name.Text = reader.GetValue(8).ToString();
                        A_Seller_gender.Text = reader.GetValue(5).ToString();
                        A_Seller_Email.Text = reader.GetValue(6).ToString();
                        A_Seller_Address.Text = reader.GetValue(7).ToString();
                        A_Seller_city.Text = reader.GetValue(4).ToString();
                        A_Seller_phone_number.Text = reader.GetValue(6).ToString();
                        A_Seller_DateOfBirth.Text = reader.GetValue(3).ToString();
                        A_Seller_password.Text = reader.GetValue(1).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Email!!')</script>");
                }

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}