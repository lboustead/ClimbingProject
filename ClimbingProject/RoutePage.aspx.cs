using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ClimbingProject
{
    public partial class RoutePage : System.Web.UI.Page
    {
        // Connect to the database - LOCAL CONNECTION STRING
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ClimbingDatabaseConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtain climberid
            int locationID = Convert.ToInt32(Session["climberid"].ToString());

            // Don't execute on postback so that the selected index value is correct
            if (!IsPostBack)
            {
                // Query to retrieve locations id/description
                string queryLocation = "SELECT Location_ID, Description FROM LocationTable";

                // Query to retrieve grade id/description
                string queryGrade = "SELECT GradeID, GradeDescription FROM Grades";

                // Create a DataTable to store the results
                DataTable dataTableLocation = new DataTable();
                DataTable dataTableGrade = new DataTable();

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
                        using (SqlDataAdapter adapterGrade = new SqlDataAdapter(queryGrade, connection))
                        {
                            adapterGrade.Fill(dataTableGrade);
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
                drpLocation.DataValueField = "LocationID";
                drpLocation.DataBind();

                // Bind the grade dropdown
                drpGrade.DataSource = dataTableGrade;
                drpGrade.DataTextField = "GradeDescription";
                drpGrade.DataValueField = "GradeID";
                drpGrade.DataBind();
            }
        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            // Create the SQL query
            string query = $"INSERT INTO Route (LocationID, GradeID) VALUES ({drpLocation.SelectedValue}, {drpGrade.SelectedValue})";

            // Create SqlConnection and SqlCommand
            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // The record was added successfully
                        lblSuccessMessage.Text = ("Route added successfully!");
                    }
                    else
                    {
                        // No rows were affected, something went wrong
                        lblErrorMessage.Text = ("Failed to add route - make sure you have valid inputs.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions and display an error message
                    lblErrorMessage.Text = ($"An error occurred: {ex.Message}");
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
            }
        }
    }
}