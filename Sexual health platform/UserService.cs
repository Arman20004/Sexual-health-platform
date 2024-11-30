using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

public class UserService
{
    private readonly string _connectionString;

    public UserService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<bool> CheckUserCredentialsAsync(string login, string passwordHash)
    {
        const string query = "SELECT COUNT(1) FROM Users WHERE Login = @Login AND PasswordHash = @PasswordHash";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                var count = (int) await command.ExecuteScalarAsync();
                return count > 0;
            }
        }
    }
}
