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

public partial class ImageDisplay : System.Web.UI.Page
{
    Accessible access = new Accessible();
    DataTable images = new DataTable();
    private Color color;
    private int b;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostBack)
        {
            AllImage();
            if (Request.QueryString["catID"] != null)
            {
                BindCatFromHome();
            }
        }
            CategoryRptr();
           
    }

    protected void BindCatFromHome()
    {

        int category = Convert.ToInt32(Request.QueryString["catID"]);
        SqlCommand cmd = new SqlCommand("Select * from Products WHERE CategoryID='" + category + "'");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }



    protected void AllImage()
    {
        SqlCommand cmd = new SqlCommand("Select TOP 6 ProductID,ProductName,Price,Image,Description from Products ORDER BY ProductID");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }

    private void CategoryRptr()
    {
        SqlCommand cmd = new SqlCommand("select * from Category");
        DataTable dtCat = new DataTable();
        dtCat = access.SelectFromDatabase(cmd);
        rptrCat.DataSource = dtCat;
        rptrCat.DataBind();
    }

    protected void SubCat_Click(object sender, EventArgs e)
    {
        
        LinkButton lb = (LinkButton)(sender);
        int subCategory = Convert.ToInt32(lb.CommandArgument);
        SqlCommand cmd = new SqlCommand("Select * from Products WHERE SubCategoryID='" + subCategory + "'");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }

    protected void Cat_Click(object sender, EventArgs e)
    {
        
        LinkButton lb = (LinkButton)(sender);
        int category = Convert.ToInt32(lb.CommandArgument);
        SqlCommand cmd = new SqlCommand("Select * from Products WHERE CategoryID='" + category + "'");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }

    protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField category = item.FindControl("hfCategoryID") as HiddenField;
            int catId = Convert.ToInt32( category.Value );
            Repeater rptrSubCategories = item.FindControl("rptrSubCat") as Repeater;
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubCategory WHERE CategoryID='" + catId + "'");
            DataTable dtSubCat = new DataTable();
            dtSubCat = access.SelectFromDatabase(cmd);
            rptrSubCategories.DataSource = dtSubCat;
            rptrSubCategories.DataBind();
           // ((HtmlControl)e.Item.FindControl("SomeControl")).Attributes.Add("class", "cssStyle");
     
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
        b = RandomNumber(1, 7);
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
