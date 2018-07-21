using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class Activation : System.Web.UI.Page
{
    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void btnVerify_Click(object sender, EventArgs e)
    {

        if (code.Text != "")
        {

              if (checkCode(code.Text))
              {
                  String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
                  using (SqlConnection con = new SqlConnection(CS))
                  {
                      SqlCommand cmd = new SqlCommand("INSERT INTO Customer(CustomerEmail, CustomerPassword, CustomerName, CustomerAddress) Values('" + Request.QueryString["email"] + "','" + Request.QueryString["password"] + "','" + Request.QueryString["username"] + "','" + Request.QueryString["contactNumber"] + "')", con);
                      con.Open();
                      int a = cmd.ExecuteNonQuery();
                      if (a > 0)
                      {
                          Response.Redirect("~/Login.aspx");
                      }
                  }
                

              }
              else
              {
                  ErrorMessage.ForeColor = Color.Red;
                  ErrorMessage.Text = "Code do not match";

                 
              }
        }
        else
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "Please Enter the code";
        }
    }


    

 public bool checkCode(string code)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT CustomerCode FROM Code WHERE CustomerCode=@Code");
        cmd.Parameters.AddWithValue("@Code", code);
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