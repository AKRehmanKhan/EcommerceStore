using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DB_Prpject
{
    public partial class userprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["login_id"] == null || Session["login_id"].ToString() == "" )
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if (Session["role"].Equals("customer"))
                    {
                        inventory.Attributes["style"] = "display:none";
                        string quere = "select t.ID as Id,t._dateTime as  [Date] ,t.payment as Payment from transactions as t where customerID='";
                        getttransection(quere);
                    }


                    else if (Session["role"].Equals("seller"))
                    {
                        string h = "select  p.ID as Product_ID, p.namep  as Product_Name, b._name as Brand , c.namec as Category , p.price as Price , i.stock as Stock from inventory as i join product_info as p on i.productID = p.ID join Categorey as c on p.cid = c.Id  join brand as b on p.brandid = b.ID where sellerID = '";
                        getinventory(h);
                        inventory.Attributes["style"] = "display:block";
                        string quere = "select tr.ID as Id,tr._dateTime as  [Date] ,tr.payment as Payment from transactions as tr join ( select t.ID from transactions as t join sold_items as s on t.ID = s.transactionID join inventory as i on s.productID = i.productID where i.sellerID =@a group by t.ID) as dd on tr.ID=dd.ID";
                        gettransection(quere);
                    }
                    if (!Page.IsPostBack)
                    {
                        if (Session["role"].Equals("customer"))
                        {
                            string q = "Select * from customer where login_id='";
                           getUserPersonalDetails(q);
                        }

                        else if(Session["role"].Equals("seller"))
                        {
                            string q = "Select * from sellers where login_id='";
                            getUserPersonalDetails(q);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }
    

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //own functions

        void gettransection( string quere)
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(quere , con);
                cmd.Parameters.AddWithValue("@a",  Session["login_id"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getttransection(string quere)
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(quere + Session["login_id"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getinventory(string quere)
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);
                    con.Open();
                

                SqlCommand cmd = new SqlCommand(quere + Session["login_id"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void getUserPersonalDetails( string quere)
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(quere + Session["login_id"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["dob"].ToString();
                TextBox3.Text = dt.Rows[0]["phone_number"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["gender"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox5.Text = dt.Rows[0]["_address"].ToString();
                TextBox8.Text = dt.Rows[0]["login_id"].ToString();
                TextBox9.Text = dt.Rows[0]["_password"].ToString();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void updatePersonalDetails(string querey)
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                DateTime InvoiceDateFrom = new DateTime();
                DateTime InvoiceDateTo = new DateTime();

                if (TextBox2.Text.Trim() != "")
                {

                    DateTime FromDate = DateTime.ParseExact(TextBox2.Text.Trim(), "1/1/1947", null).AddDays(1);
                    InvoiceDateFrom = Convert.ToDateTime(TextBox2.Text);
                    DateTime toDate = DateTime.ParseExact(TextBox2.Text.Trim(), "1/1/2002", null).AddDays(1);

                }

                if (TextBox2.Text.Trim() != "")
                {
                    InvoiceDateTo = Convert.ToDateTime(TextBox2.Text);
                }
                if (InvoiceDateTo < InvoiceDateFrom)
                    Response.Write("<script>alert('Please Select Valid Date');</script>");


                else
                {

                    SqlCommand cmd = new SqlCommand(querey + Session["login_id"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@_password", password);



                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {

                        Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                        if (Session["role"].Equals("customer"))
                        {
                            string quere = "select s.transactionID as Transaction_ID,p.ID as Product_ID,p.namep as Product_Name,s.sellerID as Seller_ID,p.price as Price,s.quantity as Quantity, t.payment as Total from sold_items as s join transactions as t on s.transactionID =t.ID join product_info as p on s.productID =p.ID where customerID='";
                            gettransection(quere);
                        }


                        else if (Session["role"].Equals("seller"))
                        {
                            string quere = "select s.transactionID as Transaction_ID,p.ID as Product_ID,p.namep as Product_Name,s.customerID as Customer_ID,p.price as Price,s.quantity as Quantity, t.payment as Total from sold_items as s join transactions as t on s.transactionID =t.ID join product_info as p on s.productID =p.ID where sellerID='";
                            gettransection(quere);
                        }

                        if (Session["role"].Equals("customer"))
                        {
                            string q = "Select * from customer where login_id='";
                            getUserPersonalDetails(q);
                        }

                        else if (Session["role"].Equals("seller"))
                        {
                            string q = "Select * from sellers where login_id='";
                            getUserPersonalDetails(q);
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('Invaid entry');</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["login_id"].ToString() == "" || Session["login_id"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                
                if (Session["role"].Equals("customer"))
                {
                   string quer = "update customer set full_name=@full_name, dob=@dob, phone_number=@phone_number, email=@email ,gender=@gender, city=@city, _address=@_address, _password=@_password WHERE login_id='";
                    updatePersonalDetails(quer);
                }

                else if (Session["role"].Equals("seller"))
                {
                  string  quer = "update sellers set full_name=@full_name, dob=@dob, phone_number=@phone_number, email=@email,gender=@gender, city=@city, _address=@_address, _password=@_password WHERE login_id='";
                   updatePersonalDetails(quer);
                }

              

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("admininventory.aspx");
        }

    }
 }

    
