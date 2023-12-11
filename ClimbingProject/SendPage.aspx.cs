using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClimbingProject
{
    public partial class SendPage : System.Web.UI.Page
    {
        // Connect to the database - LOCAL CONNECTION STRING
        private string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ClimbingDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            // Don't execute on postback so that the selected index value is correct
            if (!IsPostBack)
            {
                // Query to retrieve locations id/description
                string queryLocation = "SELECT Location_ID, Description FROM LocationTable";

                // Create a DataTable to store the results
                DataTable dataTableLocation = new DataTable();

                try
                {
                    // Use SqlConnection, SqlDataAdapter to fetch the data for location and grade
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();
                        using (SqlDataAdapter adapterLocation = new SqlDataAdapter(queryLocation, connection))
                        {
                            adapterLocation.Fill(dataTableLocation);
                        }

                        // Close the connection afterwards
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }

                // Bind the location dropdown
                drpLocation.DataSource = dataTableLocation;
                drpLocation.DataTextField = "Description";
                drpLocation.DataValueField = "Location_ID";
                drpLocation.DataBind();
            }
        }

        protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Grab location index from dropdown
            int LocationID = Int32.Parse(drpLocation.SelectedValue);

            //Find grades associated with location and its routes
            string queryGrades = $"SELECT R.GradeID, G.GradeDescription FROM Route R " +
                $"JOIN Grades G ON G.Grade_ID = R.GradeID " +
                $"WHERE LocationID = {LocationID};";

            //Turn GradeID's into descriptions
            // Create a DataTable to store the results
            DataTable dataTableGrades = new DataTable();

            try
            {
                // Use SqlConnection, SqlDataAdapter to fetch the data for location and grade
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();


                    using (SqlDataAdapter adapterGrades = new SqlDataAdapter(queryGrades, conn))
                    {
                        adapterGrades.Fill(dataTableGrades);
                    }

                    // Close the connection afterwards
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }

            // Bind the location dropdown
            drpGrade.DataSource = dataTableGrades;
            drpGrade.DataTextField = "GradeDescription";
            drpGrade.DataValueField = "GradeID";
            drpGrade.DataBind();
        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            //Obtain climberid
            int climberID = Convert.ToInt32(Session["climberid"].ToString());

            //Obtain attempts
            int attempts = Int32.Parse(txtAttempts.Text);

            try
            {
                // Use SqlConnection, SqlDataAdapter to fetch the data for location and grade
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    //Query to find routeID
                    string queryRouteID = $"SELECT RouteID FROM Route WHERE LocationID = {drpLocation.SelectedValue} " +
                        $"AND GradeID = {drpGrade.SelectedValue};";
                    SqlCommand getRouteID = new SqlCommand(queryRouteID, connection);
                    int routeID = Int32.Parse(getRouteID.ExecuteScalar().ToString());

                    //Insert Query
                    string insertQuery = $"INSERT INTO Sends (ClimberID, RouteID, Attempts) VALUES ({climberID}, {routeID}, {attempts});";

                    //Execute query
                    SqlCommand insertSend = new SqlCommand(insertQuery, connection);
                    insertSend.ExecuteNonQuery();

                    // Close the connection afterwards
                    connection.Close();

                    //Show success message
                    lblSuccessMessage.Text = "Your new send has been updated!";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}