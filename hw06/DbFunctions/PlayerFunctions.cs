
using System.Data.SqlClient;
using System.Xml.Linq;

namespace AdoNetFootball.DbFunctions
{
    public class Address
    {
        public string Country { get; private set; }
        public string City { get; private set; }    
        public string Street { get; private set; }
        public int Building { get; private set; }
        public int Appartment { get; private set; }

        public Address(string country, string city, string street, int building, int appartmanet)
        {
            Country = country;
            City = city;
            Street = street;
            Building = building;    
            Appartment = appartmanet;
        }
    }
    public static class PlayerFunctions
    {
        public static void AddPlayer(string firstName, string lastName, int teamID, Address address, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            
            try
            {
                command.CommandText = String.Format("INSERT INTO Address (Country, City, Street, Building, Appartment)" +
                    " VALUES ('{0}', '{1}', '{2}', {3}, {4})", address.Country, address.City, address.Street, address.Building, address.Appartment);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("SELECT TOP 1 (ID) FROM Address ORDER BY ID DESC");
                int addressID = int.Parse((command.ExecuteScalar().ToString()));
                command.CommandText = String.Format("INSERT INTO Player (FirstName, LastName, AddressID, TeamID, NumberOfGoals)" +
                    " VALUES ('{0}', '{1}', {2}, {3}, 0)", firstName, lastName, addressID, teamID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("UPDATE Stats SET NumberOfPlayers=NumberOfPlayers+1 WHERE TeamID={0}", teamID);
                command.ExecuteNonQuery();


                transaction.Commit();
                Console.WriteLine("AddPlayer successfull");

                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        } 
        
        public static void ScoreGoal(int playerID, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = String.Format("UPDATE Player SET NumberOfGoals=NumberOfGoals+1 WHERE ID={0}", playerID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("SELECT TeamID FROM Player WHERE ID={0}", playerID);
                int teamID = int.Parse((command.ExecuteScalar().ToString()));
                command.CommandText = String.Format("SELECT ROUND(AVG(NumberOfGoals), 1) FROM Player WHERE TeamID={0}", teamID);
                int avgGoals = int.Parse((command.ExecuteScalar().ToString()));
                command.CommandText = String.Format("UPDATE Stats SET AverageGoalsPerPlayer={0} WHERE TeamID={1}", avgGoals, teamID);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("ScoreGoal successfull");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }

        }
        public static void ChangeTeam(int playerID, int newTeamID, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = String.Format("SELECT TeamID FROM Player WHERE ID={0}", playerID);
                int oldTeamID = int.Parse((command.ExecuteScalar().ToString()));
                command.CommandText = String.Format("UPDATE Player SET TeamID={0} WHERE ID={1}", newTeamID, playerID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("UPDATE Stats SET NumberOfPlyers=NumberOfPlayers-1 WHERE TeamID={0}", oldTeamID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("UPDATE Stats SET NumberOfPlyers=NumberOfPlayers+1 WHERE TeamID={0}", newTeamID);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("ChangeTeam successfull");

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }

        }

        public static void DeletePlayer(int playerID, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = String.Format("SELECT TeamID FROM Player WHERE ID={0}", playerID);
                int teamID = int.Parse((command.ExecuteScalar().ToString()));
                command.CommandText = String.Format("DELETE FROM Player WHERE ID={0}", playerID);
                command.ExecuteNonQuery();
                command.CommandText = String.Format("UPDATE Stats SET NumberOfPlyers=NumberOfPlayers-1 WHERE TeamID={0}", teamID);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("DeletePlayer successfull");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }
    }
}
