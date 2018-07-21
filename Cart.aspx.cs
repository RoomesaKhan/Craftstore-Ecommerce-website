using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;

public partial class Cart : System.Web.UI.Page
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
                CheckOutButton.Enabled = false;
                CheckOutButton.CssClass = "btn btn-primary disabled";
                FillAddress();
            }

        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }


    private void FillAddress()
    {
        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Customer where CustomerID='" + Session["userID"] + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ShippingAddress.Text = rdr["ShippingAddress"].ToString();
            }
        }
        EmptyAddress.Text = "Confirm/Add Address before checkout";
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
                h2NoItems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";

                DataTable cartitems = new DataTable();

                cartitems.Columns.Add("ProductQnty");

                DataTable det = new DataTable();
                Int64 CartTotal = 0;
                //Decimal Total = 0;
                Int64 Discount = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string ProductID = CookieDataArray[i].ToString().Split('-')[0];

                    SqlCommand cmd = new SqlCommand("Select * from Products where ProductID=" + ProductID);

                    cartitems.Merge(access.SelectFromDatabase(cmd));

                    cartitems.Rows[i]["ProductQnty"] = CookieQuantityArray[i].ToString().Split('-')[0];


                    CartTotal += Convert.ToInt64(cartitems.Rows[i]["ProductQnty"]) * Convert.ToInt64(cartitems.Rows[i]["Price"]);

                    Discount = (CartTotal * 10) / 100;

                }

                rptrCartProducts.DataSource = cartitems;
                rptrCartProducts.DataBind();
                divPriceDetails.Visible = true;

                spanCartTotal.InnerText = CartTotal.ToString();
                spanDiscount.InnerText = "Rs. " + Discount.ToString();
                Cart.Total = CartTotal - Discount;
                spanTotal.InnerText = "Rs. " + Total.ToString();




            }

            else
            {
                //TODO Show Empty Cart
                h2NoItems.InnerText = "Your Shopping Cart is Empty";
                divPriceDetails.Visible = false;

            }
        }
        else
        {
            //TODO Show Empty Cart
            h2NoItems.InnerText = "Your Shopping Cart is Empty";
            divPriceDetails.Visible = false;


        }

    }//end of BindCartProducts

    protected void add_ShippingAddress(object sender, EventArgs e)
    {
        if (ShippingAddress.Text == String.Empty)
        {
            EmptyAddress.Text = "Please Enter Valid Email Address";
        }
        else
        {
            String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
            access.AddAndDelInDatabase("update Customer SET ShippingAddress='" + ShippingAddress.Text + "'where CustomerID='" + Session["userID"] + "'");
            EmptyAddress.Text = "Provided address added";
            CheckOutButton.Enabled = true;
            CheckOutButton.CssClass = "btn btn-primary enabled";
        }


    }

    protected void checkOut_Click(object sender, EventArgs e)
    {
        int modified;
        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO [Order](OrderAmount,CustomerID,ShippingAddress) output Inserted.OrderID Values(@amount,@custID,@addr)", con);

            cmd.Parameters.AddWithValue("@amount", Cart.Total);
            cmd.Parameters.AddWithValue("@custID", Convert.ToInt32(Session["userID"]));
            cmd.Parameters.AddWithValue("@addr", ShippingAddress.Text.ToString());

            con.Open();

            modified = Convert.ToInt32(cmd.ExecuteScalar());



            string CookiePID = Request.Cookies["OrderID"]["ProductID"].Split('=')[0];
            string CookieQuantity = Request.Cookies["OrderID"]["Quantity"].Split('=')[0];


            List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            List<String> CookieQuantityList = CookieQuantity.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();


            for (int i = 0; i < CookiePIDList.Count(); i++)
            {

                SqlCommand cmd2 = new SqlCommand("INSERT INTO OrderDetails(DetailProductID,DetailPrice,DetailQuantity,OrderID) VALUES(@ProductCode,@OrderTotalPrice,@OrderQnty,@OrderID)", con);
                cmd2.Parameters.AddWithValue("@ProductCode", CookiePIDList.ElementAt(i));
                cmd2.Parameters.AddWithValue("@OrderQnty", CookieQuantityList.ElementAt(i));


                DataTable price = new DataTable();
                SqlCommand cmd3 = new SqlCommand("Select Price from Products where ProductID=" + CookiePIDList.ElementAt(i));

                price = access.SelectFromDatabase(cmd3);


                cmd2.Parameters.AddWithValue("@OrderTotalPrice", Convert.ToInt64(price.Rows[0]["Price"]) * Convert.ToInt64(CookieQuantityList.ElementAt(i)));
                cmd2.Parameters.AddWithValue("@OrderID", modified);



                int x = cmd2.ExecuteNonQuery();

                if (x > 0)
                {

                    subtractItems(CookiePIDList.ElementAt(i), CookieQuantityList.ElementAt(i));
                }

            }



            Response.Redirect("~/Bill.aspx?OrderID=" + modified);






        }


    }




    private void subtractItems(string pid, string qnty)
    {
        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {


            SqlCommand cmd3 = new SqlCommand("Select InStock From Products where ProductID='" + pid + "'");
            con.Open();
            DataTable qntyTable = access.SelectFromDatabase(cmd3);
            Int64 quantity = Convert.ToInt64(qntyTable.Rows[0]["InStock"]);
            Int64 purchasedQnty = Convert.ToInt64(qnty);
            Int64 updateQuantity = (quantity - purchasedQnty);
            SqlCommand cmd = new SqlCommand("Update Products set InStock='" + updateQuantity + "' where ProductID='" + pid + "'", con);

            cmd.ExecuteNonQuery();

        }
    }




    protected void btnRemoveItem_Click(object sender, EventArgs e)
    {
        string CookiePID = Request.Cookies["OrderID"]["ProductID"].Split('=')[0];
        string CookieQuantity = Request.Cookies["OrderID"]["Quantity"].Split('=')[0];

        LinkButton btn = (LinkButton)sender;
        string PID = btn.CommandArgument;
        List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
        List<String> CookieQuantityList = CookieQuantity.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();

        Int32 ind = CookiePIDList.IndexOf(PID);


        CookieQuantityList.RemoveAt(ind);
        CookiePIDList.RemoveAt(ind);

        string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
        string CookieQntyUpdated = String.Join(",", CookieQuantityList.ToArray());


        if (CookiePIDUpdated == "")
        {
            HttpCookie CartProducts = Request.Cookies["OrderID"];
            CartProducts.Values["ProductID"] = null;
            CartProducts.Values["Quantity"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);

        }
        else
        {
            HttpCookie CartProducts = Request.Cookies["OrderID"];
            CartProducts.Values["ProductID"] = CookiePIDUpdated;
            CartProducts.Values["Quantity"] = CookieQntyUpdated;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);

        }
        Response.Redirect("~/Cart.aspx");

    }// end of remove 



}












