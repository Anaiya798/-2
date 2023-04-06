using System;
using System.Data.SqlClient;

namespace AdoNetFootball.DbFunctions
{
    public static class StadiumFunctions
    {
        public static void AddStadium(string name, SqlConnection connection)
        {
            string sqlExpression = String.Format("INSERT INTO Stadium1 (Name) VALUES ('{0}')", name);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
        }

        public static void RenameStadium(int id, string newName, SqlConnection connection)
        {
            string sqlExpression = String.Format("UPDATE Stadium1 SET Name='{1}' WHERE ID={0}", id, newName);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
        }
    }
}
