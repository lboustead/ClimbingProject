using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Routing;
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
            //Get climberID
            int climberID = Convert.ToInt32(Request.QueryString["field1"].ToString());

            //get full name query
            string getFullNameQuery = "SELECT CONCAT(FirstName,' ',LastName) FROM Climber WHERE Climber.ClimberID = '"+climberID+"'";
            string highestGradeSentQuery = "SELECT GradeDescription FROM Grades WHERE Grade_ID in (SELECT MAX(Grade_ID) FROM Grades, NetUser, Route, Sends WHERE NetUser.ClimberID = '"+climberID+"' AND NetUser.ClimberID = Sends.ClimberID AND Sends.RouteID = Route.RouteID AND Route.GradeID = Grades.Grade_ID)";
            string averageGradeSentQuery = "SELECT GradeDescription FROM Grades WHERE Grade_ID in (SELECT ROUND(AVG(Grade_ID), 0) FROM Grades, NetUser, Route, Sends WHERE NetUser.ClimberID = '"+climberID+"' AND NetUser.ClimberID = Sends.ClimberID AND Sends.RouteID = Route.RouteID AND Route.GradeID = Grades.Grade_ID)\r\n";
            string mostClimbedLocationQuery = "";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand getFullName = new SqlCommand(getFullNameQuery, conn);
                SqlCommand getHighestGradeSent = new SqlCommand(highestGradeSentQuery, conn);
                SqlCommand getAverageGradeSent = new SqlCommand(averageGradeSentQuery, conn);
                SqlCommand getMostClimbedLocation = new SqlCommand(mostClimbedLocationQuery, conn);

                //setting full name
                lblName.Text = "Hello, "+getFullName.ExecuteScalar().ToString();

                //setting HighestGradeSent
                HGSlbl.Text = getHighestGradeSent.ExecuteScalar().ToString();

                //setting AverageGradeSent
                AGSlbl.Text = getAverageGradeSent.ExecuteScalar().ToString();

                conn.Close();
            }
        }
    }
}