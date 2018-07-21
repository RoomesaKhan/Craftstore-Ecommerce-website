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

public partial class Home : System.Web.UI.Page
{
    Accessible access = new Accessible();
    DataTable images = new DataTable();
    private Color color;
    private int b;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            AllImage();
        }
        CategoryRptr();
       

    }

    private void CategoryRptr()
    {
        SqlCommand cmd = new SqlCommand("select * from Category");
        DataTable dtCat = new DataTable();
        dtCat = access.SelectFromDatabase(cmd);
        rptrCat.DataSource = dtCat;
        rptrCat.DataBind();
    }


    protected void AllImage()
    {
        SqlCommand cmd = new SqlCommand("Select TOP 3 ProductID,ProductName,Price,Image,Description from Products ORDER BY ProductID");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }

    protected void Cat_Click(object sender, EventArgs e)
    {

        LinkButton lb = (LinkButton)(sender);
        int category = Convert.ToInt32(lb.CommandArgument);
        Response.Redirect("~/ImageDisplay.aspx?catID="+category+"");
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);


        if (Session["user"] != null)
        {
            if (Request.Cookies["OrderID"] != null)
            {
                string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
                CookiePID = CookiePID + "," + ProductID;

                HttpCookie Order = new HttpCookie("OrderID");
                Order.Values["OrderID"] = CookiePID;
                Order.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(Order);
            }
            else
            {
                HttpCookie Order = new HttpCookie("OrderID");
                Order.Values["OrderID"] = ProductID.ToString();
                Order.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(Order);
            }
            Response.Redirect("~/Home.aspx?ProductID=" + ProductID);
        }

        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }


    private static readonly Random random = new Random();
    private static readonly object syncLock = new object();
    public static int RandomNumber(int min, int max)
    {
        lock (syncLock)
        { // synchronize
            for (int i = 0; i < 1000000; i++)
            {

            }
            return random.Next(min, max);
        }
    }
    protected void GetRandColor(object sender, EventArgs e)
    {
        //Random r = new Random();
        b = RandomNumber(1, 7);
        // b = r.Next(1, 5);
        switch (b)
        {
            case 1:
                color = Color.Red; break;
            case 2:
                color = Color.Blue; break;
            case 3:
                color = Color.Green; break;
            case 4:
                color = Color.Yellow; break;
            case 5:
                color = Color.Orange; break;
            case 6:
                color = Color.Purple; break;
        }
        for (int k = 0; k < 100; k++)
        {
        }

        LinkButton btn = (LinkButton)sender;
        btn.BackColor = color;
    }

    




}