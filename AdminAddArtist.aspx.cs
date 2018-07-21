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

public partial class AdminAddArtist : System.Web.UI.Page
{
    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                BindArtistsRptr();
            }

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
       

    }

    private void BindArtistsRptr()
    {
         SqlCommand cmd = new SqlCommand("select * from Artist");
         DataTable dtArtist = new DataTable();
         dtArtist=access.SelectFromDatabase(cmd);
         rptrArtists.DataSource = dtArtist;
         rptrArtists.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (checkCat(ArtistName.Text))
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "This Category already exists";


        }
        else
        {
           String SQL_Insert= "INSERT INTO Artist(ArtistName) Values('" + ArtistName.Text + "')";
             if (access.AddAndDelInDatabase(SQL_Insert))
             {
                 ArtistName.Text = String.Empty;
                 ErrorMessage.ForeColor= Color.Green;
                 ErrorMessage.Text = "Successfully Added";
             }
             else{
                 ErrorMessage.ForeColor=Color.Red;
                 ErrorMessage.Text="Adding Artist not Successful";
             }
                BindArtistsRptr();    
        }
    }



    protected void ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable dt = new DataTable();
        int artID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Delete")
        {
            SqlCommand cmd = new SqlCommand("select A.ArtistID,B.ProductName,B.ArtistID from Artist A inner join Products B on B.ArtistID=A.ArtistID where A.ArtistID =" + artID + "");
           
            dt = access.SelectFromDatabase(cmd);
            if (dt.Rows.Count > 0)
            {
                ErrorMessage.Text="You will first need to delete Products by this artist";
            }
            else
            {
                access.AddAndDelInDatabase("delete from Artist where ArtistID='" + artID.ToString() + "'");
                ErrorMessage.Text = "";
                BindArtistsRptr();

            }

        }

    }

    public bool checkCat(string artist)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT ArtistName FROM Artist WHERE ArtistName=@Artist");
        cmd.Parameters.AddWithValue("@Artist", artist);
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