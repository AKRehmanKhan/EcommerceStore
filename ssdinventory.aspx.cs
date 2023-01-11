using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class ssdinventory : System.Web.UI.Page
    {
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
           // GridView1.DataBind();
        }

        //        // go button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            getSSDByID();
        }


        //        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateSSDByID();
        }
        //        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteSSDByID();
        }
        //        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfSSDExists())
            {
                Response.Write("<script>alert('SSD Already Exists, try some other SSD ID');</script>");
            }
            else
            {
                addNewSSD();
            }
        }

        void deleteSSDByID()
        {
            if (checkIfSSDExists())
            {
                try
                {
                    //                  string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                    SqlConnection con = new SqlConnection(strconnect);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("DELETE from ssd WHERE SSD_ID='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('SSDs Deleted Successfully');</script>");

                   // GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid SSD ID');</script>");
            }
        }

        void updateSSDByID()
        {

            if (checkIfSSDExists())
            {
                // Response.Write("<script>alert('Enter if ');</script>");
                try
                {

                    //Response.Write("<script>alert('Enter tryD');</script>");



                    string filepath = "~/laptopimajes/ssd";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("laptopimajes/" + filename));
                        filepath = "~/laptopimajes/" + filename;
                    }

                                    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                    SqlConnection con = new SqlConnection(strconnect);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("UPDATE ssd set  Stock=@Stock, Brand=@Brand, Size=@Size,  Price=@Price where SSD_ID='" + TextBox1.Text.Trim() + "'", con);

                    //cmd.Parameters.AddWithValue("@SSD_ID", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Stock", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Brand", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Size", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", TextBox6.Text.Trim());
                    //cmd.Parameters.AddWithValue("@SSD_Pic", filepath);
                    //Response.Write("<script>alert('SSD Updated Successfully 1');</script>");
                    cmd.ExecuteNonQuery();



                    SqlCommand cnd = new SqlCommand("update inventory set Stock = @st where productID = (select pid  from  ssd where SSD_ID= @sid)" , con);
                    cnd.Parameters.AddWithValue("@st", TextBox3.Text.Trim());
                    cnd.Parameters.AddWithValue("@sid", TextBox1.Text.Trim());
                    cnd.ExecuteNonQuery ();

                    con.Close();
                   // GridView1.DataBind();
                    Response.Write("<script>alert('SSD Updated Successfully');</script>");

                    Response.Redirect("ssdinventory.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid SSD ID');</script>");
            }
        }


        void getSSDByID()
        {
            try
            {
                //                  string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from ssd WHERE SSD_ID='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["Stock"].ToString();
                    TextBox6.Text = dt.Rows[0]["Price"].ToString();
                    TextBox4.Text = dt.Rows[0]["Size"].ToString();

                    //TextBox5.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownList2.SelectedValue = dt.Rows[0]["Brand"].ToString().Trim();


                    global_filepath = dt.Rows[0]["SSD_Pic"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid SSD ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        //        void fillValuecheckd()
        //        {
        //            try
        //            {
        //                SqlConnection con = new SqlConnection(strcon);
        //                if (con.State == ConnectionState.Closed)
        //                {
        //                    con.Open();
        //                }
        //                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                DropDownList3.DataSource = dt;
        //                DropDownList3.DataValueField = "author_name";
        //                DropDownList3.DataBind();

        //                cmd = new SqlCommand("SELECT publisher_name from publisher_master_table;", con);
        //                da = new SqlDataAdapter(cmd);
        //                dt = new DataTable();
        //                da.Fill(dt);
        //                DropDownList2.DataSource = dt;
        //                DropDownList2.DataValueField = "publisher_name";
        //                DropDownList2.DataBind();

        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }

        bool checkIfSSDExists()
        {
            try
            {
                //                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";


                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from ssd where SSD_ID='" + TextBox1.Text.Trim() + "' ;", con);
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

        void addNewSSD()
        {
            //                  string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
            string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

            SqlConnection con = new SqlConnection(strconnect);

            con.Open();


            string filepath = "~/laptopimajes/ssd.jpg";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("laptopimajes/" + filename));
            filepath = "~/laptopimajes/" + filename;




            SqlCommand cmd = new SqlCommand("addssdtoinventory", con);


            cmd.Parameters.AddWithValue("@SSD_ID", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@Stock", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@Brand", DropDownList2.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Size", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@Price", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@SSD_Pic", filepath);
            cmd.Parameters.AddWithValue("@sellerID", Session["login_id"].ToString());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('SSD added successfully.');</script>");
           // GridView1.DataBind();


        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            Response.Redirect("admininventory.aspx");
        }
    }
}