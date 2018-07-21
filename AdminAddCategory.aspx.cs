using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class AdminAddCategory : System.Web.UI.Page
{

    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                BindCategoriesRptr();
            }

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }

    }
    private void BindCategoriesRptr()
    {
       
           SqlCommand cmd = new SqlCommand("select * from Category");
           DataTable dtCategory = new DataTable();
           dtCategory = access.SelectFromDatabase(cmd);
           rptrCategories.DataSource = dtCategory;
           rptrCategories.DataBind();
 
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (checkCat(CategoryName.Text))
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "This Category already exist.";
           
          
          
        }
        else
        {
             String SQL_Insert= "INSERT INTO Category(CategoryName) Values('" + CategoryName.Text + "')";
             if (access.AddAndDelInDatabase(SQL_Insert))
             {
                 CategoryName.Text = String.Empty;
                 ErrorMessage.ForeColor= Color.Green;
                 ErrorMessage.Text = "Successfully Added";
             }
             else{
                 ErrorMessage.ForeColor=Color.Red;
                 ErrorMessage.Text="Adding Category not Successful";
             }
            BindCategoriesRptr();
        }
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable dt = new DataTable();
        int catID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Delete")
        {
            SqlCommand cmd = new SqlCommand("select A.CategoryID,B.ProductName,B.CategoryID from Category A inner join Products B on B.CategoryID=A.CategoryID where A.CategoryID =" + catID + "");

            dt = access.SelectFromDatabase(cmd);
            if (dt.Rows.Count > 0)
            {
                ErrorMessage.Text = "You will first need to delete Products of this Category";
            }
            else
            {
                access.AddAndDelInDatabase("delete from Category where CategoryID='" + catID.ToString() + "'");
                ErrorMessage.Text = "";
                BindCategoriesRptr();

            }

        }



    
    }


    public bool checkCat(string cat)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT CategoryName FROM Category WHERE CategoryName=@Cat");
        cmd.Parameters.AddWithValue("@Cat", cat);
        dt = access.SelectFromDatabase(cmd);
        if (dt.Rows.Count > 0)
        {
            retval = true;
        }
        else
        {
            retval = false;
        }
        return retval;
    }














}