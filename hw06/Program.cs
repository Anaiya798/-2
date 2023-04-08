using System.Configuration;
using System.Data.SqlClient;
using AdoNetFootball.DbFunctions;

class Program
{
    public static void GetConnectionInfo(SqlConnection connection)
    {
        Console.WriteLine("Свойства подключения:");
        Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
        Console.WriteLine("\tБаза данных: {0}", connection.Database);
        Console.WriteLine("\tСервер: {0}", connection.DataSource);
        Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
        Console.WriteLine("\tСостояние: {0}", connection.State);
        Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
    }
   
    public static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Подключение открыто");
            
            
        
        }
        Console.WriteLine("Подключение закрыто...");

        Console.Read();

    }


}