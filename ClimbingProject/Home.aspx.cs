using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClimbingProject
{
    public partial class Home : System.Web.UI.Page
    {
        
        //Establish connection string
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucas\\source\\repos\\Work\\ClimbingProject\\App_Data\\ClimbingDatabase.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("SESSION");
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string userName = ticket.Name;
            


            string highestGradeSentQuery = "SELECT MAX(Grade_ID), GradeDescription FROM Grades, NetUser, Route, Sends " +
                "WHERE NetUser.Username = '" + userName + "' " +
                "AND NetUser.ClimberID = Sends.ClimberID " +
                "AND Sends.RouteID = Route.RouteID " +
                "AND Route.GradeID = Grades.Grade_ID " +
                "GROUP BY Grades.GradeDescription ";

            lbl.Text = userName;
            string highestGradeAttemptQuery = "";
            string averageGradeSentQuery = "";
            string mostClimbedLocationQuery = "";

            string HGS = "";
            string HGA = "";
            string AGS = "";
            string MCL = "";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand getHighestGradeSent = new SqlCommand(highestGradeSentQuery, conn);
                SqlCommand getHighestGradeAttempt = new SqlCommand(highestGradeAttemptQuery, conn);
                SqlCommand getAverageGradeSent = new SqlCommand(averageGradeSentQuery, conn);
                SqlCommand getMostClimbedLocation = new SqlCommand(mostClimbedLocationQuery, conn);

                var s1 = getHighestGradeSent.ExecuteScalar();
                //varify not null
                if (s1 != null)
                {
                    HGSlbl.Text = s1.ToString();
                }
                conn.Close();
            }
        }
    }
}