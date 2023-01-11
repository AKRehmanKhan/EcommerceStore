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
    public partial class raminventory : System.Web.UI.Page
    {
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
           // GridView1.DataBind();
        }

        //        // go button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            getRAMByID();
        }


        //        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateRAMByID();
        }
        //        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteRAMByID();
        }
        //        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfRAMExists())
            {
                Response.Write("<script>alert('RAM Already Exists, try some other RAM ID');</script>");
            }
            else
            {
                addNewRAM();
            }
        }

        void deleteRAMByID()
        {
            if (checkIfRAMExists())
            {
                try
                {
                   //                 string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                   string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";


                    SqlConnection con = new SqlConnection(strconnect);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("DELETE from ram WHERE RAM_ID='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('RAMs Deleted Successfully');</script>");

                   // GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid RAM ID');</script>");
            }
        }

        void updateRAMByID()
        {

            if (checkIfRAMExists())
            {

                try
                {



                    string filepath = "~/laptopimajes/ram";
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

                    //                 string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                    SqlConnection con = new SqlConnection(strconnect);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("UPDATE ram set  Stock=@Stock,DDR_Version=@DDR_Version, Brand=@Brand, Size=@Size,  Price=@Price where RAM_ID='" + TextBox1.Text.Trim() + "'", con);

                    //cmd.Parameters.AddWithValue("@RAM_ID", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Stock", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@DDR_Version", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Brand", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Size", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", TextBox6.Text.Trim());
                    //cmd.Parameters.AddWithValue("@RAM_Pic", filepath);
                    //Response.Write("<script>alert('RAM Updated Successfully 1');</script>");
                    cmd.ExecuteNonQuery();



                    SqlCommand cnd = new SqlCommand("update inventory set Stock = @st where productID = (select pid  from  ram where RAM_ID= @sid)", con);
                    cnd.Parameters.AddWithValue("@st", TextBox3.Text.Trim());
                    cnd.Parameters.AddWithValue("@sid", TextBox1.Text.Trim());
                    cnd.ExecuteNonQuery();

                    con.Close();
                   // GridView1.DataBind();
                    Response.Write("<script>alert('RAM Updated Successfully');</script>");

                    Response.Redirect("raminventory.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid RAM ID');</script>");
            }
        }


        void getRAMByID()
        {
            try
            {
                //                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();



                SqlCommand cmd = new SqlCommand("SELECT * from ram WHERE RAM_ID='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["Stock"].ToString();
                    TextBox6.Text = dt.Rows[0]["Price"].ToString();
                    TextBox4.Text = dt.Rows[0]["Size"].ToString();


                    DropDownList1.SelectedValue = dt.Rows[0]["Brand"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["DDR_Version"].ToString().Trim();


                    global_filepath = dt.Rows[0]["RAM_Pic"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid RAM ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }



        bool checkIfRAMExists()
        {
            try
            {
                //                 string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from RAM where RAM_ID='" + TextBox1.Text.Trim() + "' ;", con);
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

        void addNewRAM()
        {
            try
            {
                //                 string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                string filepath = "~/laptopimajes/ram.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("laptopimajes/" + filename));
                filepath = "~/laptopimajes/" + filename;



                SqlCommand cmd = new SqlCommand("addramtoinventory", con);


                cmd.Parameters.AddWithValue("@RAM_ID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Stock", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@DDR_Version", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Brand", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Size", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Price", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@RAM_Pic", filepath);
                cmd.Parameters.AddWithValue("sellerID", Session["login_id"].ToString());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('RAM added successfully.');</script>");
               // GridView1.DataBind();

            }
            catch
            {

            }




        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            Response.Redirect("admininventory.aspx");
        }
    }
}