using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace ClimbingProject
{
    public partial class Home : System.Web.UI.Page
    {
        
        //Establish connection string
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ClimbingDatabaseConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get climberID if not null. If null, redirect to login
            if (Session["climberid"] == null)
            {
                Response.Redirect("LoginPage.aspx", true);
            }
            //Adding variable to session
            int climberID = Convert.ToInt32(Session["climberid"].ToString());

            //fill gridview
            string gridViewQuery = $"SELECT Description AS 'Location:', GradeDescription AS 'Grade:', Attempts AS 'Attempts:' FROM Sends, Route, Grades, LocationTable WHERE Sends.ClimberID = {climberID} AND Sends.RouteID = Route.RouteID AND Route.LocationID = LocationTable.Location_ID AND Route.GradeID = Grades.Grade_ID";
            if (Session["climberid"] == null)
            {
                Response.Redirect("LoginPage.aspx", true);
            }";
            // Connect to the database and run the query.
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(gridViewQuery, connection);
                DataSet data = new DataSet();
                // Fill the DataSet.
                adapter.Fill(data);

                GridView1.DataSource = data;
                GridView1.DataBind();
            }
                
            //get full name query
            string getFullNameQuery = "SELECT CONCAT(FirstName,' ',LastName) FROM Climber WHERE Climber.ClimberID = '"+climberID+"'";
            string highestGradeSentQuery = "SELECT GradeDescription FROM Grades WHERE Grade_ID in (SELECT MAX(Grade_ID) FROM Grades, NetUser, Route, Sends WHERE NetUser.ClimberID = '"+climberID+"' AND NetUser.ClimberID = Sends.ClimberID AND Sends.RouteID = Route.RouteID AND Route.GradeID = Grades.Grade_ID)";
            string averageGradeSentQuery = "SELECT GradeDescription FROM Grades WHERE Grade_ID in (SELECT ROUND(AVG(Grade_ID), 0) FROM Grades, NetUser, Route, Sends WHERE NetUser.ClimberID = '"+climberID+"' AND NetUser.ClimberID = Sends.ClimberID AND Sends.RouteID = Route.RouteID AND Route.GradeID = Grades.Grade_ID)";
            string mostClimbedLocationQuery = "SELECT CONCAT(Description,', ' , City, ', ', StateName) FROM LocationTable WHERE Location_ID in (SELECT LocationID FROM NetUser, Sends, Route, LocationTable WHERE NetUser.ClimberID = '"+climberID+"' AND NetUser.ClimberID = Sends.ClimberID AND Sends.RouteID = Route.RouteID AND Route.LocationID = LocationTable.Location_ID GROUP BY LocationID ORDER BY COUNT(LocationID) DESC OFFSET 0 ROWS FETCH FIRST 1 ROWS ONLY)";

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

                //setting MostClimbedLocation
                MCLlbl.Text = getMostClimbedLocation.ExecuteScalar().ToString();

                conn.Close();
            }
        }
    }
}