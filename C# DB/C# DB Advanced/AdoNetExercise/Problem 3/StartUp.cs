namespace Problem3
{
    using AdoNetExercise;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection
                (Configuration.ConnectionString))
            {
                connection.Open();
                string villianNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(villianNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    
                    string villianName = (string)command.ExecuteScalar();

                    if (villianName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }
                    Console.WriteLine($"Villain: {villianName}");                  
                }

                string minionsQuery =
                      @"SELECT 
	                        ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                            m.Name, 
                            m.Age
                        FROM MinionsVillains AS mv
                        JOIN Minions As m ON mv.MinionId = m.Id
                        WHERE mv.VillainId = @Id
                        ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                            return;
                        }
                        Console.WriteLine("(no minions)");
                    }
                }
            }
        }
    }
}
