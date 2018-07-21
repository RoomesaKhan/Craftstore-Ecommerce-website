using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;



public partial class SubCategory : System.Web.UI.Page
{

    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                BindSubCatRptr();
            }

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }

    private void BindSubCatRptr()
    {
        SqlCommand cmd = new SqlCommand("select A.*,B.* from SubCategory A inner join Category B on B.CategoryID=A.CategoryID");
       DataTable dtSubCat = new DataTable();
       dtSubCat=access.SelectFromDatabase(cmd);
       rptrSubCat.DataSource = dtSubCat;
       rptrSubCat.DataBind();
    }

    private void BindMainCategory()
    {
         String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
         using (SqlConnection con = new SqlConnection(CS))
         {
             SqlCommand cmd = new SqlCommand("select * from Category" , con);
             con.Open();
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
            
             if (dt.Rows.Count != 0)
             {
                 ddlCategory.DataSource = dt;
                 ddlCategory.DataTextField = "CategoryName";
                 ddlCategory.DataValueField = "CategoryID";
                 ddlCategory.DataBind();
                 ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
             }
         }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        

            if (checkSub(SubCatName.Text))
            {
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Text = "This subcategory already exists";
  

            }
            else
            {
                String SQL_Insert="INSERT INTO SubCategory(SubCategoryName,CategoryID) Values('" + SubCatName.Text + "','" + ddlCategory.SelectedItem.Value + "')";
                    if (access.AddAndDelInDatabase(SQL_Insert))
                  {
                       SubCatName.Text = string.Empty;
                       ddlCategory.ClearSelection();
                       ddlCategory.Items.FindByValue("0").Selected = true;
                       ErrorMessage.ForeColor= Color.Green;
                       ErrorMessage.Text = "Successfully Added";
                   }
                 else{
                 ErrorMessage.ForeColor=Color.Red;
                 ErrorMessage.Text="Adding SubCategory not Successful";
                 }
                BindSubCatRptr();
            }
        
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable dt = new DataTable();
        int subCatID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Delete")
        {
            SqlCommand cmd = new SqlCommand("select A.SubCategoryID,B.ProductName,B.SubCategoryID from SubCategory A inner join Products B on B.SubCategoryID=A.SubCategoryID where A.SubCategoryID =" + subCatID + "");

            dt = access.SelectFromDatabase(cmd);
            if (dt.Rows.Count > 0)
            {
                ErrorMessage.Text = "You will first need to delete Products from this SubCategory";
            }
            else
            {
                access.AddAndDelInDatabase("delete from SubCategory where SubCategoryID='" + subCatID.ToString() + "'");
                ErrorMessage.Text = "";
                BindSubCatRptr();

            }

        }

    }






    public bool checkSub(string subcat)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT SubCategoryName FROM SubCategory WHERE SubCategoryName=@Subcat");
        cmd.Parameters.AddWithValue("@Subcat", subcat);
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