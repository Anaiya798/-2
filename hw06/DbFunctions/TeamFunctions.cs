using System.Data.SqlClient;

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

                transaction.Commit();
                Console.WriteLine("Данные добавлены в базу данных");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }
    }
}
