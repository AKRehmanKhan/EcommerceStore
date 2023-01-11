using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class Laptopinventory : System.Web.UI.Page
    {

        static string global_filepath;



        protected void Page_Load(object sender, EventArgs e)
        {


        }

        //        // go button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            
            getLaptopByID();
        }


        //        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateLaptopByID();
        }
        //        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteLaptopByID();
        }
        //        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfLaptopExists())
            {
                Response.Write("<script>alert('Laptop Already Exists, try some other Laptop ID');</script>");
            }
            else
            {
                addNewLaptop();
            }
        }



        //        // user defined functions

        //void Viewlaptop()
        //{
        //    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

        //    SqlConnection con = new SqlConnection(strconnect);

        //    con.Open();


        //    SqlCommand cmd = new SqlCommand ("SELECT pid as Product_ID,Laptop_ID,Laptop_Name,Generation, Brand,Proceesor,RAM,SSD,HDD,i.Stock,Price,Laptop_Pic,sellerID from laptop as l join Inventory as i on l.pid = i.productID WHERE l.Laptop_Id ='" + TextBox1.Text.Trim() + "' AND  i.sellerID=@lid;", con);
        //    cmd.Parameters.AddWithValue("@lid", Session["login_id"].ToString());
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    cmd.ExecuteNonQuery();
          
        //    GridView1.DataBind();
        //    con.Close();
        //}
        void deleteLaptopByID()
        {
            if (checkIfLaptopExists())
            {
                try
                {
                    //                 string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

                    SqlConnection con = new SqlConnection(strconnect);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("DELETE from laptop WHERE Laptop_ID='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Laptops Deleted Successfully');</script>");

                  //  GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Laptop ID');</script>");
            }
        }

        void updateLaptopByID()
        {

            if (checkIfLaptopExists())
            {
                try
                {



                    string filepath = "~/laptopimajes/laptop";
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


                    SqlCommand cmd = new SqlCommand("UPDATE laptop set Laptop_Name=@Laptop_Name, Stock=@Stock, Brand=@Brand, Generation=@Generation, Proceesor=@Proceesor, RAM=@RAM, HDD=@HDD, SSD=@SSD, Price=@Price where Laptop_ID='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@Laptop_ID", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Laptop_Name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Stock", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Brand", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Generation", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Proceesor", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@RAM", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@HDD", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@SSD", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@Laptop_Pic", filepath);
                    cmd.Parameters.AddWithValue("@linklaptop", "NULL");
                    //Response.Write("<script>alert('Laptop Updated Successfully 1');</script>");
                    cmd.ExecuteNonQuery();

                    SqlCommand cnd = new SqlCommand("update inventory set Stock = @st where productID = (select pid  from  laptop where Laptop_ID= @sid)", con);
                    cnd.Parameters.AddWithValue("@st", TextBox3.Text.Trim());
                    cnd.Parameters.AddWithValue("@sid", TextBox1.Text.Trim());
                    cnd.ExecuteNonQuery();

                    con.Close();
                 //   GridView1.DataBind();
                    Response.Write("<script>alert('Laptop Updated Successfully');</script>");
                    Response.Redirect("Laptopinventory.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Laptop ID');</script>");
            }
        }


        void getLaptopByID()
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT pid as Product_ID,Laptop_ID,Laptop_Name,Generation, Brand,Proceesor,RAM,SSD,HDD,i.Stock,Price,Laptop_Pic,sellerID from laptop as l join Inventory as i on l.pid = i.productID WHERE l.Laptop_Id ='" + TextBox1.Text.Trim() + "' AND  i.sellerID=@lid;", con);
                cmd.Parameters.AddWithValue("@lid", Session["login_id"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["Laptop_name"].ToString();
                    TextBox8.Text = dt.Rows[0]["Proceesor"].ToString();
                    TextBox3.Text = dt.Rows[0]["Stock"].ToString();
                    TextBox9.Text = dt.Rows[0]["HDD"].ToString();
                    TextBox10.Text = dt.Rows[0]["SSD"].ToString();
                    TextBox6.Text = dt.Rows[0]["Price"].ToString();
                    TextBox4.Text = dt.Rows[0]["RAM"].ToString();



                    DropDownList1.SelectedValue = dt.Rows[0]["Generation"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["Brand"].ToString().Trim();


                    global_filepath = dt.Rows[0]["Laptop_Pic"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Laptop ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }


        bool checkIfLaptopExists()
        {
            try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                SqlConnection con = new SqlConnection(strconnect);

                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from laptop where Laptop_ID='" + TextBox1.Text.Trim() + "' ;", con);
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

        void addNewLaptop()
        {
            string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
            SqlConnection con = new SqlConnection(strconnect);

            con.Open();


            string filepath = "~/laptopimajes/laptop.jpg";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //FileUpload1.SaveAs(Server.MapPath("laptopimajes/" + filename));
            filepath = "~/laptopimajes/" + filename;



            SqlCommand cmd = new SqlCommand("AddToinventory", con);

            cmd.Parameters.AddWithValue("@Laptop_ID", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@Laptop_Name", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@Stock", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@Brand", DropDownList2.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Generation", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Proceesor", TextBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@RAM", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@HDD", TextBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@SSD", TextBox10.Text.Trim());
            cmd.Parameters.AddWithValue("@Price", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@Laptop_Pic", filepath);
            cmd.Parameters.AddWithValue("@sellerID", Session["login_id"].ToString());

            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Laptop added successfully.');</script>");
         //   GridView1.DataBind();

        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            Response.Redirect("admininventory.aspx");
        }
    }
}