using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
            {
                username.Text = Request.Cookies["UNAME"].Value;
                password.Attributes["value"] = Request.Cookies["PWD"].Value;
                CheckBox1.Checked = true;
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Customer where CustomerName='" + username.Text + "' and CustomerPassword='" + password.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                if (CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = username.Text;
                    Response.Cookies["PWD"].Value = password.Text;

                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(3);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(3);
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                }
                int userID = dt.Rows[0].Field<int>(0);
                Session["userID"] = userID;
                Session["user"] = username.Text;

               
                        if (Request.QueryString["ProductID"] != null)
                        {
                            Response.Redirect("~/Description.aspx?ProductID=" + Request.QueryString["ProductID"]);
 
                        }
                       
                    
                else
                {
                    Response.Redirect("~/Home.aspx");
                }

                Session.RemoveAll();
            }
            else
            {
                lblError.Text = "Invalid Username or password";
            }
        }
    }
}