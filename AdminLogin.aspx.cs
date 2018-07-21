using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLoginAdmin_Click(object sender, EventArgs e)
    {
        if (passwordAdmin.Text == "Admin123")
        {
            Session["admin"] = "admin";
            Response.Redirect("~/AdminHome.aspx");
        }
        else
        {
            lblError.Text = "Invalid Password";
        }
    }
}