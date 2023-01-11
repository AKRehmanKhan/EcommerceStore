using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class signupuser : System.Web.UI.Page
    {
       // string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        protected void Button22_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                signUpNewMember();
            }

        }

        //user defined method
        bool checkMemberExists()
        {
            try
            {
                //SqlConnection con = new SqlConnection(strcon);
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from sellers where login_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signUpNewMember()
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                //DateTime InvoiceDateFrom = new DateTime();
                //DateTime InvoiceDateTo = new DateTime();

                //if (TextBox2.Text.Trim() != "")
                //{

                //    DateTime FromDate = DateTime.ParseExact(TextBox2.Text.Trim(), "1/1/1947", null).AddDays(1);
                //    InvoiceDateFrom = Convert.ToDateTime(TextBox2.Text);
                //    DateTime toDate = DateTime.ParseExact(TextBox2.Text.Trim(), "1/1/2002", null).AddDays(1);

                //}

                //if (TextBox2.Text.Trim() != "")
                //{
                //    InvoiceDateTo = Convert.ToDateTime(TextBox2.Text);
                //}
                //if (InvoiceDateTo < InvoiceDateFrom)
                //    Response.Write("<script>alert('Please Select Valid Date');</script>");


                //else
                {

                    SqlCommand cmd = new SqlCommand("insert into sellers (login_id,_password,full_name,dob,city,gender,email,_address,phone_number) values(@login_id,@_password,@full_name,@dob,@city,@gender,@email,@_address,@phone_number)", con);
                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@login_id", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@_password", TextBox9.Text.Trim());


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                    Response.Redirect("login.aspx");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkMemberExistsbuyer())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                signUpNewMemberbuyer();
            }

          
        }

        //user defined method
        bool checkMemberExistsbuyer()
        {
            try
            {

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from customer where login_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signUpNewMemberbuyer()
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                //SqlConnection con = new SqlConnection(strcon);
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                SqlCommand cmd = new SqlCommand("insert into customer (login_id,_password,full_name,dob,city,gender,email,_address,phone_number) values(@login_id,@_password,@full_name,@dob,@city,@gender,@email,@_address,@phone_number)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@gender", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@login_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@_password", TextBox9.Text.Trim());
                // cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                Response.Redirect("login.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }
        
    }
}



       