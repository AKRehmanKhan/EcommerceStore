using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Prpject
{
    public partial class homepage : System.Web.UI.Page
    {
     
           
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

                Session["addproduct"] = false;
                if (TextBox1.Text == "")
                {
                    allProducts();

                }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(TextBox1.Text.Trim()!= null)
            {
                ViewSearchedProducts();

            }
            else
            {
                //do nothing
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void ViewSearchedProducts()
        {
            string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

            SqlConnection con = new SqlConnection(strconnect);


            string quere = "select p.namep, p.ID , p.price,b._name ,i.Stock, p._image from product_info  as p join brand as b on p.brandid = b.ID   join Categorey as c on p.cid= c.ID join inventory as i on i.productID=p.ID where ( p.namep like  '%' + @name + '%' OR  b._name like '%' + @brand + '%' OR  p.ID like '%' + @id + '%'  OR  c.namec like '%' + @Cname + '%'   + @price+ '%')";
            SqlCommand comm = new SqlCommand(quere, con);
            comm.Parameters.Add("@name", SqlDbType.NVarChar).Value = TextBox1.Text;
            comm.Parameters.Add("@brand", SqlDbType.NVarChar).Value = TextBox1.Text;
            comm.Parameters.Add("@id", SqlDbType.NVarChar).Value = TextBox1.Text;
            comm.Parameters.Add("@Cname", SqlDbType.NVarChar).Value = TextBox1.Text;
            comm.Parameters.Add("@price", SqlDbType.NVarChar).Value = TextBox1.Text;
            DataTable dt = new DataTable();
            con.Open();

            comm.ExecuteNonQuery();


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            DataSet ds = new DataSet();
            da.Fill(ds);

            DataList1.DataSourceID = null;
            DataList1.DataSource = ds;
            DataList1.DataBind();


            con.Close();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            allProducts();
        }


        void allProducts()
        {
            string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";

            SqlConnection con = new SqlConnection(strconnect);


            string quere = "select p.namep, p.ID , p.price,b._name , p._image, i.Stock from product_info  as p join brand as b on p.brandid =  b.ID  join inventory as i on p.ID=i.productID ";
            SqlCommand comm = new SqlCommand(quere, con);

            DataTable dt = new DataTable();
            con.Open();

            comm.ExecuteNonQuery();


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            DataSet ds = new DataSet();
            da.Fill(ds);

            DataList1.DataSourceID = null;
            DataList1.DataSource = ds;
            DataList1.DataBind();


            con.Close();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "details")
            { 
                Response.Redirect("details.aspx?id=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "cart")
            {
                if(Session["role"]==null || Session["role"].ToString()=="")
                {
                    Response.Redirect("login.aspx");
                    Response.Write("<script>alert('Login First');</script>");
                }
                else if (Session["role"].Equals("customer"))
                {
                    string strconnect = "Data Source=AKKHAN;Initial Catalog=dbproject;Integrated Security=True";
                    SqlConnection con = new SqlConnection(strconnect);

                    SqlCommand cmd = new SqlCommand("insertintocart", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid", e.CommandArgument);
                    cmd.Parameters.AddWithValue("cid", Session["login_id"].ToString());
                    SqlParameter retval = cmd.Parameters.Add("@sf", SqlDbType.Int, 16);
                    cmd.Parameters["@sf"].Direction = ParameterDirection.Output;


                    con.Open();
                    cmd.ExecuteNonQuery();
                    int retunvalue = Convert.ToInt16(cmd.Parameters["@sf"].Value);
                    if (retunvalue == 0)
                    {
                        Response.Write("<script>alert('Out of Stock');</script>");
                    }
                    else
                    {
                        Response.Redirect("AddtoCart.aspx");
                    }

                }

                else if(Session["role"].Equals("seller"))
                {
                    Response.Write("<script>alert('You can't buy as a seller');</script>");
                }


            }

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["role"]==null || Session["role"].ToString()=="")
            {
                Response.Redirect("login.aspx");
                Response.Write("<script>alert('Login as a customer first');</script>");
            }

             else if (Session["role"].Equals("customer"))
            {
                Response.Redirect("AddtoCart.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}