using Microsoft.Data.SqlClient;
using Dapper;
using UserManagementAPI.Models;
using System.Text.Json.Serialization;

namespace UserManagementAPI.DataAccess
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found");
        }

        public async Task SaveUsersAsync(List<UserModel> users)
        {
            using var connection = new SqlConnection(_connectionString);
            foreach (var user in users)
            {
                try
                {
                    await connection.ExecuteAsync("INSERT INTO users (first_name, last_name, email, dob, country) VALUES (@FirstName, @LastName, @Email, @Dob, @Country)", user);
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    // Handle Dublicate Email Entries
                    Console.WriteLine($"Duplicate email detected: {user.Email}. Skipping entry.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while inserting user {user.Email}: {ex.Message}");
                }
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync(string? country = null)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT user_id AS UserId, first_name AS FirstName, last_name AS LastName, email AS Email, dob AS Dob, country AS Country FROM users";
            {
                if (!string.IsNullOrEmpty(country))
                {
                    query += " WHERE country = @Country";
                }

                query += " ORDER BY last_name";

                return await connection.QueryAsync<UserModel>(query, new { Country = country });
            }
        }

        public class MetricsModel
        {
            [JsonPropertyName("total_users")]
            public int TotalUsers { get; set; }

            [JsonPropertyName("countries_count")]
            public int CountriesCount { get; set; }

            [JsonPropertyName("average_age")]
            public double AverageAge { get; set; }
        }

        public async Task<dynamic> GetMetricsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var totalUsers = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM users");
            var countriesCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(DISTINCT country) FROM users");
            var averageAge = await connection.ExecuteScalarAsync<double>("SELECT AVG(DATEDIFF(YEAR, dob, GETDATE())) FROM users");

            return new MetricsModel
            {
                TotalUsers = totalUsers,
                CountriesCount = countriesCount,
                AverageAge = averageAge
            };
        }
    }
}
