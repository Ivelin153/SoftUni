namespace Problem8
{
    using AdoNetExercise;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] ids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateSql =
                    @"UPDATE Minions
                    SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                    WHERE Id = @Id";

                foreach (var id in ids)
                {
                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }

                string getMinionsSql = @"SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(getMinionsSql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }

            }
        }
    }
}
