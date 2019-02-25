namespace Problem_2
{
    using System;
    using AdoNetExercise;
    using System.Data.SqlClient;
    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection
                (Configuration.ConnectionString))
            {
                connection.Open();

                string cmdText =
                    @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                    FROM Villains AS v
                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                    GROUP BY v.Id, v.Name
                    HAVING COUNT(mv.VillainId) > 3
                    ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} - {age}");
                        }
                    }
                }
            }
        }
    }
}
