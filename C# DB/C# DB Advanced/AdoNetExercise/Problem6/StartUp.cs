namespace Problem6
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

                string villainName = GetVillainName(id, connection);
                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                int affectedRows = deleteMinionsVillainsById(connection, id);
                DeleteVillainById(connection, id);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        private static void DeleteVillainById(SqlConnection connection, int id)
        {
            string deleteVillainQueary = 
                @"DELETE FROM Villains
                WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQueary, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                command.ExecuteNonQuery();
            }
        }

        private static int deleteMinionsVillainsById(SqlConnection connection, int id)
        {
            string deleteFromMininonsVillainsSql =
                    @"DELETE FROM MinionsVillains 
                    WHERE VillainId = @villainId";
            using (SqlCommand command = new SqlCommand(deleteFromMininonsVillainsSql, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                return command.ExecuteNonQuery();
            }
        }

        private static string GetVillainName(int id, SqlConnection connection)
        {
            string villianNameQueary = "SELECT Name FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(villianNameQueary, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                return (string)command.ExecuteScalar();
            }
        }
    }
}
