using System.Data.SqlClient;
using System.Xml.Linq;

namespace AdoNetFootball.DbFunctions
{
    public static class TeamFunctions
    {
        public static void AddTeam(string name, int year, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = String.Format("INSERT INTO Team1 (Name, EstYear) VALUES ('{0}', {1})", name, year);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("SELECT TOP 1 (ID) FROM Team1 ORDER BY ID DESC");
                int id = int.Parse((command.ExecuteScalar().ToString()));
                Console.WriteLine(id);
                command.CommandText = String.Format("INSERT INTO Stats1 (TeamID, NumberOfPlayers, NumberOfStadiums, AverageGoalsPerPlayer) VALUES ({0}, 0, 0, 0)", id);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("AddTeam successfull");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }

        public static void RenameTeam(int id, string newName, SqlConnection connection)
        {
            string sqlExpression = String.Format("UPDATE Team1 SET Name='{1}' WHERE ID={0}", id, newName);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
        }

        public static void AddStadium(int teamID, int stadiumID, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = String.Format("INSERT INTO TeamStadium (TeamID, StadiumID) VALUES ({0}, {1})", teamID, stadiumID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("UPDATE Stats1 SET NumberOfStadiums=NumberOfStadiums+1 WHERE TeamID={0}", teamID);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("AddStadium for Team successfull");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }

        public static void RemoveStadium(int teamID, int stadiumID, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = String.Format("DELETE FROM TeamStadium WHERE TeamID={0}", teamID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("UPDATE Stats1 SET NumberOfStadiums=NumberOfStadiums-1 WHERE TeamID={0}", teamID);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("RemoveStadium for Team successfull");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }
    }
}
