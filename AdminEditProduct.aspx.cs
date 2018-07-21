using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class AdminEditProduct : System.Web.UI.Page
{

    public int artID,catID,subCatID;
    Accessible access = new Accessible();
    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PID"] != null)
                {
                    int PID = Convert.ToInt32(Request.QueryString["PID"]);
                    ExtractData();
                    BindArtistsRptr();
                    BindCategoryRptr();
                    BindSubCatRptr();
                    
                    lbl_ID.Text = PID.ToString();
                }
                else 
                {
                    Response.Redirect("~/AdminHome.aspx");
                }
            }

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }

    public void ExtractData()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            SqlCommand cmd = new SqlCommand("select * from Products where ProductID='" + PID + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                    {
                        txtPName.Text = rdr["ProductName"].ToString();
                        artID = Convert.ToInt32(rdr["ArtistID"]);
                        catID = Convert.ToInt32(rdr["CategoryID"]);
                        subCatID = Convert.ToInt32(rdr["SubCategoryID"]);
                        txtSelPrice.Text = rdr["Price"].ToString();
                        txtSize.Text = rdr["Size"].ToString();
                        txtQuantity.Text = rdr["InStock"].ToString();
                        colour.Text = rdr["Colour"].ToString();
                        txtDesc.Text = rdr["Description"].ToString();
                        rptrImages.DataSource = dt;
                        rptrImages.DataBind();
                        if (Convert.ToInt32(rdr["FreeDelivery"]) == 1)
                        {
                            cbFD.Checked = true;
                        }
                        if (Convert.ToInt32(rdr["30DayRet"]) == 1)
                        {
                            cb30Ret.Checked = true;
                        }
                        if (Convert.ToInt32(rdr["COD"]) == 1)
                        {
                            cbCOD.Checked = true;
                        }
                    }

        }
    }

    


    private void BindArtistsRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Artist", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlArtist.DataSource = dt;
                ddlArtist.DataTextField = "ArtistName";
                ddlArtist.DataValueField = "ArtistID";
                ddlArtist.DataBind();
                ddlArtist.Items.FindByValue(artID.ToString()).Selected = true;
            }
        }

    }

    private void BindCategoryRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Category", con);
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
                ddlCategory.Items.FindByValue(catID.ToString()).Selected = true;
                ddlSubCategory.Enabled = true;
            }
        }

    }

    private void BindSubCatRptr()
    {


        SqlCommand cmd = new SqlCommand("select * from SubCategory where CategoryID='" + ddlCategory.SelectedItem.Value + "'");
           DataTable dtSubCategory = new DataTable();
           dtSubCategory = access.SelectFromDatabase(cmd);
           ddlSubCategory.DataSource = dtSubCategory;
           ddlSubCategory.DataTextField = "SubCategoryName";
           ddlSubCategory.DataValueField = "SubCategoryID";
           ddlSubCategory.DataBind();
           ddlSubCategory.Items.FindByValue(subCatID.ToString()).Selected = true;
    }
    
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from SubCategory where CategoryID='" + ddlCategory.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataValueField = "SubCategoryID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Enabled = true;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int PID = Convert.ToInt32(Request.QueryString["PID"]);
        string ProductName = txtPName.Text;
        string Price= txtSelPrice.Text;
        int CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        int SubCategoryID= Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
        int InStock= Convert.ToInt32(txtQuantity.Text);
        string Colour=colour.Text;
        string Size = txtSize.Text;
        int ArtistID= Convert.ToInt32(ddlArtist.SelectedItem.Value);
        string Description= txtDesc.Text;
        int FreeDelivery;
        int Ret;
        int COD;
        string ImageType;
        Byte[] Img;
        
        if (cbFD.Checked == true)
                    FreeDelivery=1;
                else
                    FreeDelivery=0;
        if (cb30Ret.Checked == true)
                Ret=1;
                else
                Ret=0; 
        if (cbCOD.Checked == true)
               COD=1;
                else
                COD=0; 
        string filePath = fuImg01.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;

         switch (ext)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                }

  

                    Stream fs = fuImg01.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    //insert the file into database

                    ImageType = contenttype;
                    Img= bytes;

            

         access.AddAndDelInDatabase("update Products SET ProductName='" + ProductName + "',Price='" + Price+ "',CategoryID='" + CategoryID+ "',SubCategoryID='" + SubCategoryID+ "',InStock='" + InStock+"',Colour='" + Colour.ToString() + "',Size='" + Size.ToString() + "',ArtistID='" + ArtistID+ "',Description='" + Description + "',FreeDelivery='" + FreeDelivery+ "',[30DayRet]='" + Ret+ "',COD='" + COD + "'where ProductID='" + PID.ToString() + "'");

                Response.Redirect("~/AdminDescription.aspx?ProductID=" + PID + "");
               

    }


    public bool checkProduct(string product)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName=@Product");
        cmd.Parameters.AddWithValue("@Product", product);
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