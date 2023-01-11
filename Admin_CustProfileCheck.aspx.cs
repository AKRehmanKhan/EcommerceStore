using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{

    public partial class Admin_CustProfileCheck : System.Web.UI.Page
    {

                        string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Admin_Customer_profile_search_btn_Click(object sender, EventArgs e)
        {
            try
            {

                                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                SqlCommand cmd1 = new SqlCommand("SELECT * from customer where login_id = '" + Admin_Cust_Profile_user_text.Text.Trim() + "';", con);
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer_full_name.Text = reader.GetValue(2).ToString();
                        Customer_Phone_Nuber_name.Text = reader.GetValue(8).ToString();
                        Customer_gender.Text = reader.GetValue(5).ToString();
                        Customer_Email.Text = reader.GetValue(6).ToString();
                        Customer_Address.Text = reader.GetValue(7).ToString();
                        Customer_city.Text = reader.GetValue(4).ToString();
                        Customer_phone_number.Text = reader.GetValue(6).ToString();
                        Customer_DateOfBirth.Text = reader.GetValue(3).ToString();
                        Customer_password.Text = reader.GetValue(1).ToString();
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