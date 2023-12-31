﻿using System;
using System.Data.SqlClient;

namespace ClimbingProject
{
    public partial class LocationPage : System.Web.UI.Page
    {
        // Connect to the database - LOCAL CONNECTION STRING
        private string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ClimbingDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            //Obtain climberid
            int locationID = Convert.ToInt32(Session["climberid"].ToString());

            // All fields are filled with validators - ensure they are all less than 50 characters
            if (txtCity.Text.Length >= 50 || txtDescription.Text.Length >= 50 || txtState.Text.Length >= 50)
            {
                lblErrorMessage.Text = "Please enter less than 50 characters";
                return;
            }

            
            // Query to insert value
            string query = $"INSERT INTO LocationTable (StateName, City, Description) VALUES ('{txtState.Text}', '{txtCity.Text}', '{txtDescription.Text}')";

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
                        lblSuccessMessage.Text = ("Location added successfully!");
                    }
                    else
                    {
                        // No rows were affected, something went wrong
                        lblErrorMessage.Text = ("Failed to add location - make sure you have valid inputs.");
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