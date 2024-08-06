using MySql.Data.MySqlClient;
using System.Data;

public class MySqlConnectionHelper
{
    private readonly string _connectionString;

    public MySqlConnectionHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    public int ExecuteNonQuery(string query, MySqlParameter[] parameters)
    {
        using (MySqlConnection connection = GetConnection())
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public MySqlDataReader ExecuteReader(string query, MySqlParameter[] parameters)
    {
        MySqlConnection connection = GetConnection();
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddRange(parameters);
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}