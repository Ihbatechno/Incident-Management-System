using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace IMS
{
    public partial class Login : System.Web.UI.Page
    {
        Common con = null;
        DataSet ds = null;
        protected void Page_Load(object sender, EventArgs e)
        {

          
        }

        protected void btlogin_Click(object sender, EventArgs e)
        {
            con = new Common();
            ds = new DataSet();
            ds = con.fnRetriveByQuery("Select * from [tbl_registration] where Email='" + txtemail.Text.ToString() + "' and Password='" + txtpassword.Text.ToString() + "'");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                HttpCookie obCookies = new HttpCookie("Userinfo");
                obCookies.Values.Add("UserID", ds.Tables[0].Rows[0]["id"].ToString());
                obCookies.Values.Add("Useremail", ds.Tables[0].Rows[0]["Email"].ToString());
                obCookies.Values.Add("UserPass", ds.Tables[0].Rows[0]["Password"].ToString());
                obCookies.Values.Add("Usermobile", ds.Tables[0].Rows[0]["Phonenumber"].ToString());

                obCookies.Expires = DateTime.Now.Date.AddDays(1);
                Response.Cookies.Add(obCookies);
                //Session["google"] = null;
                //Session["useremail"] = txtemail.Text.ToString();
                Response.Redirect("~/Dashboard/ManageTrash1.aspx");

            }

            else
            {
                lblmsg.Text = "Invalid Email and Password";
            }
          
        }
        protected void btnLoginWithGoogle_Click(object sender, EventArgs e)
        {
           
            string clientid = "429345487284-6uhj8hh2pgic6tfk2ficjv7rnss5nlvd.apps.googleusercontent.com";
            //your client secret  
            string clientsecret = "kD8SYFW-N2w_yAYb0RaHxvt_";
            //your redirection url  
            string redirection_url = "http://113.193.19.67.xip.io/Dashboard/ManageTrash1";
        
            string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=profile&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
            Response.Redirect(url);
        }
        //protected void btnLoginWithFacebook_Click(object sender, EventArgs e)
        //{
        //    string callbackUrl = "http://localhost:51500/Dashboard/profile1";
        //    string appID = "757770374557736";
        //    //Request offline access and publish to the users stream access.
        //    Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope=offline_access,email,publish_stream", appID, callbackUrl));
        //}
    }
}