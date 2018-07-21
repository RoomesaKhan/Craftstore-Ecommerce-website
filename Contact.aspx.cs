using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Net;



public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    Accessible access = new Accessible();

    protected void btnForm_Click(object sender, EventArgs e)
    {

        string value = Request.Form["username"];
        string value2 = Request.Form["usermsg"];

        if (value != "" && value2 != "")
        {
            ErrorMessage.Text = "";
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = "Thankyou for your message :)";
            
   
        }
        
        else
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "All fields are mandatory";
        }
    }



 
}