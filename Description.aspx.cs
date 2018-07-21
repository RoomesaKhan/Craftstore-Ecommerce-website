using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

public partial class Description : System.Web.UI.Page
{
    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductID"] != null)
        {
            if (!IsPostBack)
            {
                BindProductImages();
                BindProductDetails();
               
            }
           
        }
        else
        {
            Response.Redirect("~/ImageDisplay.aspx");
        }
    }


    private void BindProductImages()
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);

        SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "");
        DataTable images = new DataTable();
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();

    }


    





    private void BindProductDetails()
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);
        SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.* from Products A inner join Category B on B.CategoryID=A.CategoryID inner join SubCategory C on C.SubCategoryID=A.SubCategoryID inner join Artist D on D.ArtistID=A.ArtistID where ProductID=" + ProductID + "");

        //SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "");
        DataTable dtProducts = new DataTable();
        dtProducts = access.SelectFromDatabase(cmd);
        rptrProductDetails.DataSource = dtProducts;
        rptrProductDetails.DataBind();


        /* textbox disabled */
        


            DataTable sizeDet = new DataTable();
            SqlCommand cmd2 = new SqlCommand("SELECT InStock  FROM Products WHERE ProductID = @ProductID");
            cmd2.Parameters.AddWithValue("@ProductID", ProductID);
            sizeDet = access.SelectFromDatabase(cmd2);
           
            if (Convert.ToString(sizeDet.Rows[0]["InStock"]).Equals("0"))
            {
               // productQnty.Enabled = false;
                btnAddToCart.Enabled = false;
                btnAddToCart.CssClass = "btn btn-primary btn-lg disabled";
                lblErr.Text = "Item not in stock";
                lblErr.ForeColor = Color.Red;
            }
        

        /* textbox disabled */


    }


    private void AddToCart(string quantity)
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);


        if (Session["user"] != null)
        {
            if (Request.Cookies["OrderID"] != null)
            {
                string CookiePID = Request.Cookies["OrderID"]["ProductID"].Split('=')[0];
                CookiePID = CookiePID + "," + ProductID;

                HttpCookie Order = new HttpCookie("OrderID");
                Order.Values["ProductID"] = CookiePID;

                string CookieQnty = Request.Cookies["OrderID"]["Quantity"].Split('=')[0];
                CookieQnty = CookieQnty + "," + quantity;
                Order.Values["Quantity"] = CookieQnty;

                Order.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(Order);
            }
            else
            {
                HttpCookie Order = new HttpCookie("OrderID");
                Order.Values["ProductID"] = ProductID.ToString();
                Order.Values["Quantity"] = quantity;
                Order.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(Order);
            }
             Response.Redirect("~/Description.aspx?ProductID=" + ProductID);
        }
        else
        {
            Response.Redirect("~/Login.aspx?ProductID=" + ProductID);
        }
    }



    protected void AddCart(object sender, System.EventArgs e)
    {
        string qnty = string.Empty;
        int avail = 0;
        foreach (RepeaterItem item in rptrProductDetails.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox txt = (TextBox)item.FindControl("productQnty") as TextBox;
                qnty = txt.Text;
                HiddenField available = item.FindControl("hfAvailable") as HiddenField;
                avail = Convert.ToInt32(available.Value);
            }
        }

            if (qnty.Equals("0") || qnty == string.Empty)
            {
                lblErr.Text = "Please add quantity for your product";
                lblErr.ForeColor = Color.Red;
            }
            else if (Convert.ToInt32(qnty) > Convert.ToInt32(avail))
            {
                lblErr.Text = "Please enter quantity within available range Your quantity is:"+Convert.ToInt32(qnty)+"available is:"+Convert.ToInt32(avail);
                lblErr.ForeColor = Color.Red;
            }
            else
            {
                AddToCart(qnty);

            }
        
    }




    





}