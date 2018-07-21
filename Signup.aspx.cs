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
public partial class Signup : System.Web.UI.Page
{
    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {   
        string User,Email, Pass;
        if (username.Text != "" && email.Text != "" && password.Text != "" && confirm_password.Text != "")
        {
            if (checkEmail(email.Text))
            {
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Text = "This email address account already exists";

            }
            else
            {
                if (password.Text == confirm_password.Text)
                {
                            if (Page.IsValid)
                            {
                                try
                                {
                                    string random = genCode();
                                    User = username.Text.ToString();
                                    Email = email.Text.ToString();
                                    Pass = password.Text.ToString();
                                    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
                                    using (SqlConnection con1 = new SqlConnection(CS))
                                    {
                                        SqlCommand cmd1 = new SqlCommand("INSERT INTO Code(CustomerCode) Values('" + random + "')", con1);

                                        con1.Open();
                                        cmd1.ExecuteNonQuery();

                                        sendMsg(Email, User, Pass, random);
                                        Session["newEmail"] = User;
                                        Response.Redirect(string.Format("Activation.aspx?email={0}&password={1}&username={2}&contactNumber={3}", email.Text, password.Text,username.Text,contact_number.Text));


                                        
                                    }

                                }
                                catch (Exception msg1)
                                {
                                    Response.Write(msg1);
                                }
                            }
                            /*email code*/


                }
                else
                {
                    ErrorMessage.ForeColor = Color.Red;
                    ErrorMessage.Text = "Passwords do not match";
                }
            }
        }
        else
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "All fields are mandatory";
        }
    }



    public String genCode()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        return finalString;
    }



    //Send Mail
    public static void sendMsg(string Email, string User, string Pass, string random)
    {

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("craftstore50@gmail.com", "12345craft");
        smtp.EnableSsl = true;

        MailMessage msg = new MailMessage();
        msg.Subject = "Hello User"; 
        msg.Body = "Hello " + User + "Thanks for Registering in Craftstore...Your Account Details are given below:";
        msg.Body += "<tr>";
        msg.Body += "<td>User Name :" + User + "</td>";
        msg.Body += "</tr>";
        msg.Body += "<tr>";
        msg.Body += "<td>Password :" + Pass + "</td>";
        msg.Body += "</tr>";
        msg.Body += "<tr>";
        msg.Body += "<td>Activation Number :" + random + "</td>";
        msg.Body += "</tr>";

        msg.Body += "<tr>";
        msg.Body += "<td>Thanking</td><td>Team Craftstore</td>";
        msg.Body += "</tr>";

        string toAddress = Email; // Add Recepient address
        msg.To.Add(toAddress);

        string fromAddress = "\"Craftstore \" <craftstore50@gmail.com>";
        msg.From = new MailAddress(fromAddress);
        msg.IsBodyHtml = true;

        try
        {
            smtp.Send(msg);

        }
        catch
        {
            throw;
        }
    }

    public bool checkEmail(string email)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT CustomerEmail FROM Customer WHERE CustomerEmail=@Email");
        cmd.Parameters.AddWithValue("@Email", email);
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