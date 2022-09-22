using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace LearningCSharp
{
    class SQLConnection
    {
        readonly string connectionString;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public SQLConnection(string sqlScript)
        {
           var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                Console.WriteLine("AppSettings is empty.");
            }
            else
            {
                connectionString = appSettings["ConnectionString"];
                sqlConnection = new SqlConnection(connectionString);
                sqlCommand = new SqlCommand(sqlScript, sqlConnection);
            }
        }

        public bool ExecuteScalar()
        {
            try
            {
                sqlConnection.Open();
                bool result = sqlCommand.ExecuteScalar().Equals(1);
                sqlConnection.Close();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
                throw;
            }
        }

        public void ExecuteNonQuery()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }



    }
}
