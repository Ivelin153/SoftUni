namespace Problem4
{
    using AdoNetExercise;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] minionInput = Console.ReadLine().Split().Skip(1).ToArray();
            string[] villainInput = Console.ReadLine().Split().Skip(1).ToArray();

            string minionName = minionInput[0];
            int minionAge = int.Parse(minionInput[1]);
            string town = minionInput[2];

            string villainName = villainInput[0];

            using (SqlConnection connection = new SqlConnection
                (Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownByName(town, connection);

                if (townId == null)
                {
                    AddTown(connection, town);
                }

                townId = GetTownByName(town, connection);

                AddMinion(connection, minionName, minionAge, townId);

                int? villainId = GetVillainByName(connection, villainName);

                if (villainId == null)
                {
                    AddVillain(villainName, connection);
                }

                villainId = GetVillainByName(connection, villainName);
                int minionId = GetMinionByName(connection, minionName);
                AddMinionsVillains(connection, minionId, villainId, minionName, villainName);
            }

        }

        private static void AddMinionsVillains(SqlConnection connection, int minionId, int? villainId, string minionName, string villainName)
        {
            string insertMinionVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertMinionVillain, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue(@"minionId", minionId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static int GetMinionByName(SqlConnection connection, string minionName)
        {
            string minionQueary = "SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(minionQueary, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int)command.ExecuteScalar();
            }
        }

        private static void AddVillain(string villainName, SqlConnection connection)
        {
            string insertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(insertVillain, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static int? GetVillainByName(SqlConnection connection, string villainName)
        {
            string villainIdQueary = "SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(villainIdQueary, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string name, int age, int? townId)
        {
            string insertMinionSql = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertMinionSql, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static int? GetTownByName(string town, SqlConnection connection)
        {
            string townIdQueary = "SELECT Id FROM Towns WHERE Name = @townName";

            using (SqlCommand command = new SqlCommand(townIdQueary, connection))
            {
                command.Parameters.AddWithValue("@townName", town);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string town)
        {
            string insertTownSql = "INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(insertTownSql, connection))
            {
                command.Parameters.AddWithValue("@townName", town);

                command.ExecuteNonQuery();

                Console.WriteLine($"Town {town} was added to the database.");
            }
        }
    }
}
