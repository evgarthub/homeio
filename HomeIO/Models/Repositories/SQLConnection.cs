using System;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class SQLConnection
    {
        public SqlConnection DBInstance { get; set; }

        public SQLConnection()
        {
            DBInstance = new SqlConnection(
            "user=dbuser;" +
            "password=admin;" +
            "server=" +
			Environment.MachineName +
			@"\SQLEXPRESS;" +
            "database=homeio;");
        }

        public void Open()
        {
            DBInstance.Open();
        }

        public void Close()
        {
            DBInstance.Close();
        }

        public SqlCommand CreateCommand(string commandText)
        {
            Open();
            SqlCommand command = new SqlCommand();
            command.Connection = DBInstance;
            command.CommandText = commandText;
            return command;
        }
    }
}