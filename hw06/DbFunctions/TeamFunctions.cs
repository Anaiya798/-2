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
                command.CommandText = String.Format("INSERT INTO Team (Name, EstYear) VALUES ('{0}', {1})", name, year);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("SELECT TOP 1 (ID) FROM Team ORDER BY ID DESC");
                int id = int.Parse((command.ExecuteScalar().ToString()));
                command.CommandText = String.Format("INSERT INTO Stats (TeamID, NumberOfPlayers, NumberOfStadiums, AverageGoalsPerPlayer) VALUES ({0}, 0, 0, 0)", id);
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
            string sqlExpression = String.Format("UPDATE Team SET Name='{1}' WHERE ID={0}", id, newName);
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
                command.CommandText = String.Format("UPDATE Stats SET NumberOfStadiums=NumberOfStadiums+1 WHERE TeamID={0}", teamID);
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
                command.CommandText = String.Format("UPDATE Stats SET NumberOfStadiums=NumberOfStadiums-1 WHERE TeamID={0}", teamID);
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

        public static void GetTeamPlayers(int teamID, SqlConnection connection)
        {
            string sqlExpression = "sp_GetTeamPlayers";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter teamIDParam = new SqlParameter
            {
                ParameterName = "@teamID",
                Value = teamID
            };
            command.Parameters.Add(teamIDParam);

            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {          

                while (reader.Read())
                {
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    Console.WriteLine("{0} \t{1}", firstName, lastName);
                }
            }
            reader.Close();
        }
    }
}
