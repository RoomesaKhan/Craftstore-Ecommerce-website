using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class Bill : System.Web.UI.Page
{

    public static double Total;
    Accessible access = new Accessible();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            if (!IsPostBack)
            {
                BindCartProducts();
                BindOrderDetails();
              
            }

        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }



    }


    public void BindCartProducts()
    {

        if (Request.Cookies["OrderID"] != null)
        {
            string CookieData = Request.Cookies["OrderID"]["ProductID"].Split('=')[0];
            string[] CookieDataArray = CookieData.Split(',');


            string CookieQuantity = Request.Cookies["OrderID"]["Quantity"].Split('=')[0];
            string[] CookieQuantityArray = CookieQuantity.Split(',');

            if (CookieDataArray.Length > 0)
            {
                h2NoItems.InnerText = "Items you buyed (" + CookieDataArray.Length + ")";

                DataTable cartitems = new DataTable();

                cartitems.Columns.Add("ProductQnty");

                DataTable det = new DataTable();
                
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string ProductID = CookieDataArray[i].ToString().Split('-')[0];

                    SqlCommand cmd = new SqlCommand("Select * from Products where ProductID=" + ProductID);

                    cartitems.Merge(access.SelectFromDatabase(cmd));

                    cartitems.Rows[i]["ProductQnty"] = CookieQuantityArray[i].ToString().Split('-')[0];


                   
                }

                rptrCartProducts.DataSource = cartitems;
                rptrCartProducts.DataBind();
               

            }

            else
            {
                //TODO Show Empty Cart
                h2NoItems.InnerText = "Your Shopping Cart is Empty";
                

            }
        }
        else
        {
            //TODO Show Empty Cart
            h2NoItems.InnerText = "Your Shopping Cart is Empty";
          


        }

    }//end of BindCartProducts



    

    private void BindOrderDetails()
    {
        Int64 OrderID = Convert.ToInt64(Request.QueryString["OrderID"]);

        SqlCommand cmd = new SqlCommand("select * from [Order] where OrderID=" + OrderID + "");

        DataTable dtOrders = new DataTable();
        dtOrders = access.SelectFromDatabase(cmd);
        rptrOrderDetails.DataSource = dtOrders;
        rptrOrderDetails.DataBind();
        

    }





}

   

