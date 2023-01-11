using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



namespace DB_Prpject
{
    public partial class AddtoCart : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

                Button1.Enabled = true;
                pane.Attributes["style"] = "display:none";
 

            if (Session["role"] == null || Session["role"].ToString() == "")

            {
                Response.Write("<script>alert('You can not view cart as a seller');</script>");
            }
            else if (Session["role"].Equals("customer"))
            {
                viewcart();
            }


        }

        void viewcart()
        {
          //  try
            {
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                SqlConnection con = new SqlConnection(strconnect);


                SqlCommand cmd = new SqlCommand("ViewCart", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@uid", Session["login_id"].ToString());
                SqlParameter retval = cmd.Parameters.Add("@total", SqlDbType.Int, 16);
                cmd.Parameters["@total"].Direction = ParameterDirection.Output;


                con.Open();
                cmd.ExecuteNonQuery();
                int retunvalue = Convert.ToInt32(cmd.Parameters["@total"].Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
                Label3.Text = retunvalue.ToString();
            }
          //  catch
            {

            }
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from cart where customerID='" + Session["login_id"].ToString() + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddtoCart.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                SqlConnection con = new SqlConnection(strconnect);
                con.Open();


                SqlCommand cmd = new SqlCommand("select productID,count(*)  as qua from cart where customerID=@cid  group by productID", con);
                 cmd.Parameters.AddWithValue("@cid", Session["login_id"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        SqlCommand cm = new SqlCommand("canbuy", con);
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.Parameters.AddWithValue("@pid", dt.Rows[i][0]);
                        cm.Parameters.AddWithValue("@qua", dt.Rows[i][1]);

                        SqlParameter rt = cm.Parameters.Add("@lf", SqlDbType.Int, 16);
                        cm.Parameters["@lf"].Direction = ParameterDirection.Output;

                        SqlParameter rt1 = cm.Parameters.Add("@rf", SqlDbType.Int, 16);
                        cm.Parameters["@rf"].Direction = ParameterDirection.Output;

                        SqlParameter rt2 = cm.Parameters.Add("@sf", SqlDbType.Int, 16);
                        cm.Parameters["@sf"].Direction = ParameterDirection.Output;


                        cm.ExecuteNonQuery();
                        int lff = Convert.ToInt16(cm.Parameters["@lf"].Value);
                        int rff = Convert.ToInt16(cm.Parameters["@rf"].Value);
                        int sff = Convert.ToInt16(cm.Parameters["@sf"].Value);
                        if (lff == 0 && sff == 0 & rff == 0)
                        {
                            Response.Write("<script>alert('One or more item is out of stock');</script>");

                            return;
                        }

                    }
                }

            SqlCommand cnd = new SqlCommand("Buy", con);
            cnd.CommandType = CommandType.StoredProcedure;
            cnd.Parameters.AddWithValue("@cid", Session["login_id"].ToString());
            SqlParameter retval = cnd.Parameters.Add("@tid", SqlDbType.Int, 16);
            cnd.Parameters["@tid"].Direction = ParameterDirection.Output;
            cnd.ExecuteNonQuery();
            int tid = Convert.ToInt16(cnd.Parameters["@tid"].Value);
            /////


            for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count >= 1)
                    {

                        int pid = Convert.ToInt32(dt.Rows[i][0]);
                        int count = Convert.ToInt32(dt.Rows[i][1]);

                        SqlCommand cmd1 = new SqlCommand("select sellerId,Stock from inventory where productID='" + pid + "'", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        cmd1.ExecuteNonQuery();

                        string sid = dt1.Rows[0][0].ToString();
                        int stock = Convert.ToInt32(dt1.Rows[0][1]);

                        SqlCommand cmd2 = new SqlCommand("insert into sold_items(transactionID,customerID,sellerID,productID,quantity) values(@tid,@cid,@sid,@pid,@qua)", con);
                        cmd2.Parameters.AddWithValue("@tid", tid);
                        cmd2.Parameters.AddWithValue("@cid", Session["login_id"].ToString());
                        cmd2.Parameters.AddWithValue("@sid", sid);
                        cmd2.Parameters.AddWithValue("@pid", pid);
                        cmd2.Parameters.AddWithValue("@qua", count);
                        cmd2.ExecuteNonQuery();

                        SqlCommand cmd3 = new SqlCommand("update transactions  set customerID =@cid, payment=@total , _dateTime = getdate()where ID = @tid", con);
                        cmd3.Parameters.AddWithValue("@cid", Session["login_id"].ToString());
                        cmd3.Parameters.AddWithValue("@total", Label3.Text.ToString());
                        cmd3.Parameters.AddWithValue("@tid", tid);
                        cmd3.ExecuteNonQuery();


                        SqlCommand cmd4 = new SqlCommand("removebuyproducts", con);
                        cmd4.CommandType = CommandType.StoredProcedure;
                        cmd4.Parameters.AddWithValue("@pid", pid);
                        cmd4.Parameters.AddWithValue("@qua", count);
                        cmd4.Parameters.AddWithValue("@uid", Session["login_id"].ToString());
                        cmd4.ExecuteNonQuery();

                    }
                }
                pane.Attributes["style"] = "display:block";

            Button1.Enabled = false;

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddtoCart.aspx");
        }
    }
}