using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class AdminHome : System.Web.UI.Page
{
    Accessible access = new Accessible();
    DataTable images = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            if (!this.IsPostBack)
            {
                AllImage();
            }
            CategoryRptr();

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }

    protected void DeleteProduct(object sender, CommandEventArgs e)
    {
        int ProductID = Convert.ToInt32(e.CommandArgument);
        access.AddAndDelInDatabase("delete from Products where ProductID='" + ProductID.ToString() + "'");
        Response.Redirect("~/AdminHome.aspx");


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
            int catId = Convert.ToInt32(category.Value);
            Repeater rptrSubCategories = item.FindControl("rptrSubCat") as Repeater;
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubCategory WHERE CategoryID='" + catId + "'");
            DataTable dtSubCat = new DataTable();
            dtSubCat = access.SelectFromDatabase(cmd);
            rptrSubCategories.DataSource = dtSubCat;
            rptrSubCategories.DataBind();
        }
    }    
}