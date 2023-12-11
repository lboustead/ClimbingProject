using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ClimbingProject
{
    public partial class LoginPage : System.Web.UI.Page
    {
        //connectionString setup
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ClimbingDatabaseConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            //assigning username and password
            string userName = Login1.UserName;
            string pass = Login1.Password;

            //Using sqlcommand to obtain username to determine if they are a user
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //get username from NetUser
                SqlCommand getUserName = new SqlCommand("SELECT Username FROM NetUser WHERE Username = '" + userName + "'", conn);
                var testUser = getUserName.ExecuteScalar();

                if (testUser != null)
                {
                    SqlCommand getPassword = new SqlCommand("SELECT PasswordValue FROM NetUser WHERE PasswordValue = '" + pass + "'", conn);
                    var testPassword = getPassword.ExecuteScalar();

                    if(testPassword != null)
                    {
                        //getting user id
                        SqlCommand getUserID = new SqlCommand("SELECT ClimberID FROM NetUser WHERE Username = '" + userName + "'", conn);
                        Session["climberid"] = Convert.ToInt32(getUserID.ExecuteScalar().ToString());
                        Response.Redirect("Home.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("LoginPage.aspx", true);
                    }
                }
                else
                {
                    Response.Redirect("LoginPage.aspx", true);
                }

                conn.Close();
            }
        }
    }
}