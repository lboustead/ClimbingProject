using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClimbingProject
{
    public partial class Default : Page
    {
        //get User Name
        string userName = HttpContext.Current.User.Identity.Name;
        
        //Establish connection string
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucas\\source\\repos\\Work\\ClimbingProject\\App_Data\\ClimbingDatabase.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            string highestGradeSentQuery = "SELECT MAX(Grade_ID), GradeDescription FROM Grades, NetUser, Route, Sends " +
                "WHERE NetUser.Username = '" + userName + "' " +
                "AND NetUser.ClimberID = Sends.ClimberID " +
                "AND Sends.RouteID = Route.RouteID " +
                "AND Route.GradeID = Grades.Grade_ID " +
                "GROUP BY Grades.GradeDescription ";
            
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
                    HGS = s1.ToString();
                }
                conn.Close();
            }
            
        }

        
    }
}